using Checkin_Platform.Core.Abstract;
using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Infrastructure.Data.Repository;

namespace Checkin_Platform.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;
        private IClassRepository _classRepository;
        private IClassroomRepository _classroomRepository;
        private IClassroomFeatureRepository _classroomFeatureRepository;
        private IFeatureRepository _featureRepository;
        private IScheduleRepository _scheduleRepository;
        private IUserRepository _userRepository;
        private IUserScheduleRepository _userScheduleRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IClassRepository ClassRepository 
        { 
            get 
            {
                if (_classRepository == null) 
                {
                    _classRepository = new ClassRepository(_appDbContext);
                }
                return _classRepository;
            }
            set
            {
                _classRepository = value;
            }
        }
        public IClassroomRepository ClassroomRepository
        {
            get
            {
                if (_classroomRepository == null)
                {
                    _classroomRepository = new ClassroomRepository(_appDbContext);
                }
                return _classroomRepository;
            }
            set
            {
                _classroomRepository = value;
            }
        }
        public IClassroomFeatureRepository ClassroomFeatureRepository
        {
            get
            {
                if (_classroomFeatureRepository == null)
                {
                    _classroomFeatureRepository = new ClassroomFeatureRepository(_appDbContext);
                }
                return _classroomFeatureRepository;
            }
            set
            {
                _classroomFeatureRepository = value;
            }
        }
        public IFeatureRepository FeatureRepository
        {
            get
            {
                if (_featureRepository == null)
                {
                    _featureRepository = new FeatureRepository(_appDbContext);
                }
                return _featureRepository;
            }
            set
            {
                _featureRepository = value;
            }
        }
        public IScheduleRepository ScheduleRepository
        {
            get
            {
                if (_scheduleRepository == null)
                {
                    _scheduleRepository = new ScheduleRepository(_appDbContext);
                }
                return _scheduleRepository;
            }
            set
            {
                _scheduleRepository = value;
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_appDbContext);
                }
                return _userRepository;
            }
            set
            {
                _userRepository = value;
            }
        }
        public IUserScheduleRepository UserScheduleRepository
        {
            get
            {
                if (_userScheduleRepository == null)
                {
                    _userScheduleRepository = new UserScheduleRepository(_appDbContext);
                }
                return _userScheduleRepository;
            }
            set
            {
                _userScheduleRepository = value;
            }
        }
        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
