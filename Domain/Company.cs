using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class Company
    {
        [Key]
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public User Leader { get; set; } = null!;
        public ICollection<User>? Members { get; set; } = new List<User>();
    }
}