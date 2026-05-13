using System.ComponentModel.DataAnnotations;

namespace EstoqueApi.DTOs
{
    public class EstoqueCreateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string NomeProduto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
    }
}
