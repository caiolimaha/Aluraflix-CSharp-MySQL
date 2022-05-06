using Aluraflix.Controllers;
using Aluraflix.Data.Dtos;
using Aluraflix.Models;
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
using Xunit.Abstractions;

namespace AluraflixTestes
{
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private IMapper _mapper;

        public VideoServiceTests()
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
        public async Task AdicionaVideo()
        {
            //Arrange
            var videoDto = new CreateVideoDto();
            videoDto.Titulo = "VideoTeste3";
            videoDto.Descricao = "DescriçãoVideoTeste3";
            videoDto.CategoriaId = 20;

            //Act
            var readVideo = await _videoService.AdicionaVideo(videoDto);

            //Assert
            Assert.IsType<ReadVideoDto>(readVideo);
        }

        [Fact]
        public async Task RecuperarVideosPorTitulo()
        {
            //Act
            var videos = await _videoService.RecuperaVideoPorTitulo("");

            //Assert
            Assert.Equal(2, videos.Count());
        }

        [Fact]
        public async Task RecuperaVideoPorId()
        {
            //Act
            var videos = await _videoService.RecuperaVideoPorId(1);

            //Assert
            Assert.NotNull(videos);
        }

        [Fact]
        public async Task AtualizaVideo()
        {
            //Arrange
            UpdateVideoDto videoUpdate = new UpdateVideoDto();
            videoUpdate.Titulo = "VideoAtualizado";
            videoUpdate.Descricao = "DescriçãoVideoTeste";
            videoUpdate.CategoriaId = 20;

            //Act
            var video = await _videoService.AtualizaVideo(1, videoUpdate);

            //Assert
            Assert.IsType<Result>(video);
        }

    }
}
