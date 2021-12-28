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

        [HttpPost]
        public IActionResult AdicionaVideo([FromBody] CreateVideoDto videoDto)
        {
            ReadVideoDto readDto = _videoService.AdicionaVideo(videoDto);
            return CreatedAtAction(nameof(RecuperaVideoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaVideoPorId(int id)
        {
            ReadVideoDto readDto = _videoService.RecuperaVideoPorId(id);
            if(readDto == null) return NotFound();
            return Ok(readDto);
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
