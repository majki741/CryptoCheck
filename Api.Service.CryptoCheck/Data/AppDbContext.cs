using Api.Service.CryptoCheck.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.CryptoCheck.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
        
    }
    
    public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }
}