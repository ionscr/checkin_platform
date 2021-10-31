using Checkin_Platform.Domain;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Abstract
{
    public interface IUnitOfWork
    {
        public IList<User> User { get; set; }
        public IList<Class> Class { get; set; }
        public IList<Classroom> Classroom { get; set; }
        public IList<Schedule> Schedule { get; set; }
        public IList<Feature> Feature { get; set; }
        public IList<ClassroomFeature> ClassroomFeature { get; set; }
        public IList<ScheduleReservation> ScheduleReservation { get; set; }

    }
}
