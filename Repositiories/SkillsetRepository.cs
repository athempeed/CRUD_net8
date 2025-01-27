using Freelance.Models;
using Freelance.Models.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Freelance.Repositiories
{
    public class SkillsetRepository : RepositoryBase<Skillset,FreelancerDBContext>, ISkillsetRepository
    {
        public SkillsetRepository(FreelancerDBContext context) : base(context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
