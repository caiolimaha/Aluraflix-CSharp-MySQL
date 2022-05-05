using Aluraflix.Controllers;
using Aluraflix.Data.Dtos;
using Aluraflix.Services;
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
        //private Mock<IVideoService> _videoControllerMock = new Mock<IVideoService>();

        //private VideoController _videoController;

        //public ITestOutputHelper Output { get; }




        //public VideoControllerTests(ITestOutputHelper testOutputHelper)
        //{
        //    Output = testOutputHelper;
        //    _videoController = new VideoController(_videoControllerMock.Object);
        //}

        //[Fact]
        //public async Task ComValoresCorretos_AdicionaVideo_RetornaEndereco()
        //{
        //    //Arrange
        //    //Act
        //    //Assert
        //}

        //[Fact]
        //public async Task ComValoresCorretos_RecuperaVideo_RetornaOk()
        //{
        //    //Arrange
        //    //Act
        //    //Assert

        //}


        public void Dispose()
        {
            //Output.WriteLine("Execução Cleanup : Limpando os objetos");
        }
    }
}
