using GestaoDePaciente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GestaoDePaciente.Domain.Entities
{
    public class Endereco : Base
    {
        public string Cep { get; set; } = string.Empty;
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }

        // ViaCEP: "localidade" => cidade
        public string? Localidade { get; set; }

        // ViaCEP: "uf" => sigla da unidade federativa (ex: "SP")
        public string? Uf { get; set; }

        // ViaCEP também provê "estado" => nome completo do estado ("São Paulo")
        public string? Estado { get; set; }

        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
    }
}