using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public SubscriptionTypeEnum Type { get; set; }

        public int? ConversionLimit { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}