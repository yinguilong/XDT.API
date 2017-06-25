using System;
using System.Collections.Generic;
using System.Text;
using XDT.Infrastructure;

namespace XDT.Domain.Repositories
{
    public interface IRepositoryContext : IUnitOfWork
    {
        // 用来标识仓储上下文
        Guid Id { get; }

        void RegisterNew<TAggregateRoot>(TAggregateRoot entity)
            where TAggregateRoot : class, IAggregateRoot;

        void RegisterModified<TAggregateRoot>(TAggregateRoot entity)
            where TAggregateRoot : class, IAggregateRoot;

        void RegisterDeleted<TAggregateRoot>(TAggregateRoot entity)
            where TAggregateRoot : class, IAggregateRoot;
    }
}
