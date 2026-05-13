using EstoqueApi.DTOs;
using EstoqueApi.Entities;
using System.Linq.Expressions;

namespace EstoqueApi.Mapper
{
    public static class EstoqueMapper
    {
        public static Estoque ToEntity(this EstoqueCreateDto dto)
        {
            return new Estoque
            {
                NomeProduto = dto.NomeProduto,
                Quantidade = dto.Quantidade,
                DataCadastro = DateTime.UtcNow
            };
        }

        public static void UpdateEntity(this EstoqueUpdateDto dto, Estoque estoque)
        {
            estoque.NomeProduto = dto.NomeProduto ?? estoque.NomeProduto;
            estoque.Quantidade = dto.Quantidade ?? estoque.Quantidade;
        }

        public static EstoqueReadDto ToDTO(this Estoque estoque)
        {
            return new EstoqueReadDto
            {
                Id = estoque.Id,
                NomeProduto = estoque.NomeProduto,
                Quantidade = estoque.Quantidade,
                Disponivel = estoque.Disponivel,
                DataCadastro = estoque.DataCadastro
            };
        }

        public static Expression<Func<Estoque, EstoqueReadDto>> ToDTOExpression =>
            e => new EstoqueReadDto
            {
                Id = e.Id,
                NomeProduto = e.NomeProduto,
                Quantidade = e.Quantidade,
                DataCadastro = e.DataCadastro
            };
    }
}