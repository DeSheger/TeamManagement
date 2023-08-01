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
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set;}
        public string? Description {get; set; }
        public User Author { get; set; }
        public Company Company { get; set; }
        public Group? Group { get; set; }
        public ICollection<User>? Members { get; set; }
    }
}