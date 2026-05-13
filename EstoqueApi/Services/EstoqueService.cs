using EstoqueApi.Data;
using EstoqueApi.DTOs;
using EstoqueApi.Entities;
using EstoqueApi.Enum;
using EstoqueApi.Mapper;
using Microsoft.EntityFrameworkCore;

namespace EstoqueApi.Services
{
    public class EstoqueService
    {
        private readonly AppDbContext _context;
        public EstoqueService(AppDbContext context) => _context = context;

        public async Task<List<EstoqueReadDto>> GetAll()
        {
            return await _context.Estoques
                .Select(e => new EstoqueReadDto
                {
                    Id = e.Id,
                    NomeProduto = e.NomeProduto,
                    Quantidade = e.Quantidade,
                    Disponivel = e.Disponivel,
                    DataCadastro = e.DataCadastro
                }).ToListAsync();
        }

        public async Task<EstoqueReadDto?> GetById(int id)
        {
            var estoque = await _context.Estoques.FindAsync(id);
            if (estoque == null) return null;

            return estoque.ToDTO();
        }
        
        public async Task<EstoqueReadDto> Create(EstoqueCreateDto createDto) 
        {
            var estoque = createDto.ToEntity();

            if (estoque.Quantidade < 0)
                throw new ArgumentException("Quantidade não pode ser negativa.");

            estoque.Disponivel = estoque.Quantidade > 0;

            var movimentacao = new MovimentacaoEstoque
            {
                Estoque = estoque,
                Tipo = TipoMovimentacao.Entrada,
                DataMovimentacao = DateTime.Now
            };
            await _context.Movimentacoes.AddAsync(movimentacao);

            await _context.SaveChangesAsync();
            return estoque.ToDTO();
        }

        public async Task<EstoqueReadDto?> Update(int id, EstoqueUpdateDto updateDto)
        {
            var estoque = await _context.Estoques.FindAsync(id);
            if (estoque == null) return null;

            if (updateDto.Quantidade < 0)
                throw new ArgumentException("Quantidade não pode ser negativa.");

            estoque.NomeProduto = updateDto.NomeProduto ?? estoque.NomeProduto;
            estoque.Quantidade = updateDto.Quantidade ?? estoque.Quantidade;

            estoque.Disponivel = estoque.Quantidade > 0;

            var movimentacao = new MovimentacaoEstoque
            {
                Estoque = estoque,
                Tipo = TipoMovimentacao.Entrada,
                DataMovimentacao = DateTime.Now
            };

            await _context.SaveChangesAsync();
            return estoque.ToDTO();
        }

        public async Task<bool> Delete(int id)
        {
            var estoque = await _context.Estoques.FindAsync(id);
            if (estoque == null) return false;
            _context.Estoques.Remove(estoque);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}