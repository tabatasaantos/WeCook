using WeCook.Domain;
using AutoMapper;
using WeCook.WebApi.ViewModels;

namespace WeCook.WebApi.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Receita, ReceitaViewModel>().ReverseMap();
        }
    }
}
