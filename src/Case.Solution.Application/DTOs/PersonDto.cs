namespace Case.Solution.Application.DTOs
{
    public class PersonDto
    {
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Document { get; set; } = string.Empty;
		public string Type { get; set; } = string.Empty;
		public DateTime? BirthDate { get; set; }
	}
}
