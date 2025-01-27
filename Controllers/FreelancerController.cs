using Freelance.Models;
using Freelance.Models.DbEntities;
using Freelance.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Freelance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {
        private readonly IFreelancerService _freelancerService;
        public FreelancerController(IFreelancerService freelancerService)
        {
            _freelancerService = freelancerService ?? throw new ArgumentNullException(nameof(freelancerService));
        }

        [HttpGet("/activeFreelancers")]
        public async Task<IActionResult> GetActiveFreelancers()
            => Ok(await _freelancerService.GetAllFreelancers(isarchived: false));

        [HttpGet("/activeFreelancersWithDetails")]
        public async Task<IActionResult> GetActiveFreelancersWithDetails()
           => Ok(await _freelancerService.GetAllFreelancersWithDetailsAsync(isarchived: false));

        [HttpGet("/allFreelancersWithDetails")]
        public async Task<IActionResult> GetallFreelancersWithDetails()
        {
            var active = await _freelancerService.GetAllFreelancersWithDetailsAsync(isarchived: false);
            var inActive = await _freelancerService.GetAllFreelancersWithDetailsAsync(isarchived: true);
            active.AddRange(inActive);
            return Ok(active);
        }

        [HttpGet("/allFreelancers")]
        public async Task<IActionResult> GetallFreelancers()
        {
            var active = await _freelancerService.GetAllFreelancers(isarchived: false);
            var inActive = await _freelancerService.GetAllFreelancers(isarchived: true);
            active.AddRange(inActive);
            return Ok(active);
        }
            

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFreelancer(int id)
        {
            //var freelancer = await _repository.GetFreelancerByIdAsync(id);
           var freelancer = await _freelancerService.GetFreelancerByID(id);
            if (freelancer == null) return NotFound();
            return Ok(freelancer);
        }

        [HttpPost]
        public async Task<IActionResult> AddFreelancer(FreelancerDTO freelancer)
        {
            //await _repository.AddFreelancerAsync(freelancer);
            await _freelancerService.AddFreelancerAsync(freelancer);
            return CreatedAtAction(nameof(GetFreelancer), new { id = freelancer.Id }, freelancer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFreelancer(int id, FreelancerDTO freelancer)
        {                     
            await _freelancerService.UpdateFreelancerAsync(id, freelancer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelancer(int id)
        {
            //await _repository.DeleteFreelancerAsync(id);
            await _freelancerService.DeleteFreelancerAsync(id);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchFreelancers([FromQuery] string query)
            => Ok(await _freelancerService.SearchFreelancersAsync(query));

        [HttpPut("{id}/archive")]
        public async Task<IActionResult> ArchiveFreelancer(int id)
        {
            await _freelancerService.ArchiveFreelancerAsync(id);
            return NoContent();
        }

        [HttpPut("{id}/unarchive")]
        public async Task<IActionResult> UnarchiveFreelancer(int id)
        {
            await _freelancerService.UnarchiveFreelancerAsync(id);
            return NoContent();
        }
    }
}
