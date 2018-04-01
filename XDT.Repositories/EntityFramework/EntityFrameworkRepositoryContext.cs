using Microsoft.AspNetCore.Http;
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

        public XDTDbContext DbContext
        {
            get
            {
                object factory = ServiceLocator.Instance.GetService(serviceType: typeof(Microsoft.AspNetCore.Http.IHttpContextAccessor));
                HttpContext context = ((IHttpContextAccessor)factory).HttpContext;
                return (XDTDbContext)context.RequestServices.GetService(typeof(XDTDbContext));
            }
        }

        private IServiceProvider sp { get; set; }

        //private readonly ThreadLocal<XDTDbContext> _localCtx
        //    = new ThreadLocal<XDTDbContext>(() =>
        //    {
        //        object factory = ServiceLocator.Instance.GetService(serviceType: typeof(Microsoft.AspNetCore.Http.IHttpContextAccessor));

        //        HttpContext context = ((IHttpContextAccessor)factory).HttpContext;
        //        return (XDTDbContext)context.RequestServices.GetService(typeof(XDTDbContext));
        //        //return (XDTDbContext)ServiceLocator.Instance.GetService(typeof(XDTDbContext));
        //    });

        private readonly Guid _id = Guid.NewGuid();

        #region IRepositoryContext Members
        public Guid Id
        {
            get { return _id; }
        }

        public void RegisterNew<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, Domain.IAggregateRoot
        {
            DbContext.Set<TAggregateRoot>().Add(entity);
        }

        public void RegisterModified<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, Domain.IAggregateRoot
        {
            DbContext.Entry<TAggregateRoot>(entity).State = EntityState.Modified;
        }

        public void RegisterDeleted<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, Domain.IAggregateRoot
        {
            DbContext.Set<TAggregateRoot>().Remove(entity);
        }

        #endregion

        #region IUnitOfWork Members
        public void Commit()
        {
            //var validationError = _localCtx.Value.GetValidationErrors();
            DbContext.SaveChanges();
        }
        #endregion
    }
}
