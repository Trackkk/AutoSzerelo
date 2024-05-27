using AutoSzerelo.Shared;

namespace AutoSzerelo.UI.Services
{
    public interface IMunkaSzolgaltatas
    {
        Task AddJobAsync(Munka munka);

        Task DeleteJobAsync(Guid id);

        Task<Munka> GetJobAsync(Guid id);

        Task<IEnumerable<Munka>> GetAllJobAsync();

        Task UpdateJobAsync(Guid id, Munka job);
    }
}
