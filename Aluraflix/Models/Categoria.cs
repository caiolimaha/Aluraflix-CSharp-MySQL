using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aluraflix.Models
{
    public class Categoria
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
