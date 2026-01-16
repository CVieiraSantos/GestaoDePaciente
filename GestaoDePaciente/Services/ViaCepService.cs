using GestaoDePaciente.DTOs.Endereco;
using GestaoDePaciente.Services.Interfaces;

namespace GestaoDePaciente.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _http;

        public ViaCepService(HttpClient http)
        {
            _http = http;
        }

        public async Task<EnderecoViaCepDto?> GetByCepAsync(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep)) return null;
            var normalized = cep.Replace("-", "").Trim();
            var url = $"https://viacep.com.br/ws/{normalized}/json/";
            try
            {
                var dto = await _http.GetFromJsonAsync<EnderecoViaCepDto>(url);
                
                if (dto == null) 
                    return null;

                if (dto.Erro) return null;
                return dto;
            }
            catch
            {
                return null;
            }
        }
    }
}
