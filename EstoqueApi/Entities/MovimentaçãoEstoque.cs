using EstoqueApi.Enum;

namespace EstoqueApi.Entities
{
    public class MovimentacaoEstoque
    {
        public int Id { get; set; }
        public int EstoqueId { get; set; }
        public Estoque Estoque { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public DateTime DataMovimentacao { get; set; } = DateTime.Now;
    }
}
