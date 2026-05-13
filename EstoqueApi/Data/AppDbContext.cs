using Microsoft.EntityFrameworkCore;

namespace EstoqueApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Entities.Estoque> Estoques { get; set; }
        public DbSet<Entities.MovimentacaoEstoque> Movimentacoes { get; set; } 
    }
}
