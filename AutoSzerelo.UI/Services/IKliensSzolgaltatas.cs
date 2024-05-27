using AutoSzerelo.Shared;
namespace AutoSzerelo.UI.Services
{
    public interface IKliensSzolgaltatas
    {
        Task AddClientAsync(Kliens kliens);

        Task DeleteClientAsync(Guid id);

        Task<Kliens> GetClientAsync(Guid id);

        Task<IEnumerable<Kliens>> GetAllClientAsync();

        Task UpdateClientAsync(Guid id, Kliens kliens);

        Task<IEnumerable<Munka>> GetJobsOfClientAsync(Guid kliensId);
    }
}
