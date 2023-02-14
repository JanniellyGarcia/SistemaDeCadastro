using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeCadastro.Models;

namespace SistemaDeCadastro.Map
{
    public class EmpregadoMap : IEntityTypeConfiguration<Empregado>
    {
        public void Configure(EntityTypeBuilder<Empregado> builder)
        {
            builder.HasKey(x => x.Matricula);
            builder.Property(x => x.Nome).IsRequired();
        }
    }
}
