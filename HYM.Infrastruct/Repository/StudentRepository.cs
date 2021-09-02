using HYM.Domain.Interfaces;
using HYM.Domain.Models;
using HYM.Infrastruct.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HYM.Infrastruct.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {

        public StudentRepository(StudyContext context):base(context)
        {
            
        }
        public Student GetByEmail(string email)
        {
            return _db.Students.FirstOrDefault(r => r.Email == email);
        }
    }
}
