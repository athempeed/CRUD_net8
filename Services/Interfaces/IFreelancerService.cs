using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Models;

namespace Services.Interfaces
{
    public interface IFreelancerService
    {
        public Task<FreelancerDTO> CreateFreelancerAsync(FreelancerDTO freelancer);

        public Task<List<Freelancer>> GetFreelancersAsync();
         
        public Task<FreelancerDTO> GetFreelancerByIdAsync(int id);
          
        public Task<FreelancerDTO> UpdateFreelancerAsync(int id, FreelancerDTO freelancer);
         
        public Task DeleteFreelancerAsync(int id);
        
    }
}
