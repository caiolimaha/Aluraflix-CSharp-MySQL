using Aluraflix.Data.Dtos;
using Aluraflix.Models;
using AutoMapper;
using System.Linq;

namespace Aluraflix.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<Categoria, ReadCategoriaDto>();
            CreateMap<UpdateCategoriaDto, Categoria>();
        }
    }
}
