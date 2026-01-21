using Case.Solution.Application.DTOs;
using Case.Solution.Application.Interfaces;
using System.Text.Json;


namespace Case.Solution.Infrastructure.Services
{
	public class ViaCepService: IViaCep
	{
		private readonly HttpClient _httpClient;
		public ViaCepService(HttpClient httpClient) => _httpClient = httpClient;

		public async Task<AddressDto?> GetAddressByCepAsync(string cep)
		{
			var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
			if (!response.IsSuccessStatusCode) return null;
			var json = await response.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			return JsonSerializer.Deserialize<AddressDto>(json, options);

		}
	}
}
