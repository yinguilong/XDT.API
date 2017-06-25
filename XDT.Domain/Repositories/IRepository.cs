using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using XDT.Infrastructure;

namespace XDT.Domain.Repositories
{
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        #region Methods
        void Add(TAggregateRoot aggregateRoot);

        // 根据聚合根的ID值，从仓储中读取聚合根
        TAggregateRoot GetByKey(long key);

        TAggregateRoot GetByExpression(Expression<Func<TAggregateRoot, bool>> expression);

        // 读取所有聚合根。
        IEnumerable<TAggregateRoot> GetAll();

        // 以指定的排序字段和排序方式，从仓储中读取所有聚合根。
        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);
        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> expression);
        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> expression, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);

        void Remove(TAggregateRoot aggregateRoot);

        void Update(TAggregateRoot aggregateRoot);

        #region 分页支持

        PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageNumber, int pageSize);



        PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate,
            SortOrder sortOrder, int pageNumber, int pageSize,
            params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        #endregion
        #endregion
        #region 饥饿加载方式

        //IEnumerable<TAggregateRoot> GetAll(params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        #endregion
    }
}
