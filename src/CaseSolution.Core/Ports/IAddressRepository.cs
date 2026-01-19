using CaseSolution.Core.Entities;

namespace CaseSolution.Core.Ports
{
    public interface IAddressRepository
    {
		Task<IEnumerable<Address>> GetAllAsync();
		Task<Address?> GetByIdAsync(Guid id);
		Task<Address> CreateAsync(Address person);
		Task<Address?> UpdateAsync(Address person);
		Task<bool> DeleteAsync(Guid id);
	}
}
