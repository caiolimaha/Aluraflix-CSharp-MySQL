using System.ComponentModel.DataAnnotations;

namespace Aluraflix.Models
{
    public class Video
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
    }
}
