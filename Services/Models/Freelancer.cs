using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Freelancer
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsArchived { get; set; } = false;

     
        public List<Skillset> Skillsets { get; set; } = new();
        public List<Hobby> Hobbies { get; set; } = new();
    }
}