using Api.Service.CryptoCheck.Models;

namespace Api.Service.CryptoCheck.Data;

public static  class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }

    private static void SeedData(AppDbContext context)
    {
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