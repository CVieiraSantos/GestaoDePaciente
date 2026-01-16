using GestaoDePaciente.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace GestaoDePaciente.DTOs.Paciente
{
    public class CreatePacienteDto
    {
        [Required(ErrorMessage ="O nome do paciente é obrigatório")]
        [MinLength(3)]
        [MaxLength(150)]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage ="A data do paciente é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage ="O sexo do paciente é obrigatório")]
        [EnumDataType(typeof(ESexo))]
        public ESexo Sexo { get; set; }

        [RegularExpression(
            @"^\(\d{2}\)\s\d{5}-\d{4}$",
            ErrorMessage = "Telefone deve estar no formato (99) 99999-9999")]
        public string? Telefone { get; set; }

        [RegularExpression(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            ErrorMessage = "E-mail inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O CEP do paciente é obrigatório")]
        [RegularExpression(
            @"^\d{5}-\d{3}$",
            ErrorMessage = "CEP deve estar no formato 99999-999")]
        public string Cep { get; set; } = null!;

        [MaxLength(5)]
        public string? Numero { get; set; }

        [MaxLength(8)]
        public string? Complemento { get; set; }
    }
}
