using Data.Entities;

namespace Services.Services.Interfaces
{
    public interface IConversionService
    {
        ConversionResultDTO ConvertCurrency(int userId, int initialCurrencyId, int finalCurrencyId, decimal amount);
        IList<Conversion> GetConversionByUserId(int userId);
        void CheckConversionLimit(int userId);
    }
}