using Common.Enums;
using Data.Entities;
using Data.Repositories.Interfaces;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementations
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public IEnumerable<Subscription> GetAllSubscriptions()
        {
            return _subscriptionRepository.GetAllSubscriptions();
        }
        public Subscription? GetSubscriptionById(int id)
        {
            return _subscriptionRepository.GetSubscriptionById(id);
        }
        public Subscription? GetSubscriptionByType(SubscriptionTypeEnum type) 
        {
            return _subscriptionRepository.GetAllSubscriptions().FirstOrDefault(s => s.Type == type);
        }
        public IEnumerable<Subscription> Get()
        {
            return _subscriptionRepository.GetAllSubscriptions();
        }
    }
}
