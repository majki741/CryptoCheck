namespace Api.Service.CryptoCheck.Dtos;

public class CryptocurrencyReadDto
{
    public int CryptoId { get; set; }
    
    public string CryptoName { get; set; }
    
    public string CryptoShortName { get; set; }
    
    public double CryptoPrice { get; set; }
}