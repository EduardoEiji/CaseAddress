namespace CaseSolution.Core.Entities
{
    public class PessoaJuridica : Person
    {
		public string CompanyName { get; private set; } = string.Empty;

		public PessoaJuridica(string tradingName, string cnpj,Address address)
			: base(tradingName, cnpj, PersonType.Juridica,address)
		{
			if (string.IsNullOrWhiteSpace(tradingName))
				throw new ArgumentException("Nome da pessoa juridica não pode ser vazio.", nameof(tradingName));
			CompanyName = tradingName;
		}

		public PessoaJuridica()
		{ }
	}
}
