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
            var eredmeny = await _httpClient.GetFromJsonAsync<IEnumerable<Kliens>>("/kliens");
            if (eredmeny != null)
            {
                return eredmeny;
            }
            throw new Exception("A válasz üres");
        }

        public async Task<Kliens> GetClientAsync(Guid id)
        {
            var eredmeny =  await _httpClient.GetFromJsonAsync<Kliens>($"/kliens/{id}");
            if (eredmeny != null)
            {
                return eredmeny;
            }
            throw new Exception("A válasz üres");
        }

        public async Task<IEnumerable<Munka>> GetJobsOfClientAsync(Guid kliensId)
        {
            var eredmeny = await _httpClient.GetFromJsonAsync<IEnumerable<Munka>>($"/kliens/{kliensId}/munka");
            if (eredmeny != null)
            {
                return eredmeny;
            }
            throw new Exception("A válasz üres");
        }

        public async Task UpdateClientAsync(Guid id, Kliens kliens)
        {
            await _httpClient.PutAsJsonAsync($"/kliens/{id}", kliens);
        }
    }
}
