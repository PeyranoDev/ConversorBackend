using Common.Modals;
using Data.Entities;

namespace Services.Services.Interfaces
{
    public interface ICurrencyService
    {
        void UpdateCurrency(CurrencyForUpdateDTO dto);
        IEnumerable<Currency> Get();
    }
}