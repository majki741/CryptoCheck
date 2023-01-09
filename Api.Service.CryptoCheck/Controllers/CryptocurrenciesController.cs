using Api.Service.CryptoCheck.Data;
using Api.Service.CryptoCheck.Dtos;
using Api.Service.CryptoCheck.Models;
using Api.Service.CryptoCheck.SyncDataServices.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Service.CryptoCheck.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CryptocurrenciesController : ControllerBase
{
    private readonly ICryptocurrencyRepo _repository;
    private readonly IMapper _mapper;
    private readonly IMailDataClient _dataClient;

    public CryptocurrenciesController(ICryptocurrencyRepo repository, IMapper mapper, IMailDataClient dataClient)
    {
        _repository = repository;
        _mapper = mapper;
        _dataClient = dataClient;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CryptocurrencyReadDto>> GetCryptocurrencies()
    {
        Console.WriteLine("Getting Cryptocurrencies..");

        var cryptocurrencyItem = _repository.GetAllCryptocurrencies();
        return Ok(_mapper.Map<IEnumerable<CryptocurrencyReadDto>>(cryptocurrencyItem));
    }

    [HttpGet("{id}", Name = "GetCryptocurrencyById")]
    public ActionResult<CryptocurrencyReadDto> GetCryptocurrencyById(int id)
    {
        var cryptocurrencyItem = _repository.GetCryptocurrencyById(id);
        if (cryptocurrencyItem != null)
        {
            return Ok(_mapper.Map<CryptocurrencyReadDto>(cryptocurrencyItem));
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<CryptocurrencyReadDto>> AddCryptocurrency(CryptocurrencyCreateDto cryptocurrencyCreateDto)
    {
        var cryptocurrencyModel = _mapper.Map<Cryptocurrency>(cryptocurrencyCreateDto);
        _repository.AddCryptocurrency(cryptocurrencyModel);
        _repository.SaveChanges();

        var cryptocurrencyReadDto = _mapper.Map<CryptocurrencyReadDto>(cryptocurrencyModel);

        try
        {
            await _dataClient.SendCryptocurrencyViaMail(cryptocurrencyReadDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> {DateTime.Now.ToString("yyyy-MM-dd HH:mm")} Error with sent: {ex.Message}");
        }
        
        return CreatedAtRoute(nameof(GetCryptocurrencyById), new {id = cryptocurrencyReadDto.CryptoId}, cryptocurrencyReadDto);
    }
}