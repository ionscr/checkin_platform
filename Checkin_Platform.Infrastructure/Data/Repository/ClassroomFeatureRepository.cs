using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Checkin_Platform.Infrastructure.Data.Repository
{
    public class ClassroomFeatureRepository : IClassroomFeatureRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClassroomFeatureRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<ClassroomFeature> GetClassroomFeatures()
        {
            return _appDbContext.ClassroomFeature.Include(c => c.Classroom).Include(c => c.Feature).OrderBy(c => c.Id).ToList();
        }
        public void AddClassroomFeature(ClassroomFeature classroomFeature)
        {
            _appDbContext.ClassroomFeature.Add(classroomFeature);
        }
        public void DeleteClassroomFeature(ClassroomFeature classroomFeature)
        {
            _appDbContext.ClassroomFeature.Remove(classroomFeature);
        }
        public ClassroomFeature GetClassroomFeatureById(int id)
        {
            return _appDbContext.ClassroomFeature.FirstOrDefault(c => c.Id == id);
        }
    }
}
