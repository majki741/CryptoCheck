using Api.Service.CryptoCheck.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.CryptoCheck.Data;

public static  class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app, bool isDev)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isDev);
        }
    }

    private static void SeedData(AppDbContext context, bool isDev)
    {
        if (!isDev)
        {
            Console.WriteLine("Attempting to apply migrations...");
            try
            {
                context.Database.Migrate();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> {DateTime.Now.ToString("yyyy-MM-dd HH:mm")} Migrations error: {ex.Message}");
            }
            
        }
        if (!context.Cryptocurrencies.Any())
        {
            Console.WriteLine("Seeding data...");
            
            context.Cryptocurrencies.AddRange(
                new Cryptocurrency() {CryptoName = "Ethereum", CryptoShortName = "ETH", CryptoPrice = 1400.00},
                new Cryptocurrency() {CryptoName = "Bitcoin", CryptoShortName = "BTC", CryptoPrice = 19000.00},
                new Cryptocurrency() {CryptoName = "BNB", CryptoShortName = "BNB", CryptoPrice = 260.00}
                );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("We already have data");
        }
    }
}