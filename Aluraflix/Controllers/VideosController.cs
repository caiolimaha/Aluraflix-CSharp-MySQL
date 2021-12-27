using Aluraflix.Data.Dtos.Video;
using Aluraflix.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Aluraflix.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class VideosController : ControllerBase
    {
        private VideoService _videoService;

        public VideosController(VideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public IActionResult RecuperaVideos()
        {
            List<ReadVideoDto> readDto = _videoService.RecuperaVideos();
            if(readDto == null) return NotFound();
            return Ok(readDto);
        }
    }
}
