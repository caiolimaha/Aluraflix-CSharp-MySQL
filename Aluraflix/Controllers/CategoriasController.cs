using Aluraflix.Data.Dtos.Categoria;
using Aluraflix.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
        public IActionResult RecuperaCategoriaPorId(int id)
        {
            ReadCategoriaDto readDto = _categoriaService.RecuperaCategoriaPorId(id);
            if(readDto == null) return NotFound("Não encontrado.");
            return Ok(readDto);
        }
    }
}
