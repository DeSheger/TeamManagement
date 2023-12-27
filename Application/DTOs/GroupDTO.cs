namespace Application.DTOs
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CompanyId { get; set; }
        public UserDto Leader { get; set; } = null!;
        public ICollection<UserDto> Members { get; set; }  = new List<UserDto>();
    }
}