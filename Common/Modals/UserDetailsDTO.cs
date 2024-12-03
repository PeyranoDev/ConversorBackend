using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modals
{
    public class UserDetailsDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int SubscriptionId { get; set; }
        public int ConversionsUsed { get; set; }
        public bool isAdmin { get; set; }
        public bool isActive { get; set; }
    }
}
