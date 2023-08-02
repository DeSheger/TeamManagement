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
        [JsonIgnore]
        public ICollection<Activity>? ActivitiesAuthor {get; set;}
        [JsonIgnore]
        public ICollection<Activity>? ActivitiesToDo {get; set;}
        [JsonIgnore]
        public ICollection<Group>? GroupsLeader {get; set;}
        [JsonIgnore]
        public ICollection<Group>? GroupsMember {get; set;}
        [JsonIgnore]
        public ICollection<Company>? CompaniesLeader {get; set;}
        [JsonIgnore]
        public ICollection<Company>? CompaniesMember {get; set;}
    }
}