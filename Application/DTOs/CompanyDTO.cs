namespace Application.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public UserDTO Leader { get; set; } = null!;
        public ICollection<UserDTO> Members { get; set; } = new List<UserDTO>();
    }
}