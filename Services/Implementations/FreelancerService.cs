using System.Net.Http.Json;
using Services.Interfaces;
using Services.Models;

namespace Services.Implementations
{
    public class FreelancerService : IFreelancerService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7089"; // API base URL

        public FreelancerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Create freelancer
        public async Task<FreelancerDTO> CreateFreelancerAsync(FreelancerDTO freelancer)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Freelancer", freelancer);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FreelancerDTO>();
        }

        // Get all freelancers
        public async Task<List<Freelancer>> GetFreelancersAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Freelancer>>($"{_baseUrl}/allFreelancers");
            return response ?? new List<Freelancer>();
        }

        // Get a freelancer by ID
        public async Task<FreelancerDTO> GetFreelancerByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<FreelancerDTO>($"{_baseUrl}/api/Freelancer/{id}");
            return response;
        }

        // Update freelancer
        public async Task<FreelancerDTO> UpdateFreelancerAsync(int id, FreelancerDTO freelancer)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Freelancer/{id}", freelancer);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FreelancerDTO>();
        }

        // Delete freelancer
        public async Task DeleteFreelancerAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Freelancer/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
