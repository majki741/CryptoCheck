using Api.Service.CryptoCheck.Dtos;
using Api.Service.CryptoCheck.Models;
using AutoMapper;

namespace Api.Service.CryptoCheck.Profiles;

public class CryptocurrenciesProfile : Profile
{
    public CryptocurrenciesProfile()
    {
        CreateMap<Cryptocurrency, CryptocurrencyReadDto>();

        CreateMap<CryptocurrencyCreateDto, Cryptocurrency>();
    }
}