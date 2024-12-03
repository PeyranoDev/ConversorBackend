using Common.Modals.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modals
{
    public class UserForUpdateDTO
    {
        [AtLeastOneRequiredUser]
        public string Username { get; set; }
        [AtLeastOneRequiredUser]
        public string Password { get; set; }
        [AtLeastOneRequiredUser]
        public string Email { get; set; }
        [AtLeastOneRequiredUser]
        public int SubscriptionId { get; set; }

    }
}
