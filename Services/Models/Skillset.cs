using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Services.Models
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
