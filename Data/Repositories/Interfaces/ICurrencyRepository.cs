using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface ICurrencyRepository
    {
        Currency GetCurrencyById(int id);
        List<Currency> GetAllCurrencies();
        void UpdateCurrency(Currency currency);
    }
}