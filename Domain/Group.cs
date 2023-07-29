using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Group
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CompanyId { get; set; }
        public Guid LeaderId { get; set; }
        [NotMapped]
        public List<Guid> Members { get; set; }
    }
}