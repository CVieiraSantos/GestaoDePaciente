using GestaoDePaciente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDePaciente.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Cep)
                   .HasColumnName("Cep")
                   .HasMaxLength(9)
                   .IsUnicode(false)
                   .IsRequired();

            builder.Property(e => e.Logradouro)
                   .HasMaxLength(200)
                   .IsRequired(false);

            builder.Property(e => e.Numero)
                   .HasMaxLength(20)
                   .IsRequired(false);

            builder.Property(e => e.Complemento)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(e => e.Bairro)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(e => e.Localidade)
                   .HasColumnName("Localidade")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(e => e.Uf)
                   .HasColumnName("Uf")
                   .HasMaxLength(2)
                   .IsUnicode(false)
                   .IsRequired(false);

            builder.Property(e => e.Estado)
                   .HasColumnName("Estado")
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.HasIndex(e => e.PacienteId).IsUnique();

            builder.HasOne(e => e.Paciente)
                   .WithOne(p => p.Endereco)
                   .HasForeignKey<Endereco>(e => e.PacienteId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}