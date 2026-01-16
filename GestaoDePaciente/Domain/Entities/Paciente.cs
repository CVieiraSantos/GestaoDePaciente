using System;

namespace GestaoDePaciente.Domain.Entities
{
    public class Paciente : Base
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public ESexo Sexo { get; set; }

        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public Endereco Endereco { get; set; } = null!;
    }
}