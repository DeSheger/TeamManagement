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
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description {get; set; }
        public Guid AuthorId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid GroupId { get; set; }
        [NotMapped]
        public List<Guid> MembersId { get; set; }
    }
}