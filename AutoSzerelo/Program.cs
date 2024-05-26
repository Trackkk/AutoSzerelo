using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AutoSzerelo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSerilog(
                    config =>
                        config
                            .MinimumLevel.Information()
                            .WriteTo.Console()
                            .WriteTo.File("log.txt"));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            
            builder.Services.AddDbContext<AutoSzereloKontextus>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
                options.UseLazyLoadingProxies();
            }, ServiceLifetime.Singleton);

            builder.Services.AddSingleton<IKliensSzolgaltatas, KliensSzolgaltatas>();
            builder.Services.AddSingleton<IMunkaSzolgaltatas, MunkaSzolgaltatas>();
            

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }


    }
}
