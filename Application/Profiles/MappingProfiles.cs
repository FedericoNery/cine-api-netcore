using Application.DTO_s;
using AutoMapper;
using Domain;

namespace Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<MovieDTO, Movie>().ReverseMap();
            CreateMap<ReservationDTO, Reservation>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
