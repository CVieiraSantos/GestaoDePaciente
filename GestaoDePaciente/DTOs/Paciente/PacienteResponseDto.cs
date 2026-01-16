using GestaoDePaciente.Domain.Enums;
using GestaoDePaciente.DTOs.Endereco;

namespace GestaoDePaciente.DTOs.Paciente
{
    public class PacienteResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public ESexo Sexo { get; set; }

        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public EnderecoResponseDto Endereco { get; set; } = null!;
    }
}
