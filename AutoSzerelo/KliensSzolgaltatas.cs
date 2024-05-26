using AutoSzerelo.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace AutoSzerelo
{
    public class KliensSzolgaltatas : IKliensSzolgaltatas
    {
        private readonly AutoSzereloKontextus _context;
        private readonly ILogger<KliensSzolgaltatas> _logger;

        public KliensSzolgaltatas(AutoSzereloKontextus context, ILogger<KliensSzolgaltatas> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Add(Kliens kliens)
        {
            try
            {
                _context.Kliensek.Add(kliens);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Kliens hozzáadva: {@KliensId}", kliens.KliensId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hiba történt a kliens hozzáadása során: {@KliensId}", kliens.KliensId);
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var kliens = await Get(id);
                _context.Kliensek.Remove(kliens);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Kliens sikeresen törölve: {@KliensId}", kliens);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hiba történt a kliens törlése során: {@KliensId}", id);
                throw;
            }
        }

        public async Task<Kliens> Get(Guid id)
        {
            try
            {
                var kliens = await _context.Kliensek.FindAsync(id);
                _logger.LogInformation("Kliens lekérve: {KliensId}", id);
                return kliens;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kliens nem találtható: {@KliensId}", id);
                throw;
            }
            
        }

        public async Task<List<Kliens>> GetAll()
        {
            try
            {
                _logger.LogInformation("Kliensek lekérve");
                return await _context.Kliensek.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hiba történt a kliensek lekérdezése során");
                throw;
            }
        }

        public async Task<List<Munka>> GetJobsOfClient(Guid kliensId)
        {
            try
            {
                var munkak = await _context.Munkak.
                    Where(m => m.KliensId == kliensId).ToListAsync();
                _logger.LogInformation("Munka sikeresen lekérve a kliens számára: {@KliensId}", kliensId);
                return munkak;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hiba történt a kliens munkáinak lekérdezése során: {@KliensId}", kliensId);
                throw;
            }
        }

        public async Task Update(Kliens ujkliens)
        {
            try
            {
                var regiKliens = await Get(ujkliens.KliensId);
                regiKliens.KliensNev = ujkliens.KliensNev;
                regiKliens.Lakcim = ujkliens.Lakcim;
                regiKliens.Email = ujkliens.Email;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Kliens sikeresen frissítve: {@KliensId}", ujkliens.KliensId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hiba történt a kliens frissítése során: : {@KliensId}", ujkliens.KliensId);
                throw;
            }
        }
    }
}
