using System.ComponentModel.DataAnnotations;

namespace HotellistingApi.Models.Country
{
    public abstract class BaseCountryDto
    { 
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }

    }
}
