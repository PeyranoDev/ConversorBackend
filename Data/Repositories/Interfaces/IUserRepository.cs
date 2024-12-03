using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        IEnumerable<User> Get();
        User GetForConversions(int userId);
        User? Get(string username);
        User? Get(int userId);
        void UpdateUserSubscription(int userId, Subscription subscription);
        void Delete(int userId);
        void Update(User user);
    }
}