using Application.DTOs;
using System.Net.Http.Json;

namespace Infrastructure.Services
{
    public class AdviceSlapClient
    {
        private readonly HttpClient _httpClient;

        public AdviceSlapClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AdviceSlipResponse> GetRandomAdviceAsync()
        {
            var response = await _httpClient.GetAsync("advice");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<AdviceSlipResponse>()
                ?? throw new InvalidOperationException("Resposta inválida da API.");
        }
    }
}
