using Api.Service.CryptoCheck.Models;

namespace Api.Service.CryptoCheck.Data;

public class CryptocurrencyRepo : ICryptocurrencyRepo
{
    private readonly AppDbContext _context;

    public CryptocurrencyRepo(AppDbContext context)
    {
        _context = context;
    }
    
    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public IEnumerable<Cryptocurrency> GetAllCryptocurrencies()
    {
        return _context.Cryptocurrencies.ToList();
    }

    public Cryptocurrency GetCryptocurrencyById(int id)
    {
        return _context.Cryptocurrencies.FirstOrDefault(x => x.CryptoId == id);
    }

    public void AddCryptocurrency(Cryptocurrency cryptocurrency)
    {
        if (cryptocurrency == null)
        {
            throw new ArgumentNullException(nameof(cryptocurrency));
        }

        _context.Cryptocurrencies.Add(cryptocurrency);
    }
}