using Checkin_Platform.Domain;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Abstract
{
    public interface IUnitOfWork
    {
        public IList<User> User { get; set; }
        public IList<Class> Class { get; set; }

    }
}
