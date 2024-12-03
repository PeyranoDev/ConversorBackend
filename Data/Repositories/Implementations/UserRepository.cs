using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly CurrencyAppContext _context;

        public UserRepository(CurrencyAppContext context)
        {
            _context = context;
        }
        public IEnumerable<User> Get()
        {
            return _context.Users.AsEnumerable();
        }

        public User? Get(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User GetForConversions(int userId)
        {
            return _context.Users.Include(u => u.UserSubscription).FirstOrDefault(u => u.Id == userId);
        }
        public User? Get(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }
        public void UpdateUserSubscription(int userId, Subscription subscription)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            user.UserSubscription = subscription;
            user.SubscriptionId = subscription.Id;

            _context.SaveChanges();
        }
        public void Delete(int userId)
        {
            _context.Users.FirstOrDefault(u => u.Id == userId).isActive = false;
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
