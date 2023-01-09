using System.Text;
using System.Text.Json;
using Api.Service.CryptoCheck.Dtos;

namespace Api.Service.CryptoCheck.SyncDataServices.Http;

public class HttpMailDataClient : IMailDataClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public HttpMailDataClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    
    public async Task SendCryptocurrencyViaMail(CryptocurrencyReadDto crypto)
    {
        var httpContent = new StringContent(JsonSerializer.Serialize(crypto), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_configuration["MailServiceAddress"]}api/Mail", httpContent);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("--> POST to MailService succesfull!");
            var responseMessage = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseMessage);
        }
        else
        {
            Console.WriteLine("--> POST to MailService unsuccesfull!");
        }
    }
}