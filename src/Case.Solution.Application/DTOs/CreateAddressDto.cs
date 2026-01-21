using System.Text.Json.Serialization;

namespace Case.Solution.Application.DTOs
{
    public class CreateAddressDto
    {
		public string Cep { get; set; } = string.Empty;
		[JsonIgnore]
		public string Logradouro { get; set; } = string.Empty;
		public string? Complemento { get; set; }
		[JsonIgnore]
		public string? Unidade { get; set; }
		[JsonIgnore]
		public string Bairro { get; set; } = string.Empty;
		[JsonIgnore]
		public string Localidade { get; set; } = string.Empty;
		[JsonIgnore]
		public string Uf { get; set; } = string.Empty;
		[JsonIgnore]
		public string Estado { get; set; } = string.Empty;
		[JsonIgnore]
		public string Regiao { get; set; } = string.Empty;
		[JsonIgnore]
		public string? Ibge { get; set; }
		[JsonIgnore]
		public string? Gia { get; set; }
		[JsonIgnore]
		public string? Ddd { get; set; }
		[JsonIgnore]
		public string? Siafi { get; set; }


	}
}
