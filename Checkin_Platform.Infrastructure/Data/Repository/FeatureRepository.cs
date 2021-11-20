using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using System.Linq;

namespace Checkin_Platform.Infrastructure.Data.Repository
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly AppDbContext _appDbContext;

        public FeatureRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IQueryable<Feature> GetFeatures()
        {
            return _appDbContext.Feature.OrderBy(c => c.Id);
        }
        public void AddFeature(Feature feature)
        {
            _appDbContext.Feature.Add(feature);
        }
        public void DeleteFeature(Feature feature)
        {
            _appDbContext.Feature.Remove(feature);
        }
        public Feature GetFeatureById(int id)
        {
            return _appDbContext.Feature.FirstOrDefault(c => c.Id == id);
        }
    }
}
