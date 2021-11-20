using Checkin_Platform.Domain;
using System.Linq;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IClassroomFeatureRepository
    {
        IQueryable<ClassroomFeature> GetClassroomFeatures();
        void AddClassroomFeature(ClassroomFeature classroomFeature);
        ClassroomFeature GetClassroomFeatureById(int id);
        void DeleteClassroomFeature(ClassroomFeature classroomFeature);
    }
}
