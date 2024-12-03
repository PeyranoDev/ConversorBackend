using Common.Modals;
using Data.Entities;

namespace Services.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(UserForCreateDTO dto);
        User? AuthenticateUser(Credentials authRequestBody);
        User? Get(int userId);
        IEnumerable<User> Get();
        void UpdateUserSubscription(int userId, int subscriptionId);
        void Delete(int userId);
        UserDetailsDTO GetUserDetails(int userId);
    }
}