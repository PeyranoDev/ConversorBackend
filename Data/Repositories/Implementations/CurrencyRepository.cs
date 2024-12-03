using Data.Entities;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly CurrencyAppContext _context;

        public CurrencyRepository(CurrencyAppContext context)
        {
            _context = context;
        }

        public Currency GetCurrencyById(int id)
        {
            return _context.Currencies.FirstOrDefault(c => c.Id == id);
        }

        public List<Currency> GetAllCurrencies()
        {
            return _context.Currencies.ToList();
        }
        public void UpdateCurrency(Currency currency)
        {
            _context.Currencies.Update(currency);
            _context.SaveChanges();
        }

    }
}
