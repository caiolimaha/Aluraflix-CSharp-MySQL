using System.ComponentModel.DataAnnotations;

namespace Aluraflix.Data.Dtos.Categoria
{
    public class ReadCategoriaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Cor { get; set; }
    }
}
