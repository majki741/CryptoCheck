using Api.Service.CryptoCheck.Models;

namespace Api.Service.CryptoCheck.Data;

public interface ICryptocurrencyRepo
{
    bool SaveChanges();

    IEnumerable<Cryptocurrency> GetAllCryptocurrencies();

    Cryptocurrency GetCryptocurrencyById(int id);

    void AddCryptocurrency(Cryptocurrency cryptocurrency);
}