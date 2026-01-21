using CaseSolution.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Case.Solution.Infrastructure.Data
{
    public class PersonDbContext : DbContext
	{
		public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }

		public DbSet<Person> People { get; set; } = null!;
		public DbSet<Address> Addresses { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>().HasKey(p => p.Id);
			modelBuilder.Entity<PessoaFisica>().HasBaseType<Person>();
			modelBuilder.Entity<PessoaJuridica>().HasBaseType<Person>();
			modelBuilder.Entity<Person>()
	   .HasDiscriminator<PersonType>("PType")
	   .HasValue<PessoaFisica>(PersonType.Fisica)
	   .HasValue<PessoaJuridica>(PersonType.Juridica);

			// Relacionamento 1:1 entre Person e Address
			modelBuilder.Entity<Person>()
				.HasOne(p => p.Address)
				.WithOne(a => a.Person)
				.HasForeignKey<Address>(a => a.PeopleId)
				.OnDelete(DeleteBehavior.Cascade);

			// Opcional: garantir que PeopleId seja único em Address
			modelBuilder.Entity<Address>()
				.HasIndex(a => a.PeopleId)
				.IsUnique();




		}
	}
}
