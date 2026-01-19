using CaseSolution.Core.Entities;

namespace Case.Solution.Application.DTOs
{
    public class CreatePersonDto
    {
		public string Name { get; set; } = string.Empty;
		public string Document { get; set; } = string.Empty;
		public string Type { get; set; } = "Fisica"; 
		public DateTime? BirthDate { get; set; }
		public AddressDto Address { get; set; }
	}
}
