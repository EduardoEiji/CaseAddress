using System.ComponentModel.DataAnnotations;

namespace CaseSolution.Core.Entities
{
	public enum PersonType { Fisica = 0, Juridica = 1 }
	public abstract class Person
    {

		//usar private ou protected ???
		[Key]
		public Guid Id { get; private set; } = Guid.NewGuid();
		public string Name { get; private set; } = string.Empty;
		public string Document { get; private set; } = string.Empty; // CPF or CNPJ
		public PersonType PType { get; private set; }
     	public Address Address { get; private set; }


		protected Person() { }

		protected Person(string name, string document, PersonType type,Address address)
		{
			Name = name;
			Document = document;
			PType = type;
			Address = address;
		}

		public void UpdateName(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");
			Name = name;
		}

		public void UpdateDocument(string doc)
		{
			if (string.IsNullOrWhiteSpace(doc)) throw new ArgumentException("Document required");
			Document = doc;
		}
	}
}
