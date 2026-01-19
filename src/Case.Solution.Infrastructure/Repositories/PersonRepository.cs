using Case.Solution.Infrastructure.Data;
using CaseSolution.Core.Entities;
using CaseSolution.Core.Ports;
using Microsoft.EntityFrameworkCore;

namespace Case.Solution.Infrastructure.Repositories
{
	public class PersonRepository : IPersonRepository
	{
		private readonly PersonDbContext _db;

		public PersonRepository(PersonDbContext db)
		{
			_db = db;
		}

		public async Task<Person> CreateAsync(Person person)
		{
			_db.People.Add(person);
			await _db.SaveChangesAsync();
			return person;
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var e = await _db.People.FindAsync(id);
			if (e == null) return false;
			_db.People.Remove(e);
			await _db.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<Person>> GetAllAsync()
		{
			return await _db.People.AsNoTracking().ToListAsync();
		}

		public async Task<Person?> GetByIdAsync(Guid id)
		{
			return await _db.People.FindAsync(id);
		}

		public async Task<Person?> UpdateAsync(Person person)
		{
			var p = await _db.People.FindAsync(person.Id);
			if (p == null) return null;

			_db.Entry(p).CurrentValues.SetValues(person);
			await _db.SaveChangesAsync();
			return person;
		}
	}
}
