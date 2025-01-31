
namespace Services.Models
{
    public class FreelancerDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsArchived { get; set; } = false;

        public List<string> Skillsets { get; set; } = new();
        public List<string> Hobbies { get; set; } = new();
    }
}
