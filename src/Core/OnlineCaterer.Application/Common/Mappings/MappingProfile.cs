
namespace OnlineCaterer.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // booking mapping
            CreateMap<Booking, BookingResponse>();
            CreateMap<BookingResponse, Booking>();


        }
    }
}
