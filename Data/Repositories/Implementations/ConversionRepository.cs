using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class ConversionRepository : IConversionRepository
    {
        private readonly CurrencyAppContext _context;

        public ConversionRepository(CurrencyAppContext context)
        {
            _context = context;
        }

        public void AddConversion(Conversion conversion)
        {
            _context.Conversions.Add(conversion);
            _context.SaveChanges();
        }

        public int GetConversionCountByUserId(int userId)
        {
            var thirtyDaysAgo = DateTime.Now.AddDays(-30);

            return _context.Conversions
                .Where(c => c.UserId == userId && c.DateTime >= thirtyDaysAgo)
                .Count();
        }

        public List<Conversion> GetConversionsByUserId(int userId)
        {

            return _context.Conversions
                .Where(c => c.UserId == userId)
                .Include(c => c.InitialCurrency)
                .Include(c => c.FinalCurrency)
                .OrderByDescending(c => c.DateTime)
                .ToList();
        }
    }
}
