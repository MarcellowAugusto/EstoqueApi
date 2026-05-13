using EstoqueApi.Entities;
using EstoqueApi.Enum;

namespace EstoqueApi.DTOs
{
    public class EstoqueReadDto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public bool Disponivel { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<MovimentacaoEstoque> Movimentacoes { get; set; }
    }
}
