using Common.Enums;
using Data.Entities;

namespace Services.Services.Interfaces
{
    public interface ISubscriptionService
    {
        IEnumerable<Subscription> GetAllSubscriptions();
        Subscription? GetSubscriptionById(int id);
        Subscription? GetSubscriptionByType(SubscriptionTypeEnum type);
        IEnumerable<Subscription> Get();
    }
}