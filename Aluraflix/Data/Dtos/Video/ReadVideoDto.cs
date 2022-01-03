using Aluraflix.Models;
using System.ComponentModel.DataAnnotations;

namespace Aluraflix.Data.Dtos
{
    public class ReadVideoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Url { get; set; }
        public Categoria Categoria { get; set; }
    }
}
