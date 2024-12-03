using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Conversion
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; } 
        public int InitialCurrencyId { get; set; } 
        public Currency InitialCurrency { get; set; } 
        public int FinalCurrencyId { get; set; }
        public Currency FinalCurrency { get; set; } 
        public DateTime DateTime { get; set; }
        public decimal ConvertedAmount { get; set; } 
        public decimal InitialAmount { get; set; }
    }
}

