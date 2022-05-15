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
    public class CategoriaController : ControllerBase
    {

        private CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AdicionaCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {
            ReadCategoriaDto readDto = await _categoriaService.AdicionaCategoria(categoriaDto);
            return CreatedAtAction(nameof(RecuperaCategoriaPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> RecuperaCategorias()
        {
            List<ReadCategoriaDto> categoriasDto = await _categoriaService.RecuperaCategorias();
            if(categoriasDto == null) return NotFound();
            return Ok(categoriasDto);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin, regular")]
        public async Task<IActionResult> RecuperaCategoriaPorId(int id)
        {
            ReadCategoriaDto readDto = await _categoriaService.RecuperaCategoriaPorId(id);
            if(readDto == null) return NotFound("Não encontrado.");
            return Ok(readDto);
        }

        [HttpGet("{id}/videos")]
        [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
        public async Task<IActionResult> RecuperaVideoPorCategoria(int id)
        {
            List<ReadVideoDto> videos = await _categoriaService.RecuperaVideoPorCategoria(id);
            if (videos == null) return NotFound();
            return Ok(videos);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AtualizaCategoria(int id, [FromBody] UpdateCategoriaDto categoriaDto)
        {
            Result resultado = await _categoriaService.AtualizaCategoria(id, categoriaDto);
            if (resultado.IsFailed) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeletaCategoria(int id)
        {
            Result resultado = await _categoriaService.DeletaCategoria(id);
            if(resultado.IsFailed) return NotFound();
            return Ok();
        }

    }
}
