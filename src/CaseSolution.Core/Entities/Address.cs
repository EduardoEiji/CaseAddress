namespace CaseSolution.Core.Entities
{
    public class Address
    {
		public Guid Id { get; set; }
		public string Cep { get; set; } = string.Empty;
		public string Logradouro { get; set; } = string.Empty;
		public string? Complemento { get; set; }
		public string? Unidade { get; set; }
		public string Bairro { get; set; } = string.Empty;
		public string Localidade { get; set; } = string.Empty;
		public string Uf { get; set; } = string.Empty;
		public string Estado { get; set; } = string.Empty;
		public string Regiao { get; set; } = string.Empty;
		public string? Ibge { get; set; }
		public string? Gia { get; set; }
		public string? Ddd { get; set; }
		public string? Siafi { get; set; }



		public Address (string cep ,string logradouro , string complemento , string unidade , string bairro , string localidade , string uf , string estado , string regiao , string ibge  , string gia , string ddd , string siafi)
		{
			Cep = cep;
			Logradouro = logradouro;	
			Complemento = complemento;	
			Unidade = unidade;	
			Bairro = bairro;
			Localidade = localidade;
			Uf = uf;
			Estado = Estado;
			Regiao = Regiao;
			Ibge = ibge;
			Gia = gia;
			Ddd = ddd;
			Siafi = siafi;
		}
		public void UpdateCep(string cep)
		{
			if (string.IsNullOrWhiteSpace(cep)) throw new ArgumentException("Cep obrigatorio");
			Cep = cep;
		}

		public void UpdateLogradouro(string logradouro)
		{
			if (string.IsNullOrWhiteSpace(logradouro)) throw new ArgumentException("Logradouro obrigatorio");
			Logradouro = logradouro;
		}
	}
}
