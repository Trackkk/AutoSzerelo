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
            try
            {
                await _httpClient.PostAsJsonAsync("/Kliensek", kliens);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteClientAsync(Guid id)
        {
            try
            {
                await _httpClient.DeleteAsync($"/Kliensek/{id}");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Kliens>> GetAllClientAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Kliens>>("/Kliensek");
            }
            catch
            {
                throw;
            }
        }

        public async Task<Kliens> GetClientAsync(Guid id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Kliens>($"/Kliensek/{id}");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Munka>> GetJobsOfClientAsync(Guid clientId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Munka>>($"/Kliensek/{clientId}/munkak");
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateClientAsync(Guid id, Kliens kliens)
        {
            try
            {
                await _httpClient.PutAsJsonAsync($"/Kliensek/{id}", kliens);
            }
            catch
            {
                throw;
            }
        }
    }
}
