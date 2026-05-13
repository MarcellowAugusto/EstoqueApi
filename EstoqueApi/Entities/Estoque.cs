using System.ComponentModel.DataAnnotations;

namespace EstoqueApi.Entities
{
    public class Estoque
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string NomeProduto { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public bool Disponivel { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public List<MovimentacaoEstoque> Movimentacoes { get; set; }
    }
}
