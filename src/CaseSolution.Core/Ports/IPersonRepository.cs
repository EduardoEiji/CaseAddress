using CaseSolution.Core.Entities;

namespace CaseSolution.Core.Ports
{
    public interface IPersonRepository
    {
		Task<IEnumerable<Person>> GetAllAsync();
		Task<Person?> GetByIdAsync(Guid id);
		Task<Person> CreateAsync(Person person);
		Task<Person?> UpdateAsync(Person person);
		Task<bool> DeleteAsync(Guid id);
	}
}
