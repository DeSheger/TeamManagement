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
        public string Name { get; set; } = null!;
        public string Surrname { get; set; } = null!;
        [JsonIgnore]
        public ICollection<Activity>? ActivitiesAuthor {get; set;} = new List<Activity>();
        [JsonIgnore]
        public ICollection<Activity>? ActivitiesToDo {get; set;} = new List<Activity>();
        [JsonIgnore]
        public ICollection<Group>? GroupsLeader {get; set;} = new List<Group>();
        [JsonIgnore] 
        public ICollection<Group>? GroupsMember {get; set;} = new List<Group>();
        [JsonIgnore]
        public ICollection<Company>? CompaniesLeader {get; set;} = new List<Company>();
        [JsonIgnore]
        public ICollection<Company>? CompaniesMember {get; set;} = new List<Company>();
    }
}