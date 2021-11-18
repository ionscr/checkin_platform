using Checkin_Platform.Domain;
using System.Linq;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        void AddUser(User user);
    }
}
