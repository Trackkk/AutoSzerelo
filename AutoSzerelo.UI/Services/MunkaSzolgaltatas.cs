using AutoSzerelo.Shared;
using System.Net.Http.Json;

namespace AutoSzerelo.UI.Services
{
    public class MunkaSzolgaltatas : IMunkaSzolgaltatas
    {
        private readonly HttpClient _httpClient;

        public MunkaSzolgaltatas(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddJobAsync(Munka munka)
        {
            await _httpClient.PostAsJsonAsync("/munka", munka);
        }

        public async Task DeleteJobAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/munka/{id}");
        }

        public async Task<IEnumerable<Munka>> GetAllJobAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Munka>>("/munka");
        }

        public async Task<Munka> GetJobAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Munka>($"/munka/{id}");
        }

        public async Task<IEnumerable<Munka>> GetJobsOfClientAsync(Guid clientId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Munka>>($"/kliens/{clientId}/munka");
        }

        public async Task UpdateJobAsync(Guid id, Munka munka)
        {
            await _httpClient.PutAsJsonAsync($"/munka/{id}", munka);
        }
    }
}
