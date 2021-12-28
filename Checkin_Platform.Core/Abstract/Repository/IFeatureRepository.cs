using Checkin_Platform.Domain;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IFeatureRepository
    {
        IEnumerable<Feature> GetFeatures();
        void AddFeature(Feature feature);
        Feature GetFeatureById(int id);
        void DeleteFeature(Feature feature);
        IEnumerable<Feature> GetFeaturesByClassroom(int classroomId);
        IEnumerable<Feature> GetOtherFeaturesByClassroom(int classroomId);
        Feature UpdateFeature(Feature feature);
    }
}
