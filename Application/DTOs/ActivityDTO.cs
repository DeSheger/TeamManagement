using Domain;

namespace Application.DTOs
{
    public class ActivityDto
    {
        public int Id { get; set; } 
        public string Title { get; set; } = null!;
        public DateTime DateStart { get; set; } = DateTime.Now!;
        public DateTime? DateEnd { get; set;} = null!;
        public string Description {get; set; } = null!;
        public UserDto Author { get; set; } = null!;
        public CompanyDto Company { get; set; } = null!;
        public GroupDto Group { get; set; } = null!;
        public ICollection<UserDto>? Members { get; set; } = new List<UserDto>();
    }
}