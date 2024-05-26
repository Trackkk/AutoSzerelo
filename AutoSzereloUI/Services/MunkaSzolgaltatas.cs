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
            try
            {
                await _httpClient.PostAsJsonAsync("/Munkak", munka);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteJobAsync(Guid id)
        {
            try
            {
                await _httpClient.DeleteAsync($"/Munkak/{id}");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Munka>> GetAllJobAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Munka>>("/Munkak");
            }
            catch
            {
                throw;
            }
        }

        public async Task<Munka> GetJobAsync(Guid id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Munka>($"Munkak/{id}");
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateJobAsync(Guid id, Munka munka)
        {
            try
            {
                await _httpClient.PutAsJsonAsync($"/Munkak/{id}", munka);
            }
            catch
            {
                throw;
            }
        }
    }
}
