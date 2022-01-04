using Aluraflix.Data.Dtos;
using Aluraflix.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Aluraflix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {

        private CategoriaService _categoriaService;

        public CategoriasController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        public IActionResult AdicionaCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {
            ReadCategoriaDto readDto = _categoriaService.AdicionaCategoria(categoriaDto);
            return CreatedAtAction(nameof(RecuperaCategoriaPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaCategorias()
        {
            List<ReadCategoriaDto> categoriasDto = _categoriaService.RecuperaCategorias();
            if(categoriasDto == null) return NotFound();
            return Ok(categoriasDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCategoriaPorId(int id)
        {
            ReadCategoriaDto readDto = _categoriaService.RecuperaCategoriaPorId(id);
            if(readDto == null) return NotFound("Não encontrado.");
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCategoria(int id, [FromBody] CreateCategoriaDto categoriaDto)
        {
            Result resultado = _categoriaService.AtualizaCategoria(id, categoriaDto);
            if (resultado.IsFailed) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCategoria(int id)
        {
            Result resultado = _categoriaService.DeletaCategoria(id);
            if(resultado.IsFailed) return NotFound();
            return Ok();
        }

        [HttpGet("{id}/videos")]
        public IActionResult RecuperaVideoPorCategoria(int id)
        {
            List<ReadVideoDto> videos = _categoriaService.RecuperaVideoPorCategoria(id);
            if(videos == null) return NotFound();
            return Ok(videos);
        }
    }
}
