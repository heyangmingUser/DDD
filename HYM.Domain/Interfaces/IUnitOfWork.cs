using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 是否提交成功
        /// </summary>
        /// <returns></returns>
        bool Commit();
    }
}
