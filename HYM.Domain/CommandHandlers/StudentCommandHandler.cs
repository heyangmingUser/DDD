using HYM.Domain.Commands;
using HYM.Domain.Core.Bus;
using HYM.Domain.Core.Notifications;
using HYM.Domain.Events;
using HYM.Domain.Interfaces;
using HYM.Domain.Models;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HYM.Domain.CommandHandlers
{

    /// <summary>
    /// Student命令处理程序
    /// 用来处理该Student下的所有命令
    /// 注意必须要继承接口IRequestHandler<,>，这样才能实现各个命令的Handle方法
    /// </summary>
    public class StudentCommandHandler : CommandHandler, IRequestHandler<RegisterStudentCommand, Unit>, IRequestHandler<UpdateStudentCommand, Unit>, IRequestHandler<RemoveStudentCommand, Unit>
    {
        // 注入仓储接口
        private readonly IStudentRepository _studentRepository;
        // 注入总线
        private readonly IMediatorHandler Bus;
        //注入缓存
        private IMemoryCache Cache;
        public StudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork uow, IMediatorHandler bus, IMemoryCache cache) : base(uow, bus,cache)
        {
            _studentRepository = studentRepository;
            Bus = bus;
            Cache = cache;
        }

        /// <summary>
        /// RegisterStudentCommand命令处理程序
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Unit> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            // 命令验证
            if (!request.IsValid())
            {
                // 错误信息收集
                NotifyValidationErrors(request);
                return Task.FromResult(new Unit());
            }

            // 实例化领域模型，这里才真正的用到了领域模型
            // 注意这里是通过构造函数方法实现
            var address = new Address(request.Province, request.City,request.County, request.Street);
            var customer = new Student(Guid.NewGuid(), request.Name, request.Email, request.Phone, request.BirthDate,address);

            // 判断邮箱是否存在
            // 这些业务逻辑，当然要在领域层中（领域命令处理程序中）进行处理
            if (_studentRepository.GetByEmail(customer.Email) != null)
            {
                //这里对错误信息进行发布，目前采用缓存形式
                //List<string> errorInfo = new List<string>() { "The customer e-mail has already been taken." };
                //Cache.Set("ErrorData", errorInfo);
                //return Task.FromResult(new Unit());
                Bus.RaiseEvent(new DomainNotification("", "该邮箱已经被使用！"));
                return Task.FromResult(new Unit());
            }

            // 持久化
            _studentRepository.Add(customer);

            // 统一提交
            if (Commit())
            {
                // 提交成功后，这里需要发布领域事件
                // 比如欢迎用户注册邮件呀，短信呀等

                Bus.RaiseEvent(new StudentRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate, customer.Phone));
            }

            return Task.FromResult(new Unit());

        }

        public Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
