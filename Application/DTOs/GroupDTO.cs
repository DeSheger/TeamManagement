namespace Application.DTOs
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CompanyId { get; set; }
        public UserDTO Leader { get; set; } = null!;
        public ICollection<UserDTO> Members { get; set; }  = new List<UserDTO>();
    }
}