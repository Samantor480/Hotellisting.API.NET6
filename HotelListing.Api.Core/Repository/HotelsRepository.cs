﻿using AutoMapper;
using Hotellisting.Api.Core.Contracts;
using HotellistingApi.Data;

namespace Hotellisting.Api.Core.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        public HotelsRepository(HotelListingDbContext context ,IMapper mapper) : base(context, mapper)
        {
        }
    }
}
