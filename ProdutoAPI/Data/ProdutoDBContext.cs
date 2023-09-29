using Microsoft.EntityFrameworkCore;
using ProdutoAPI.Data.Map;
using ProdutoAPI.Models;

namespace ProdutoAPI.Data
{
    public class ProdutoDBContext : DbContext
    {
        public ProdutoDBContext(DbContextOptions<ProdutoDBContext> options)
            : base(options)
        { 
        }

        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
