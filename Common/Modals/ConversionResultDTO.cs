using System.ComponentModel.DataAnnotations;

public class ConversionResultDTO
{
    public decimal InitialAmount { get; set; }
    public decimal ConvertedAmount { get; set; }
    public string InitialCurrency { get; set; }
    public string FinalCurrency { get; set; }
    public decimal ConversionRate { get; set; }
}
