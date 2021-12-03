﻿using Checkin_Platform.Domain;
using System.Collections.Generic;

namespace Checkin_Platform.Core.Abstract.Repository
{
    public interface IClassroomFeatureRepository
    {
        IEnumerable<ClassroomFeature> GetClassroomFeatures();
        void AddClassroomFeature(ClassroomFeature classroomFeature);
        ClassroomFeature GetClassroomFeatureById(int id);
        void DeleteClassroomFeature(ClassroomFeature classroomFeature);
        
    }
}
