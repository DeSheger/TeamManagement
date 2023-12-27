namespace Application.DTOs
{
    public class GroupDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public int CompanyId { get; init; }
        public UserDto Leader { get; init; } = null!;
        public ICollection<UserDto> Members { get; init; }  = new List<UserDto>();
    }
}