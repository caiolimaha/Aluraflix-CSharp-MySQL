using System.ComponentModel.DataAnnotations;

namespace Aluraflix.Data.Dtos.Video
{
    public class UpdateVideoDto
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
