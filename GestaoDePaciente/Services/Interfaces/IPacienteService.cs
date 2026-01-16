using GestaoDePaciente.DTOs.Paciente;

namespace GestaoDePaciente.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<PacienteResponseDto?> CreateAsync(CreatePacienteDto dto);
        Task<PacienteResponseDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, CreatePacienteDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
