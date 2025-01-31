using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using Services.Interfaces;
using Services.Models;
namespace FreelanceWeb.Controllers
{

    public class FreelancerController : Controller
    {
        private readonly IFreelancerService _freelancerService;


        public FreelancerController(FreelancerService freelancerService)
        {
            _freelancerService = freelancerService;
        }
         
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FreelancerDTO freelancer)
        {
            if (ModelState.IsValid)
            {
                var createdFreelancer = await _freelancerService.CreateFreelancerAsync(freelancer);
                return RedirectToAction("Details", new { id = createdFreelancer.Id });
            }
            return View(freelancer);
        }

        //Get all freelancers
        public async Task<IActionResult> Index()
        {
            var freelancers = await _freelancerService.GetFreelancersAsync();
            return View(freelancers);
        }

        // Get freelancer by ID
        public async Task<IActionResult> Details(int id)
        {
            var freelancer = await _freelancerService.GetFreelancerByIdAsync(id);
            if (freelancer == null)
            {
                return NotFound();
            }
            return View(freelancer);
        }

        // Edit freelancer
        public async Task<IActionResult> Edit(int id)
        {
            var freelancer = await _freelancerService.GetFreelancerByIdAsync(id);
            if (freelancer == null)
            {
                return NotFound();
            }
            return View(freelancer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FreelancerDTO freelancer)
        {
            if (ModelState.IsValid)
            {
                var updatedFreelancer = await _freelancerService.UpdateFreelancerAsync(id, freelancer);
                return RedirectToAction("Details", new { id = updatedFreelancer.Id });
            }
            return View(freelancer);
        }

        // Delete freelancer
        public async Task<IActionResult> Delete(int id)
        {
            await _freelancerService.DeleteFreelancerAsync(id);
            return RedirectToAction("Index");
        }
    }
}
