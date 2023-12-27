using Domain;

namespace Application.DTOs
{
    public class ActivityDto
    {
        public int Id { get; init; } 
        public string Title { get; init; } = null!;
        public DateTime DateStart { get; init; } = DateTime.Now!;
        public DateTime? DateEnd { get; init;} = null!;
        public string Description {get; init; } = null!;
        public UserDto Author { get; init; } = null!;
        public CompanyDto Company { get; init; } = null!;
        public GroupDto Group { get; init; } = null!;
        public ICollection<UserDto> Members { get; init; } = new List<UserDto>();
    }
}