using GestaoDePaciente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDePaciente.Data.Mappings
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(x => x.DataNascimento)
                   .IsRequired()
                   .HasColumnType("date");

            builder.Property(x => x.Sexo)
                   .IsRequired()
                   .HasConversion<int>();

            builder.Property(x => x.Telefone)
                   .HasMaxLength(15)
                   .IsUnicode(false);

            builder.Property(x => x.Email)
                   .HasMaxLength(150);
        }
    }
}