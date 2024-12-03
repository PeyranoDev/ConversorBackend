using Common.Modals.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modals
{
    public class CurrencyForUpdateDTO
    {
        [Required]
        public int CurrencyID { get; set; }

        [AtLeastOneRequiredCurrency]
        [MaxLength(10)]
        public string Code { get; set; }

        [AtLeastOneRequiredCurrency]
        [MaxLength(50)]
        public string Legend { get; set; }

        [AtLeastOneRequiredCurrency]
        public decimal ConvertibilityIndex { get; set; }
    }
}
