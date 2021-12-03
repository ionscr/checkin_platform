﻿using Checkin_Platform.Core.Abstract.Repository;
using Checkin_Platform.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Checkin_Platform.Infrastructure.Data.Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClassroomRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Classroom> GetClassrooms()
        {
            return _appDbContext.Classroom.OrderBy(c => c.Id).ToList();
        }
        public void AddClassroom(Classroom classroom)
        {
            _appDbContext.Classroom.Add(classroom);
        }
        public void DeleteClassroom(Classroom classroom)
        {
            _appDbContext.Classroom.Remove(classroom);
        }
        public Classroom GetClassroomById(int id)
        {
            return _appDbContext.Classroom.FirstOrDefault(c => c.Id == id);
        }
        public Classroom UpdateClassroom(Classroom classroom)
        {
            Classroom updatedClassroom = _appDbContext.Classroom.FirstOrDefault(c => c.Id == classroom.Id);
            updatedClassroom = classroom;
            return updatedClassroom;
        }
    }
}
