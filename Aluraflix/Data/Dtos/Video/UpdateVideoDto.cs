using System.ComponentModel.DataAnnotations;

namespace Aluraflix.Data.Dtos
{
    public class UpdateVideoDto
    {
        [Required(ErrorMessage = "O título é obrigatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "A descrição é obrigatoria")]
        public string Descricao { get; set; }
        [Required]
        public string Url { get; set; }
        public int CategoriaId { get; set; }
    }
}
