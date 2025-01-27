using Freelance.Models;
using Freelance.Models.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Freelance.Repositiories
{
    public class HobbyRepository : RepositoryBase<Hobby,FreelancerDBContext>, IHobbyRepository
    {
        public HobbyRepository(FreelancerDBContext context) : base(context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
