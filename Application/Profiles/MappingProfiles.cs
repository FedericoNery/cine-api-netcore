using Application.DTO_s;
using Application.DTO_s.Movie;
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
            CreateMap<CreateMovieDTO, Movie>();
            CreateMap<UpdateMovieDTO, Movie>();
            CreateMap<DeleteMovieDTO, int>();
        }
    }
}
