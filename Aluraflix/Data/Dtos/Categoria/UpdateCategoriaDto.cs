using System.ComponentModel.DataAnnotations;

namespace Aluraflix.Data.Dtos
{
    public class UpdateCategoriaDto
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Cor { get; set; }
    }
}
