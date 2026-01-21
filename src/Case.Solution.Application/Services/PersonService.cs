using Case.Solution.Application.DTOs;
using CaseSolution.Core.Entities;
using CaseSolution.Core.Ports;

namespace Case.Solution.Application.Services
{
    public class PersonService
    {
		private readonly IPersonRepository _repo;

		public PersonService(IPersonRepository repo)
		{
			_repo = repo;
		}

		public async Task<IEnumerable<PersonDto>> GetAllAsync()
		{
			var people = await _repo.GetAllAsync();
			return people.Select(ToDto);
		}

		public async Task<PersonDto?> GetByIdAsync(Guid id)
		{
			var p = await _repo.GetByIdAsync(id);
			return p == null ? null : ToDto(p);
		}

		public async Task<PersonDto> CreateAsync(CreatePersonDto dto)
		{
			ValidateCreateDto(dto);


			var address = new Address(dto.Address.Cep , dto.Address.Logradouro , dto.Address.Complemento ,dto.Address.Unidade , dto.Address.Bairro , dto.Address.Localidade , dto.Address.Uf , dto.Address.Estado , dto.Address.Regiao , dto.Address.Ibge , dto.Address.Gia , dto.Address.Ddd , dto.Address.Siafi);

			Person person = dto.Type switch
			{
				"1" => new PessoaJuridica(dto.Name, dto.Document,address),
				_ => new PessoaFisica(dto.Name, dto.Document, dto.BirthDate ?? DateTime.MinValue,address)
			};

			var created = await _repo.CreateAsync(person);
			return ToDto(created);
		}

		public async Task<PersonDto?> UpdateAsync(Guid id, CreatePersonDto dto)
		{
			var existing = await _repo.GetByIdAsync(id);
			if (existing == null) return null;

			existing.UpdateName(dto.Name);
			existing.UpdateDocument(dto.Document);
			// specific fields not updated here for brevity

			var updated = await _repo.UpdateAsync(existing);
			return updated == null ? null : ToDto(updated);
		}

		public async Task<bool> DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

		private void ValidateCreateDto(CreatePersonDto dto)
		{
			if (string.IsNullOrWhiteSpace(dto.Name)) throw new ArgumentException("Name required");
			if (string.IsNullOrWhiteSpace(dto.Document)) throw new ArgumentException("Document required");

			if (dto.Type == "Individual")
			{
				// simple CPF length check; replace with robust validator if required
				var digits = new string(dto.Document.Where(char.IsDigit).ToArray());
				if (digits.Length != 11) throw new ArgumentException("CPF must have 11 digits");
			}
			else if (dto.Type == "Company")
			{
				var digits = new string(dto.Document.Where(char.IsDigit).ToArray());
				if (digits.Length != 14) throw new ArgumentException("CNPJ must have 14 digits");
			}
		}

		private PersonDto ToDto(Person p) => new PersonDto
		{
			Id = p.Id,
			Name = p.Name,
			Document = p.Document,
			Type = p.PType == PersonType.Juridica ? "Juridica" : "Fisica",
			BirthDate = (p is PessoaFisica pf) ? pf.BirthDate : null
		};
	}
}
