using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using Microsoft.EntityFrameworkCore;

namespace Checkin_Platform.Core.Abstract
{
    public interface IUnitOfWork
    {
        IClassRepository ClassRepository { get; set; }
        IClassroomRepository ClassroomRepository { get; set; }
        IClassroomFeatureRepository ClassroomFeatureRepository { get; set; }
        IFeatureRepository FeatureRepository { get; set; }
        IScheduleRepository ScheduleRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IUserScheduleRepository UserScheduleRepository { get; set; }
        void SaveChanges();

    }
}
