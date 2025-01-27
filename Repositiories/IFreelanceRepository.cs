using Freelance.Models;
using Freelance.Models.DbEntities;

namespace Freelance.Repositiories
{
    public interface IFreelanceRepository : IRepositoryBase<Freelancer>
    {
        Task UpdateFreelancerAsync(int id, FreelancerDTO freelancerDto);
    }
}
