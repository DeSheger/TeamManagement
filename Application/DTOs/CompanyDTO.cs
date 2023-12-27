namespace Application.DTOs
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public UserDto Leader { get; set; } = null!;
        public ICollection<UserDto>? Members { get; set; } = new List<UserDto>();
    }
}