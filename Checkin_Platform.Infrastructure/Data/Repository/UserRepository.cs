using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using System.Linq;

namespace Checkin_Platform.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IQueryable<User> GetUsers()
        {
            return _appDbContext.User.OrderBy(c => c.Id);
        }
        public void AddUser(User user)
        {
            _appDbContext.User.Add(user);
        }
    }
}
