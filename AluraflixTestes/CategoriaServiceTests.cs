using Aluraflix.Data.Dtos;
using Aluraflix.Profiles;
using Aluraflix.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AluraflixTestes
{
    public class CategoriaServiceTests
    {
        private CategoriaService _categoriaService;
        private IMapper _mapper;

        public CategoriaServiceTests()
        {
            var dbInMemory = new DBInMemory();
            var context = dbInMemory.GetContext();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CategoriaProfile>();
            });
            _mapper = new Mapper(config);
            _categoriaService = new CategoriaService(context, _mapper);
        }

        [Fact]
        public async Task AdicionaCategoria()
        {
            //Arrange
            CreateCategoriaDto categoriaCreate = new CreateCategoriaDto();
            categoriaCreate.Titulo = "CategoriaTeste2";
            categoriaCreate.Cor = "FFFFFF";

            //Act
            ReadCategoriaDto categoriaRead = await _categoriaService.AdicionaCategoria(categoriaCreate);

            //Assert
            Assert.IsType<ReadCategoriaDto>(categoriaRead);
        }

        [Fact]
        public async Task RecuperaCategoria()
        {
            //Act
            var categorias = await _categoriaService.RecuperaCategorias();

            //Assert
            Assert.Single(categorias);
        }

        [Fact]
        public async Task RecuperaCategoriaPorId()
        {
            //Act
            var categoria = await _categoriaService.RecuperaCategoriaPorId(1);

            //Assert
            Assert.NotNull(categoria);
        }
    }
}
