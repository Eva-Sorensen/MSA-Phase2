using AutoMapper;
using MSA.Phase2.API.Data;
using MSA.Phase2.API.Models.Trainer;
using MSA.Phase2.API.Models.Pokemon;

namespace MSA.Phase2.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Trainer, CreateTrainerDto>().ReverseMap();
            CreateMap<Trainer, SimpleTrainerDto>().ReverseMap();
            CreateMap<Trainer, TrainerDto>().ReverseMap();
            CreateMap<Pokemon, CreatePokemonDto>().ReverseMap();
            CreateMap<Pokemon, SimplePokemonDto>().ReverseMap();
            CreateMap<Pokemon, PokemonDto>().ReverseMap();
        }
    }
}