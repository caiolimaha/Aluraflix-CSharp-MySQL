using Aluraflix.Controllers;
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
using Xunit.Abstractions;

namespace AluraflixTestes
{
    public class VideoControllerTests : IDisposable
    {
        private VideoService _videoService;
        private IMapper _mapper;

        public VideoControllerTests()
        {
            var dbInMemory = new DBInMemory();
            var context = dbInMemory.GetContext();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<VideoProfile>();
            });
            _mapper = new Mapper(config);
            _videoService = new VideoService(context, _mapper);
        }

        [Fact]
        public async Task RecuperarVideosPorTitulo()
        {
            //Act
            var videos = await _videoService.RecuperaVideoPorTitulo("");
            //Assert
            Assert.Equal(2, videos.Count());
        }


        public void Dispose()
        {
            //Output.WriteLine("Execução Cleanup : Limpando os objetos");
        }
    }
}
