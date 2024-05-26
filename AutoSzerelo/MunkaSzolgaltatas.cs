using AutoSzerelo.Shared;
using Microsoft.EntityFrameworkCore;

namespace AutoSzerelo
{
    public class MunkaSzolgaltatas : IMunkaSzolgaltatas
    {
        private readonly AutoSzereloKontextus _context;
        private readonly ILogger<MunkaSzolgaltatas> _logger;

        public MunkaSzolgaltatas(ILogger<MunkaSzolgaltatas> logger, AutoSzereloKontextus context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Add(Munka job)
        {
            try
            {
                await _context.Munkak.AddAsync(job);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Munka sikeresen hozzáadva: {@MunkaId}", job.MunkaId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hiba történt a munka hozzáadása során: {@MunkaId}", job.MunkaId);
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var job = await Get(id);
                _context.Munkak.Remove(job);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Munka sikeresen törölve: {@MunkaId}", job.MunkaId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hiba történt a munka törlése során: {@MunkaId}", id);
                throw;
            }
        }

        public async Task<Munka> Get(Guid id)
        {
            try
            {
                var job = await _context.Munkak.FindAsync(id);
                _logger.LogInformation("Munka sikeresen lekérve: {@MunkaId}", id);
                return job;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hiba történt a munka lekérdezése során: {@MunkaId}", id);
                throw;
            }
        }

        public async Task<List<Munka>> GetAll()
        {
            try
            {
                _logger.LogInformation("Munkák sikeresen lekérve");
                return await _context.Munkak.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hiba történt a munkák lekérdezése során");
                throw;
            }
        }

        public async Task Update(Munka job)
        {
            try
            {
                _context.Munkak.Update(job);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Munka sikeresen frissítve: {@MunkaId}", job.MunkaId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hiba történt a munka frissítése során: {@MunkaId}", job.MunkaId);
                throw;
            }
        }
    }
}
