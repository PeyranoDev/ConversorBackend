using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public int SubscriptionId { get; set; }
        public Subscription UserSubscription { get; set; }

        public int ConversionsUsed { get; set; } = 0;
        public bool isAdmin { get; set; } = false;
        public bool isActive { get; set; } = true;
    }
}
