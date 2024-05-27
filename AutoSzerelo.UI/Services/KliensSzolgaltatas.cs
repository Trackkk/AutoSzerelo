using AutoSzerelo.Shared;
using System.Net.Http.Json;

namespace AutoSzerelo.UI.Services
{
    public class KliensSzolgaltatas : IKliensSzolgaltatas
    {
        private readonly HttpClient _httpClient;

        public KliensSzolgaltatas(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddClientAsync(Kliens kliens)
        {
            await _httpClient.PostAsJsonAsync("/kliens", kliens);
        }

        public async Task DeleteClientAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/kliens/{id}");
        }

        public async Task<IEnumerable<Kliens>> GetAllClientAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Kliens>>("/kliens");
        }

        public async Task<Kliens> GetClientAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Kliens>($"/kliens/{id}");
        }

        public async Task<IEnumerable<Munka>> GetJobsOfClientAsync(Guid kliensId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Munka>>($"/kliens/{kliensId}/munka");
        }

        public async Task UpdateClientAsync(Guid id, Kliens kliens)
        {
            await _httpClient.PutAsJsonAsync($"/kliens/{id}", kliens);
        }
    }
}
