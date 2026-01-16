using GestaoDePaciente.Domain.Entities;
using GestaoDePaciente.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoDePaciente.Repository
{
    public class PacienteRepository : IPacienteRepository

    {
        private readonly AppDbContext _context;

        public PacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente?> ObterPorIdAsync(int id)
            => await _context.Pacientes
                .Include(p => p.Endereco)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task AdicionarAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Paciente paciente)
        {
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
        }
    }
}
