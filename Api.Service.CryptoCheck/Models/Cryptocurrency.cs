using System.ComponentModel.DataAnnotations;

namespace Api.Service.CryptoCheck.Models;

public class Cryptocurrency
{
    [Key]
    [Required]
    public int CryptoId { get; set; }
    
    [Required]
    public string CryptoName { get; set; }
    
    [Required]
    public string CryptoShortName { get; set; }
    
    [Required]
    public double CryptoPrice { get; set; }
}