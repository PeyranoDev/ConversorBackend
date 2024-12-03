using Common.Enums;
using Data.Entities;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly CurrencyAppContext _context;

        public SubscriptionRepository(CurrencyAppContext context)
        {
            _context = context;
        }

        public Subscription GetSubscriptionByType(SubscriptionTypeEnum typeEnum)
        {
            var subscription = _context.Subscriptions.First(s => s.Type == typeEnum);
            return subscription;
        }

        public Subscription? GetSubscriptionById(int id)
        {
            var subscription = _context.Subscriptions.FirstOrDefault(s => s.Id == id);
            return subscription;
        }
        public IEnumerable<Subscription> GetAllSubscriptions()
        {
            return _context.Subscriptions.ToList();
        }
    };
}
