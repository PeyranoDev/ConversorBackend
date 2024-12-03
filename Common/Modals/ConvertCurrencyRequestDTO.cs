using System.ComponentModel.DataAnnotations;

public class ConvertCurrencyRequestDTO
{
    [Required]
    public int InitialCurrencyId { get; set; }
    [Required]
    public int FinalCurrencyId { get; set; }
    [Required]
    public decimal Amount { get; set; }
}
