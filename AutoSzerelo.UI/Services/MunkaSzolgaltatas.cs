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

        public Task AddJobAsync(Munka munka)
        {
            return _httpClient.PostAsJsonAsync("/munka", munka);
        }

        public Task DeleteJobAsync(Guid id)
        {
            return _httpClient.DeleteAsync($"/munka/{id}");
        }

        public async Task<IEnumerable<Munka>> GetAllJobAsync()
        {
            var eredmeny = await _httpClient.GetFromJsonAsync<IEnumerable<Munka>>("/munka");
            if (eredmeny != null)
            {
                return eredmeny;
            }
            throw new Exception("A válasz üres");
        }


        public async Task<Munka> GetJobAsync(Guid id)
        {
            var eredmeny = await _httpClient.GetFromJsonAsync<Munka>($"/munka/{id}");
            if (eredmeny != null)
            {
                return eredmeny;
            }
            throw new Exception("A válasz üres.");
        }

        public Task<IEnumerable<Munka>?> GetJobsOfClientAsync(Guid clientId)
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<Munka>>($"/kliens/{clientId}/munka");
        }

        public Task UpdateJobAsync(Guid id, Munka munka)
        {
            return _httpClient.PutAsJsonAsync($"/munka/{id}", munka);
        }
    }
}
