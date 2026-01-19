namespace CaseSolution.Core.Entities
{
	public enum PersonType { Individual = 0, Company = 1 }
	public abstract class Person
    {
		public Guid Id { get; protected set; } = Guid.NewGuid();
		public string Name { get; protected set; } = string.Empty;
		public string Document { get; protected set; } = string.Empty; // CPF or CNPJ
		public PersonType Type { get; protected set; }
		public Address Address { get; protected set; }


		protected Person() { }

		protected Person(string name, string document, PersonType type,Address address)
		{
			Name = name;
			Document = document;
			Type = type;
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
