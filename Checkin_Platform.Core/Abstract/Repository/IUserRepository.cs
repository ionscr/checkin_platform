using Checkin_Platform.Domain;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        void AddUser(User user);
        User GetUserById(int id);
        void DeleteUser(User user);
        User UpdateUser(User user);
    }
}
