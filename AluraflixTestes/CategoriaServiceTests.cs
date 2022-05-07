using Aluraflix.Data.Dtos;
using Aluraflix.Profiles;
using Aluraflix.Services;
using AutoMapper;
using FluentResults;
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
                cfg.AddProfile<VideoProfile>();
            });
            _mapper = new Mapper(config);
            _categoriaService = new CategoriaService(context, _mapper);
        }

        [Fact]
        public async Task AdicionaCategoria()
        {
            //Arrange
            CreateCategoriaDto categoriaCreate = new CreateCategoriaDto();
            categoriaCreate.Titulo = "CategoriaTeste3";
            categoriaCreate.Cor = "FFFFFF";

            //Act
            ReadCategoriaDto categoriaRead = await _categoriaService.AdicionaCategoria(categoriaCreate);

            //Assert
            var numeroCategorias = await _categoriaService.RecuperaCategorias();
            Assert.Equal(3, numeroCategorias.Count());
        }

        [Fact]
        public async Task RecuperaCategoria()
        {
            //Act
            var categorias = await _categoriaService.RecuperaCategorias();

            //Assert
            Assert.Equal(2, categorias.Count());
        }

        [Fact]
        public async Task RecuperaCategoriaPorId()
        {
            //Act
            var categoria = await _categoriaService.RecuperaCategoriaPorId(1);

            //Assert
            Assert.NotNull(categoria);
            Assert.Equal("CategoriaTeste", categoria.Titulo);
        }

        [Fact]
        public async Task AtualizaCategoria()
        {
            //Arrange
            UpdateCategoriaDto categoriaUpdate = new UpdateCategoriaDto();
            categoriaUpdate.Titulo = "CategoriaUpdate";
            categoriaUpdate.Cor = "FFFF00";

            //Act
            var resultado = await _categoriaService.AtualizaCategoria(2, categoriaUpdate);

            //Assert
            var categoria = await _categoriaService.RecuperaCategoriaPorId(2);
            Assert.IsType<Result>(resultado);
            Assert.Equal("CategoriaUpdate", categoria.Titulo);
        }

        [Fact]
        public async Task RecuperaVideoPorCategoria()
        {
            //Act
            var videos = await _categoriaService.RecuperaVideoPorCategoria(1);

            //Assert
            Assert.Single(videos);
        }

    }
}
