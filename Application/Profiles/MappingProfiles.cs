using Application.DataContract.Preguntas;
using Application.DTO_s;
using Application.DTO_s.Entrevista;
using Application.DTO_s.Movie;
using Application.DTO_s.Plantilla;
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
            CreateMap<CrearPreguntaDataContract, PreguntaRespuesta>().ReverseMap();
            CreateMap<CrearPlantillaDataContract, Plantilla>().ReverseMap();
            CreateMap<EntrevistaDTO, Entrevista>().ReverseMap();
            CreateMap<PlantillaDTO, Plantilla>().ReverseMap();
            CreateMap<CrearEntrevistaDataContract, Entrevista>().ReverseMap();
        }
    }
}
