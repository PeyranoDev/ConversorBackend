using Common.Modals;
using Data.Entities;
using Data.Repositories.Interfaces;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementations
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;

        }

        public void UpdateCurrency(CurrencyForUpdateDTO dto)
        {
            {
                var existingCurrency = _currencyRepository.GetCurrencyById(dto.CurrencyID);

                if (existingCurrency == null)
                {
                    throw new ArgumentException("Currency not found.");
                }

                if (!string.IsNullOrEmpty(dto.Code))
                {
                    existingCurrency.Code = dto.Code;
                }

                if (!string.IsNullOrEmpty(dto.Legend))
                {
                    existingCurrency.Legend = dto.Legend;
                }

                if (dto.ConvertibilityIndex != 0)
                {
                    existingCurrency.ConvertibilityIndex = dto.ConvertibilityIndex;
                }

                _currencyRepository.UpdateCurrency(existingCurrency);
            }
        }
        public IEnumerable<Currency> Get()
        {
            return _currencyRepository.GetAllCurrencies();
        }
    }
}
