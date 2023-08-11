using Domain;

namespace Application.DTOs
{
    public class ActivityDTO
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set;}
        public string Description {get; set; }
        public UserDTO Author { get; set; }
        public int CompanyId { get; set; }
        public int GroupId { get; set; }
        public ICollection<UserDTO> Members { get; set; } = new List<UserDTO>();
    }
}