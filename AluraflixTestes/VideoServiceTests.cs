
using Aluraflix.Data.Dtos;
using Aluraflix.Profiles;
using Aluraflix.Services;
using AutoMapper;
using FluentResults;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

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
            var numeroVideos = await _videoService.RecuperaVideoPorTitulo("");
            Assert.Equal(3, numeroVideos.Count());
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
            var video = await _videoService.RecuperaVideoPorId(1);

            //Assert
            Assert.NotNull(video);
            Assert.Equal("VideoTeste", video.Titulo);
        }

        [Fact]
        public async Task AtualizaVideo()
        {
            //Arrange
            UpdateVideoDto videoUpdate = new UpdateVideoDto();
            videoUpdate.Titulo = "VideoUpdate";
            videoUpdate.Descricao = "DescriçãoVideoTeste";
            videoUpdate.CategoriaId = 20;

            //Act
            var resultado = await _videoService.AtualizaVideo(2, videoUpdate);

            //Assert
            var video = await _videoService.RecuperaVideoPorId(2);
            Assert.IsType<Result>(resultado);
            Assert.Equal("VideoUpdate",video.Titulo);
        }

    }
}
