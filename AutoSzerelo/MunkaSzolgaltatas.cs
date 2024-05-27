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

        public async Task Add(Munka munka)
        {
            try
            {
                await _context.Munkak.AddAsync(munka);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Munka sikeresen hozzáadva: {@MunkaId}", munka.MunkaId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hiba történt a munka hozzáadása során: {@MunkaId}", munka.MunkaId);
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var munka = await Get(id);
                _context.Munkak.Remove(munka);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Munka sikeresen törölve: {@MunkaId}", munka.MunkaId);
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
                var munka = await _context.Munkak.FindAsync(id);
                _logger.LogInformation("Munka sikeresen lekérve: {@MunkaId}", id);
                return munka;
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

        public async Task Update(Munka ujMunka)
        {
            try
            {
                var regiMunka = await Get(ujMunka.MunkaId);
                regiMunka.KliensId = ujMunka.KliensId;
                regiMunka.Allapot = ujMunka.Allapot;
                regiMunka.Rendszam = ujMunka.Rendszam;
                regiMunka.GyartasiEv = ujMunka.GyartasiEv;
                regiMunka.MKategoria = ujMunka.MKategoria;
                regiMunka.Leiras = ujMunka.Leiras;
                regiMunka.HibaSulyossaga = ujMunka.HibaSulyossaga;      

                await _context.SaveChangesAsync();
                _logger.LogInformation("Munka sikeresen frissítve: {@MunkaId}", ujMunka.MunkaId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hiba történt a munka frissítése során: {@MunkaId}", ujMunka.MunkaId);
                throw;
            }
        }
    }
}
