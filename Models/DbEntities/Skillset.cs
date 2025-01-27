using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Freelance.Models.DbEntities
{
    public class Skillset
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int FreelancerId { get; set; }

        [JsonIgnore]
        public Freelancer Freelancer { get; set; }
    }
}
