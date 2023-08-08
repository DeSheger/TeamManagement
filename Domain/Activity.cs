using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Activity
    {
        [Key]
        public int Id { get; set; } 
        public string Title { get; set; } = null!;
        public DateTime DateStart { get; set; } = DateTime.Now!;
        public DateTime? DateEnd { get; set;} = null!;
        public string? Description {get; set; } = null!;
        public User Author { get; set; } = null!;
        public Company Company { get; set; } = null!;
        public Group? Group { get; set; } = null!;
        public ICollection<User>? Members { get; set; } = new List<User>();
    }
}