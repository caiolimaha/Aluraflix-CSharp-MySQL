using Aluraflix.Controllers;
using Aluraflix.Services;
using Moq;
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
        private Mock<IVideoService> _videoControllerMock = new Mock<IVideoService>();

        private VideoController _videoController;

        public ITestOutputHelper Output { get; }


        public VideoControllerTests(ITestOutputHelper testOutputHelper)
        {
            Output = testOutputHelper;
            _videoController = new VideoController(_videoControllerMock.Object);
        }

        [Fact]
        public async Task TestaRecuperaVideos()
        {
            //Arrange
            //Act
            var resultado = await _videoController.RecuperaVideos(null);
            //Assert
            Assert.NotNull(resultado);
        }


        public void Dispose()
        {
            Output.WriteLine("Execução Cleanup : Limpando os objetos");
        }
    }
}
