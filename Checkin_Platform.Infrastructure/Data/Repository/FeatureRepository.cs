using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public IEnumerable<Feature> GetFeatures()
        {
            return _appDbContext.Feature.OrderBy(c => c.Id).ToList();
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
        public IEnumerable<Feature> GetFeaturesByClassroom(int classroomId)
        {
            return _appDbContext.Feature.Include(f => f.ClassroomFeatures).Where(f => f.ClassroomFeatures.Any(cf => cf.ClassroomId == classroomId)).ToList(); 
        }
        public IEnumerable<Feature> GetOtherFeaturesByClassroom(int classroomId)
        {
            //Select f.Id, f.Name from Feature f left join ClassroomFeature cf on f.Id = cf.FeatureId where cf.ClassroomId != 13 or cf.ClassroomId is null;
            var query = (from f in _appDbContext.Feature
                        from cf in f.ClassroomFeatures.DefaultIfEmpty()
                        where cf.ClassroomId != classroomId
                        select new Feature{Id = f.Id , Name = f.Name}).ToList();
            return query;
        }
        public Feature UpdateFeature(Feature feature)
        {
            Feature updatedFeature = _appDbContext.Feature.FirstOrDefault(c => c.Id == feature.Id);
            updatedFeature = feature;
            return updatedFeature;
        }
    }
}
