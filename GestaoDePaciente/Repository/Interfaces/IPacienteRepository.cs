using GestaoDePaciente.Domain.Entities;

namespace GestaoDePaciente.Repository.Interfaces
{
    public interface IPacienteRepository
    {
        Task<Paciente?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Paciente paciente);
        Task AtualizarAsync(Paciente paciente);
        Task RemoverAsync(Paciente paciente);
    }
}