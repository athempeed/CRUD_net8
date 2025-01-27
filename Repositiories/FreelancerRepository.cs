using Freelance.Models;
using Freelance.Models.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Freelance.Repositiories
{
    public class FreelancerRepository :RepositoryBase<Freelancer,FreelancerDBContext>, IFreelanceRepository
    {
        public FreelancerRepository(FreelancerDBContext context) : base(context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task UpdateFreelancerAsync(int id, FreelancerDTO freelancerDto)
        {
            // Fetch the freelancer including related skillsets and hobbies
            var freelancer = await dbSet
                .Include(f => f.Skillsets)
                .Include(f => f.Hobbies)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (freelancer != null)
            {
                
                // Update basic properties of freelancer
                freelancer.Username = freelancerDto.Username;
                freelancer.Email = freelancerDto.Email;
                freelancer.PhoneNumber = freelancerDto.PhoneNumber;

                // Update skillsets
                freelancer.Skillsets.Clear(); // Clear existing skillsets
                freelancer.Skillsets.AddRange(freelancerDto.Skillsets.Select(s => new Skillset { Name = s }).ToList());

                // Update hobbies
                freelancer.Hobbies.Clear(); // Clear existing hobbies
                freelancer.Hobbies.AddRange(freelancerDto.Hobbies.Select(h => new Hobby { Name = h }).ToList());
                Update(freelancer);
                //_context.SaveChanges();
            }
        }
    }
}
