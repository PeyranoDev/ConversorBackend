using Common.Enums;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementations
{
    public class ConversionService : IConversionService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IConversionRepository _conversionRepository;
        private readonly IUserRepository _userRepository;

        public ConversionService(ICurrencyRepository currencyRepository, IConversionRepository conversionRepository, IUserRepository userRepository)
        {
            _currencyRepository = currencyRepository;
            _conversionRepository = conversionRepository;
            _userRepository = userRepository;
        }

        public ConversionResultDTO ConvertCurrency(int userId, int initialCurrencyId, int finalCurrencyId, decimal amount)
        {
            CheckConversionLimit(userId);
            var user = _userRepository.Get(userId);
           
            var initialCurrency = _currencyRepository.GetCurrencyById(initialCurrencyId);
            var finalCurrency = _currencyRepository.GetCurrencyById(finalCurrencyId);

            if (initialCurrency == null || finalCurrency == null)
            {
                throw new ArgumentException("One or both currencies not found.");
            }

            
            decimal convertedOutput = ConvertAmount(initialCurrency, finalCurrency, amount);
            IncrementConversionCount(userId);

            var conversion = new Conversion
            {
                UserId = userId,
                InitialCurrencyId = initialCurrencyId,
                FinalCurrencyId = finalCurrencyId,
                DateTime = DateTime.UtcNow,
                ConvertedAmount = convertedOutput,
                InitialAmount = amount,
                User = user
            };

            _conversionRepository.AddConversion(conversion);
            

            return new ConversionResultDTO
            {
                InitialAmount = amount,
                ConvertedAmount = convertedOutput,
                InitialCurrency = initialCurrency.Code,
                FinalCurrency = finalCurrency.Code,
                ConversionRate = GetConversionRate(initialCurrency, finalCurrency)
            };
        }
        private void IncrementConversionCount(int userId)
        {
            var user = _userRepository.Get(userId);
            int conver = _conversionRepository.GetConversionCountByUserId(userId);

            user.ConversionsUsed = conver + 1;
            
            _userRepository.Update(user);
        }

        public IList<Conversion> GetConversionByUserId(int userId)
        {
            return _conversionRepository.GetConversionsByUserId(userId);
        }

        private decimal ConvertAmount(Currency initialCurrency, Currency finalCurrency, decimal amount)
        {
            decimal amountInUSD = amount * initialCurrency.ConvertibilityIndex;

            decimal convertedAmount = amountInUSD / finalCurrency.ConvertibilityIndex;

            return convertedAmount;
        }

        private decimal GetConversionRate(Currency initialCurrency, Currency finalCurrency)
        {
            if (initialCurrency.ConvertibilityIndex == 0)
            {
                throw new InvalidOperationException("Initial currency has invalid convertibility index.");
            }

            return finalCurrency.ConvertibilityIndex / initialCurrency.ConvertibilityIndex;
        }

        public void CheckConversionLimit(int userId)
        {
            int conversionsMade = _conversionRepository.GetConversionCountByUserId(userId);
            var user = _userRepository.GetForConversions(userId);

            if (user.UserSubscription.Type == SubscriptionTypeEnum.Pro)
            {
                return; 
            }

            if (user.UserSubscription.Type == SubscriptionTypeEnum.Free && conversionsMade >= 10)
            {
                throw new InvalidOperationException("Free users can only make 10 conversions in the last 30 days.");
            }

            if (user.UserSubscription.Type == SubscriptionTypeEnum.Trial && conversionsMade >= 100)
            {
                throw new InvalidOperationException("Trial users can only make 100 conversions in the last 30 days.");
            }
        }
    }
}
