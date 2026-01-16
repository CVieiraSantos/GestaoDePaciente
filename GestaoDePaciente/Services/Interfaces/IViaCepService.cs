using GestaoDePaciente.DTOs.Endereco;
using System;

namespace GestaoDePaciente.Services.Interfaces
{
    public interface IViaCepService
    {
        Task<EnderecoViaCepDto?> GetByCepAsync(string cep);
    }
}