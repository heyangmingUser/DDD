using AutoMapper;
using HYM.Application.ViewModels;
using HYM.Domain.Commands;
using HYM.Domain.Core.Bus;
using HYM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Application.Services
{
    public class StudentAppService : IStudentAppService
    {
        //注意这里是要IoC依赖注入的，还没有实现
        private readonly IStudentRepository _StudentRepository;
        //用来进行DTO
        private readonly IMapper _mapper;
        //中介者 总线
        private readonly IMediatorHandler Bus;

        public StudentAppService(IStudentRepository StudentRepository, IMediatorHandler bus,IMapper mapper) 
        {
            _StudentRepository = StudentRepository;
            _mapper = mapper;
            Bus = bus;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        //public IList<StudentHistoryData> GetAllHistory(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public StudentViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Register(StudentViewModel StudentViewModel)
        {
            var registerCommand = _mapper.Map<RegisterStudentCommand>(StudentViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentViewModel StudentViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
