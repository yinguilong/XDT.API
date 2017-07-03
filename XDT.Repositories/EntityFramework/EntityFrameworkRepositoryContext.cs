using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using XDT.Domain.Repositories;
using XDT.Infrastructure;

namespace XDT.Repositories.EntityFramework
{
    public class EntityFrameworkRepositoryContext : IEntityFrameworkRepositoryContext
    {
        // ThreadLocal代表线程本地存储，主要相当于一个静态变量
        // 但静态变量在多线程访问时需要显式使用线程同步技术。
        // 使用ThreadLocal变量，每个线程都会一个拷贝，从而避免了线程同步带来的性能开销

        private readonly ThreadLocal<XDTDbContext> _localCtx = new ThreadLocal<XDTDbContext>(() => { return (XDTDbContext)ServiceLocator.Instance.GetService(typeof(XDTDbContext)); });
        public XDTDbContext DbContext
        {
            get { return _localCtx.Value; }
        }

        private readonly Guid _id = Guid.NewGuid();

        #region IRepositoryContext Members
        public Guid Id
        {
            get { return _id; }
        }

        public void RegisterNew<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, Domain.IAggregateRoot
        {
            _localCtx.Value.Set<TAggregateRoot>().Add(entity);
        }

        public void RegisterModified<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, Domain.IAggregateRoot
        {
            _localCtx.Value.Entry<TAggregateRoot>(entity).State = EntityState.Modified;
        }

        public void RegisterDeleted<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, Domain.IAggregateRoot
        {
            _localCtx.Value.Set<TAggregateRoot>().Remove(entity);
        }

        #endregion

        #region IUnitOfWork Members
        public void Commit()
        {
            //var validationError = _localCtx.Value.GetValidationErrors();
            _localCtx.Value.SaveChanges();
        }
        #endregion
    }
}
