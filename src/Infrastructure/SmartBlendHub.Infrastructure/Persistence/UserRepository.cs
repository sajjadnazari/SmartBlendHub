using SmartBlendHub.Application.Common.Interfaces.Persistence;
using SmartBlendHub.Domain.Entities;

namespace SmartBlendHub.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static List<User> users = new List<User>();
        public void Add(User user)
        {
            users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return users.SingleOrDefault(el => el.Email == email);
        }
    }
}
