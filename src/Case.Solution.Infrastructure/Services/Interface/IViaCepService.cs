using Case.Solution.Application.DTOs;

namespace Case.Solution.Infrastructure.Services.Interface
{
    public interface IViaCepService
    {
		Task<AddressDto?> GetAddressByCepAsync(string cep);
	}
}
