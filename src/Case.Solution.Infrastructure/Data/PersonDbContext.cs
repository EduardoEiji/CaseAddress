using CaseSolution.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Case.Solution.Infrastructure.Data
{
    public class PersonDbContext : DbContext
	{
		public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }

		public DbSet<Person> People { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>().HasKey(p => p.Id);
			modelBuilder.Entity<PessoaFisica>().HasBaseType<Person>();
			modelBuilder.Entity<PessoaJuridica>().HasBaseType<Person>();

			modelBuilder.Entity<Person>()
				.Property<string>("Discriminator")
				.HasColumnName("PersonType");
		}
	}
}
