using Common.Enums;
using Common.Modals;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ISubscriptionService _subscriptionService;
        public UserService(IUserRepository userRepository, IPasswordHasherService passwordHasherService, ISubscriptionRepository subscriptionRepository, ISubscriptionService subscriptionService)
        {
            _userRepository = userRepository;
            _passwordHasherService = passwordHasherService;
            _subscriptionService = subscriptionService;
        }

        public void AddUser(UserForCreateDTO dto)
        {
            if (_userRepository.Get().All(user => user.Username != dto.Username))
            {
                var subscription = _subscriptionService.GetSubscriptionById(dto.SubscriptionId);

                if (subscription == null)
                {
                    throw new Exception("Subscription not found.");
                }

                _userRepository.AddUser(
                    new User
                    {
                        Username = dto.Username,
                        PasswordHash = _passwordHasherService.HashPassword(dto.Password),
                        Email = dto.Email,
                        ConversionsUsed = 0,
                        SubscriptionId = dto.SubscriptionId,
                        UserSubscription = subscription,  
                        isActive = true,
                    }
                );
            }
            else
            {
                throw new Exception("El usuario ya existe...");
            }
        }
        public User? AuthenticateUser(Credentials authRequestBody)
        {
            
            User? userToReturn = _userRepository.Get(authRequestBody.Username);

            
            if (userToReturn != null && _passwordHasherService.VerifyPassword(authRequestBody.Password, userToReturn.PasswordHash))
            {
                return userToReturn;
            }

            return null;
        }
        public IEnumerable<User> Get()
        {
            return _userRepository.Get();
        }
        public User? Get(int userId)
        {
            return _userRepository.Get(userId);
        }
        public void UpdateUserSubscription(int userId, int subscriptionId)
        {

            var subscription = _subscriptionService.GetSubscriptionById(subscriptionId);
            if (subscription == null)
                throw new ArgumentException($"The subscription with ID {subscriptionId} does not exist.");

            
            _userRepository.UpdateUserSubscription(userId, subscription);
        }
        public void Delete(int userId)
        {
            _userRepository.Delete(userId);
        }
        public UserDetailsDTO GetUserDetails(int userId)
        {
            var user = _userRepository.Get(userId);

            return new UserDetailsDTO
            {
                Username = user.Username,
                Email = user.Email,
                SubscriptionId = user.SubscriptionId,  
                ConversionsUsed = user.ConversionsUsed,  
                isAdmin = user.isAdmin,
                isActive = user.isActive
            };
        }
    }
}
