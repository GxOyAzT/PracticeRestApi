using AutoMapper;

namespace AllBackgroundStuff
{
    public class ModelAProfile : Profile
    {
        public ModelAProfile()
        {
            CreateMap<ModelA, ModelAReadDTO>();
            CreateMap<ModelACreateDTO, ModelA>();
            CreateMap<ModelAUpdateDTO, ModelA>();
            CreateMap<ModelA, ModelAUpdateDTO>();
        }
    }
}
