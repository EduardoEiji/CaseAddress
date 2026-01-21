

namespace CaseSolution.Core.Entities
{
    public class PessoaFisica : Person
    {
		public DateTime BirthDate { get; private set; }

		public PessoaFisica(string name, string cpf, DateTime birthDate,Address address)
			: base(name, cpf, PersonType.Fisica ,address)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Nome não pode ser vazio.", nameof(name));
			if (birthDate > DateTime.Today)
				throw new ArgumentException("Data de nascimento inválida.", nameof(birthDate));
			// Adicione validação de CPF aqui
			BirthDate = birthDate;
		}

		public PessoaFisica()
		{ }
	}
}

