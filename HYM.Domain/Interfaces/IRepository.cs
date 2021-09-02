using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HYM.Domain.Interfaces
{
    /// <summary>
    /// 基础接口，定义泛型仓储接口，并继承IDisposable，显式释放资源
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="obj"></param>
        void Add(T obj);
        /// <summary>
        /// 根据id获取对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(Guid id);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();
        /// <summary>
        /// 根据对象进行更新
        /// </summary>
        /// <param name="obj"></param>
        void Update(T obj);
        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        void Remove(Guid id);
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
