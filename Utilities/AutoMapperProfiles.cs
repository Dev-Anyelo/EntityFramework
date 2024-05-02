using AutoMapper;
using EntityFramework.DTOs;
using EntityFramework.Entities;

namespace EntityFramework.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Actor, ActorDTO>();
            CreateMap<CreationGenderDTO, Gender>();
            CreateMap<CreationActorDTO, Actor>();
            CreateMap<CreationCommentDTO, Comment>();

            CreateMap<CreationMovieDTO, Movie>().ForMember(
                ent => ent.Genders, 
                    dto => dto.MapFrom(
                       field => field.Genders.Select(
                                id => new Gender { Id = id }))
            );

            CreateMap<CreationMovieActorDTO, ActorMovie>();
        }
    }
}
