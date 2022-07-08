using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotellistingApi.Data;
using Hotellisting.Api.Core.Models.Country;
using AutoMapper;
using Hotellisting.Api.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Hotellisting.Api.Core.Exceptions;
using Microsoft.AspNetCore.OData.Query;

namespace Hotellisting.Api.Core.Controllers
{
    [Route("api/v{version:apiVersion}/countries")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CountriesV2Controller : ControllerBase
    {
        
        private readonly IMapper mapper;
        private readonly ICountriesRepository countriesRepository;
        private readonly ILogger<CountriesController> _logger;

        public CountriesV2Controller(IMapper mapper, ICountriesRepository countriesRepository, ILogger<CountriesController> logger)
        {
           
            this.mapper = mapper;
            this.countriesRepository = countriesRepository;
            this._logger = logger;
        }

        // GET: api/Countries
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var countries = await countriesRepository.GetAllAsync();
            var records = mapper.Map <List<GetCountryDto>>(countries);
      
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country =await countriesRepository.GetDetails(id);

            if (country == null)  
            {
                // _logger.LogWarning($"No record Found in the {nameof(GetCountry)} with the:{id}");
                throw new NotFoundException(nameof(GetCountry), id);
                
            }
            var countryDto = mapper.Map<CountryDto>(country);
            return Ok(countryDto);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]

        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            //_context.Entry(country).State = EntityState.Modified;
            var country = await countriesRepository.GetAsync(id);

            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountries), id);
            }

            mapper.Map(updateCountryDto, country);

            try
            {
                await countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountryDto)
        {
            /*  var country = new Country
              {
                  Name = createCountryDto.Name,
                  ShortName = createCountryDto.ShortName
              };*/

            var country = mapper.Map<Country>(createCountryDto);

            await countriesRepository.AddAsync(country);
            
            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await countriesRepository.GetAsync(id);
            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountries), id);
            }

            await countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task <bool> CountryExists(int id)
        {
            return await countriesRepository.Exists(id);
        }
    }
}
