using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

    }
}
