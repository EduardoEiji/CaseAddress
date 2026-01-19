using Case.Solution.Application.DTOs;
using Case.Solution.Infrastructure.Services.Interface;

namespace Case.Solution.Infrastructure.Services
{
	public class ViaCepService: IViaCepService
	{
		private readonly HttpClient _httpClient;
		public ViaCepService(HttpClient httpClient) => _httpClient = httpClient;

		public async Task<AddressDto?> GetAddressByCepAsync(string cep)
		{
			var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
			if (!response.IsSuccessStatusCode) return null;
			var json = await response.Content.ReadAsStringAsync();
			// Map JSON to AddressDto (use System.Text.Json or Newtonsoft.Json)
			// ...
			return null;
		}
	}
}
