﻿using HYM.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Application.Services
{
    public interface IStudentAppService : IDisposable
    {
        void Register(StudentViewModel StudentViewModel);
        IEnumerable<StudentViewModel> GetAll();
        StudentViewModel GetById(Guid id);
        void Update(StudentViewModel StudentViewModel);
        void Remove(Guid id);
        //IList<StudentHistoryData> GetAllHistory(Guid id);
    }
}
