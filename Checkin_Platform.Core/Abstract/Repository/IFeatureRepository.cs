using Checkin_Platform.Domain;
using System.Linq;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IFeatureRepository
    {
        IQueryable<Feature> GetFeatures();
        void AddFeature(Feature feature);
    }
}
