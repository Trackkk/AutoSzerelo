using AutoSzereloShared;

namespace AutoSzerelo
{
    public interface IKliensSzolgaltatas
    {
        Task Add(Kliens kliens);

        Task Delete(Guid id);

        Task<Kliens> Get(Guid id);

        Task<List<Kliens>> GetAll();

        Task Update(Kliens kliens);

        Task<List<Munka>> GetJobsOfClient(Guid kliensId);
    }
}
