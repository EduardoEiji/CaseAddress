using Case.Solution.Application.DTOs;
using CaseSolution.Core.Entities;
using CaseSolution.Core.Ports;

namespace Case.Solution.Application.Services
{
	public class AddressService
	{
		private readonly IAddressRepository _repo;

		public AddressService(IAddressRepository repo)
		{
			_repo = repo;
		}

		public async Task<IEnumerable<AddressDto>> GetAllAsync()
		{
			var people = await _repo.GetAllAsync();
			return people.Select(ToDto);
		}

		public async Task<AddressDto?> GetByIdAsync(Guid id)
		{
			var a = await _repo.GetByIdAsync(id);
			return a == null ? null : ToDto(a);
		}


		public async Task<AddressDto> CreateAsync(CreateAddressDto dto)
		{
			ValidateCreateDto(dto);
			Address address = new Address(dto.Cep , dto.Logradouro,dto.Complemento, dto.Unidade, dto.Bairro, dto.Localidade, dto.Uf, dto.Estado, dto.Regiao, dto.Ibge, dto.Gia, dto.Ddd, dto.Siafi);
			var created = await _repo.CreateAsync(address);
			return ToDto(created);
		}


		public async Task<AddressDto?> UpdateAsync(Guid id, CreateAddressDto dto)
		{
			var existing = await _repo.GetByIdAsync(id);
			if (existing == null) return null;

			existing.UpdateCep(dto.Cep);
			existing.UpdateLogradouro(dto.Logradouro);
			// specific fields not updated here for brevity

			var updated = await _repo.UpdateAsync(existing);
			return updated == null ? null : ToDto(updated);
		}

		public async Task<bool> DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

		private void ValidateCreateDto(CreateAddressDto dto)
		{
			if (string.IsNullOrWhiteSpace(dto.Logradouro)) throw new ArgumentException("Name required");
			if (string.IsNullOrWhiteSpace(dto.Cep)) throw new ArgumentException("Document required");

		}




		private AddressDto ToDto(Address a) => new AddressDto
		{

			Cep = a.Cep,
			Logradouro = a.Logradouro,
			Complemento = a.Complemento,
			Unidade = a.Unidade,
			Bairro = a.Bairro,
			Localidade = a.Localidade,
			Uf = a.Uf,
			Estado = a.Estado,
			Regiao = a.Regiao,
			Ibge = a.Ibge,
			Gia = a.Gia,
			Ddd = a.Ddd,
			Siafi = a.Siafi

		};





	}
}
