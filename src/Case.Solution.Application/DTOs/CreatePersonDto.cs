namespace Case.Solution.Application.DTOs
{
	public class CreatePersonDto
	{
		public string Name { get; set; } = string.Empty;
		public string Document { get; set; } = string.Empty;
		public string Type { get; set; } = "Fisica";
		public DateTime? BirthDate { get; set; }
		public CreateAddressDto Address { get; set; }
	}
}
