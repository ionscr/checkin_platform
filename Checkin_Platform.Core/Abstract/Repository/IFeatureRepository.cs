using Checkin_Platform.Domain;
using System.Linq;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IFeatureRepository
    {
        IQueryable<Feature> GetFeatures();
        void AddFeature(Feature feature);
        Feature GetFeatureById(int id);
        void DeleteFeature(Feature feature);
        IQueryable<Feature> GetFeaturesByClassroom(int classroomId);
        Feature UpdateFeature(Feature feature);
    }
}
