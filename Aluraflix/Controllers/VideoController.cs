using Aluraflix.Data.Dtos;
using Aluraflix.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aluraflix.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class VideoController : ControllerBase
    {
        private VideoService _videoService;

        public VideoController(VideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AdicionaVideo([FromBody] CreateVideoDto videoDto)
        {
            ReadVideoDto readDto = await _videoService.AdicionaVideo(videoDto);
            return CreatedAtAction(nameof(RecuperaVideoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
        public async Task<IActionResult> RecuperaVideoPorId(int id)
        {
            ReadVideoDto readDto = await _videoService.RecuperaVideoPorId(id);
            if(readDto == null) return NotFound("Não encontrado.");
            return Ok(readDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
        public async Task<IActionResult> RecuperaVideos([FromQuery] string nomeDoVideo)
        {
            List<ReadVideoDto> readDto = await _videoService.RecuperaVideoPorTitulo(nomeDoVideo);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AtualizaVideo(int id, [FromBody] UpdateVideoDto videoDto)
        {
            Result resultado = await _videoService.AtualizaVideo(id, videoDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeletaVideo(int id)
        {
            Result resultado = await _videoService.DeletaVideo(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
