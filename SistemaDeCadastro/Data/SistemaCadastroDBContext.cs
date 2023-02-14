using Microsoft.EntityFrameworkCore;
using SistemaDeCadastro.Map;
using SistemaDeCadastro.Models;

namespace SistemaDeCadastro.Data
{
    public class SistemaCadastroDBContext : DbContext
    {
        public SistemaCadastroDBContext(DbContextOptions<SistemaCadastroDBContext> options)
            : base(options)
        {

        }

        public DbSet<Empregado> Empregados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpregadoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
