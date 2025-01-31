using Freelance.Models;
using Freelance.Models.DbEntities;
using Freelance.UOW;
using Microsoft.EntityFrameworkCore;

namespace Freelance.Services
{
    public class FreelancerService : IFreelancerService
    {
        private readonly IUnitOfWork _uow;
        public FreelancerService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }

        public async Task<List<FreelancerDTO>> GetAllFreelancersWithDetailsAsync(bool isarchived)
        {
            var freelancers = await _uow.FreelanceRepository.GetAllAsync(f => f.Skillsets, f => f.Hobbies);
            return freelancers.Select(x=> new FreelancerDTO
            {
                Email = x.Email,
                Id = x.Id,
                IsArchived = x.IsArchived,
                PhoneNumber = x.PhoneNumber,
                Username = x.Username,
                Hobbies = x.Hobbies.Select(h => h.Name).ToList(),
                Skillsets = x.Skillsets.Select(s => s.Name).ToList()
            }).ToList();
        }

        public async Task<List<Freelancer>> GetAllFreelancers(bool isarchived)
        {
            var dbFreelancers = await _uow.FreelanceRepository.GetAllAsync();
            var freelancers = dbFreelancers.Where(x=>x.IsArchived == isarchived).Select(f => new Freelancer
            {
                Id = f.Id,
                Username = f.Username,
                Email = f.Email,   
                IsArchived = f.IsArchived,
                PhoneNumber = f.PhoneNumber
            });
            return freelancers.ToList();
        }

        public async Task<FreelancerDTO> GetFreelancerByID(int ID)
        {
            var dbFreelancer = await _uow.FreelanceRepository.GetByID(ID, f => f.Skillsets, f => f.Hobbies);
            if (dbFreelancer == null) return null;
            var freelancer = new FreelancerDTO
            {
                Id = dbFreelancer.Id,
                Username = dbFreelancer.Username,
                Email = dbFreelancer.Email,
                PhoneNumber = dbFreelancer.PhoneNumber,
                Hobbies = dbFreelancer.Hobbies.Select(h => h.Name).ToList(),
                Skillsets = dbFreelancer.Skillsets.Select(s => s.Name).ToList()
            };
            return freelancer;
        }

        public async Task<Freelancer> GetByID(int ID)
        {
            var dbFreelancer = await _uow.FreelanceRepository.GetByID(ID, f => f.Skillsets, f => f.Hobbies);
            if (dbFreelancer == null) return null;          
            return dbFreelancer;
        }

        public async Task AddFreelancerAsync(FreelancerDTO freelancer)
        {
            var entity = await _uow.FreelanceRepository.Insert(new Freelancer
            {
                Email = freelancer.Email,
                Username = freelancer.Username,
                IsArchived = false,
                PhoneNumber = freelancer.PhoneNumber
            });
            _uow.SaveChanges();
            freelancer.Skillsets.ForEach(x => {
                _uow.SkillsetRepository.Save(new Skillset
                {
                    Name = x,
                    FreelancerId = entity.Id
                });
            });

            freelancer.Hobbies.ForEach(x => {
                _uow.HobbyRepository.Save(new Hobby
                {
                    Name = x,
                    FreelancerId = entity.Id
                });
            });                  
            _uow.SaveChanges();

        }

        public async Task UpdateFreelancerAsync(int ID, FreelancerDTO freelancer)
        {
            await _uow.FreelanceRepository.UpdateFreelancerAsync(ID, freelancer);
            _uow.SaveChanges();
        }

        public async Task DeleteFreelancerAsync(int id)
        {
            var freelancer = await GetByID(id);
            if (freelancer == null) return;
            
            _uow.FreelanceRepository.Delete(freelancer);
            _uow.SaveChanges();            
        }

        public async Task<List<Freelancer>> SearchFreelancersAsync(string query)
        {
            var freelancers = await _uow.FreelanceRepository.GetBy(x => x.Username.Contains(query) || x.Email.Contains(query));
            return freelancers;
        }           

        public async Task ArchiveFreelancerAsync(int id)
        {
            var freelancer = await GetByID(id);
            if (freelancer == null) return;
            freelancer.IsArchived = true;
            _uow.FreelanceRepository.Update(freelancer);
            _uow.SaveChanges();
        }

        public async Task UnarchiveFreelancerAsync(int id)
        {
            var freelancer = await GetByID(id);
            if (freelancer == null) return;
            freelancer.IsArchived = false;
            _uow.FreelanceRepository.Update(freelancer);
            _uow.SaveChanges();
        }
    }
}
