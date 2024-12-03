using Common.Enums;
using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        IEnumerable<Subscription> GetAllSubscriptions();
        Subscription? GetSubscriptionById(int id);
        Subscription GetSubscriptionByType(SubscriptionTypeEnum typeEnum);
    }
}