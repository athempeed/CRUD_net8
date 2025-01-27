using Freelance.Models;
using Freelance.Models.DbEntities;

namespace Freelance.Services
{
    public interface IFreelancerService
    {
        Task<List<FreelancerDTO>> GetAllFreelancersWithDetailsAsync(bool isarchived);
        Task<List<Freelancer>> GetAllFreelancers(bool isarchived);
        Task<FreelancerDTO> GetFreelancerByID(int ID);
        Task<Freelancer> GetByID(int ID);
        Task AddFreelancerAsync(FreelancerDTO freelancer);
        Task UpdateFreelancerAsync(int ID, FreelancerDTO freelancer);
        Task DeleteFreelancerAsync(int id);
        Task<List<Freelancer>> SearchFreelancersAsync(string query);
        Task ArchiveFreelancerAsync(int id);
        Task UnarchiveFreelancerAsync(int id);
    }
}
