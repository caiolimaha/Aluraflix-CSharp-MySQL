using Aluraflix.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aluraflix.Data.Dtos
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
        public List<Video> Videos { get; set; }
    }
}
