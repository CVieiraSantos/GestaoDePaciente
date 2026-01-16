using GestaoDePaciente.Domain.Entities;
using GestaoDePaciente.DTOs.Endereco;
using GestaoDePaciente.DTOs.Paciente;
using GestaoDePaciente.Repository.Interfaces;
using GestaoDePaciente.Services.Interfaces;

namespace GestaoDePaciente.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repo;
        private readonly IViaCepService _viaCep;

        public PacienteService(IPacienteRepository repo, IViaCepService viaCep)
        {
            _repo = repo;
            _viaCep = viaCep;
        }

        public async Task<PacienteResponseDto?> CreateAsync(CreatePacienteDto dto)
        {
            var paciente = new Paciente
            {
                Nome = dto.Nome,
                DataNascimento = dto.DataNascimento,
                Sexo = (ESexo)dto.Sexo,
                Telefone = dto.Telefone,
                Email = dto.Email,
                Endereco = new Endereco
                {
                    Cep = dto.Cep,
                    Numero = dto.Numero,
                    Complemento = dto.Complemento
                }
            };

            var viaCep = await _viaCep.GetByCepAsync(dto.Cep);
            if (viaCep != null && !(viaCep.Erro))
            {
                paciente.Endereco.Logradouro ??= viaCep.logradouro;
                paciente.Endereco.Bairro ??= viaCep.bairro;
                paciente.Endereco.Localidade ??= viaCep.localidade;
                paciente.Endereco.Uf ??= viaCep.uf;
                paciente.Endereco.Estado ??= viaCep.estado;
            }

            await _repo.AdicionarAsync(paciente);

            return new PacienteResponseDto
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                DataNascimento = paciente.DataNascimento,
                Sexo = (Domain.Enums.ESexo)paciente.Sexo,
                Telefone = paciente.Telefone,
                Email = paciente.Email,
                Endereco = new EnderecoResponseDto
                {
                    Cep = paciente.Endereco.Cep,
                    Logradouro = paciente.Endereco.Logradouro,
                    Numero = paciente.Endereco.Numero,
                    Complemento = paciente.Endereco.Complemento,
                    Bairro = paciente.Endereco.Bairro,
                    Cidade = paciente.Endereco.Localidade,
                    Uf = paciente.Endereco.Uf,
                    Estado = paciente.Endereco.Estado
                }
            };
        }

        public async Task<PacienteResponseDto?> GetByIdAsync(int id)
        {
            var paciente = await _repo.ObterPorIdAsync(id);
            if (paciente == null) return null;

            return new PacienteResponseDto
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                DataNascimento = paciente.DataNascimento,
                Sexo = (Domain.Enums.ESexo)paciente.Sexo,
                Telefone = paciente.Telefone,
                Email = paciente.Email,
                Endereco = new EnderecoResponseDto
                {
                    Cep = paciente.Endereco.Cep,
                    Logradouro = paciente.Endereco.Logradouro,
                    Numero = paciente.Endereco.Numero,
                    Complemento = paciente.Endereco.Complemento,
                    Bairro = paciente.Endereco.Bairro,
                    Cidade = paciente.Endereco.Localidade,
                    Uf = paciente.Endereco.Uf,
                    Estado = paciente.Endereco.Estado
                }
            };
        }

        public async Task<bool> UpdateAsync(int id, CreatePacienteDto dto)
        {
            var paciente = await _repo.ObterPorIdAsync(id);
            if (paciente == null) return false;

            paciente.Nome = dto.Nome;
            paciente.DataNascimento = dto.DataNascimento;
            paciente.Sexo = (ESexo)dto.Sexo;
            paciente.Telefone = dto.Telefone;
            paciente.Email = dto.Email;

            paciente.Endereco.Cep = dto.Cep;
            paciente.Endereco.Numero = dto.Numero;
            paciente.Endereco.Complemento = dto.Complemento;

            var viaCep = await _viaCep.GetByCepAsync(dto.Cep);
            if (viaCep != null && !(viaCep.Erro))
            {
                paciente.Endereco.Logradouro = viaCep.logradouro;
                paciente.Endereco.Bairro = viaCep.bairro;
                paciente.Endereco.Localidade = viaCep.localidade;
                paciente.Endereco.Uf = viaCep.uf;
                paciente.Endereco.Estado = viaCep.estado;
            }

            await _repo.AtualizarAsync(paciente);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var paciente = await _repo.ObterPorIdAsync(id);
            if (paciente == null) return false;
            await _repo.RemoverAsync(paciente);
            return true;
        }
    }
}

