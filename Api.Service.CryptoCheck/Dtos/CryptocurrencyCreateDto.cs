using System.ComponentModel.DataAnnotations;

namespace Api.Service.CryptoCheck.Dtos;

public class CryptocurrencyCreateDto
{
    [Required]
    public string CryptoName { get; set; }
    
    [Required]
    public string CryptoShortName { get; set; }
    
    [Required]
    public double CryptoPrice { get; set; }
}