using Case.Solution.Application.DTOs;

namespace Case.Solution.Application.Interfaces
{
    public interface IViaCep
    {
		Task<AddressDto?> GetAddressByCepAsync(string cep);
	}
}
