using HYM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Domain.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        /// <summary>
        /// student独有的接口
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Student GetByEmail(string email);
    }
}
