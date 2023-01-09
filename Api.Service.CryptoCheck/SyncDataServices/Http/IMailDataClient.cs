using Api.Service.CryptoCheck.Dtos;

namespace Api.Service.CryptoCheck.SyncDataServices.Http;

public interface IMailDataClient
{
    Task SendCryptocurrencyViaMail(CryptocurrencyReadDto crypto);
}