using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surrname { get; set; }
        public ICollection<Activity>? ActivitiesAuthor {get; set;}
        public ICollection<Activity>? ActivitiesToDo {get; set;}
        public ICollection<Group>? GroupsLeader {get; set;}
        public ICollection<Group>? GroupsMember {get; set;}
        public ICollection<Company>? CompaniesLeader {get; set;}
        public ICollection<Company>? CompaniesMember {get; set;}
    }
}