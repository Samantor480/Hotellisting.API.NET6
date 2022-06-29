using HotellistingApi.Contracts;
using HotellistingApi.Data;

namespace HotellistingApi.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        public HotelsRepository(HotelListingDbContext context) : base(context)
        {
        }
    }
}
