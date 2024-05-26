using AutoSzereloShared;
namespace AutoSzerelo
{
    public interface IMunkaSzolgaltatas
    {
        Task Add(Munka job);

        Task Delete(Guid id);

        Task<Munka> Get(Guid id);

        Task<List<Munka>> GetAll();

        Task Update(Munka job);
    }
}
