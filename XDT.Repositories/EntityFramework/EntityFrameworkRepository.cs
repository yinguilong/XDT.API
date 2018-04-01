using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using XDT.Domain;
using XDT.Domain.Repositories;
using XDT.Infrastructure;

namespace XDT.Repositories.EntityFramework
{
    public class EntityFrameworkRepository<TAggregateRoot> : IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        private readonly IEntityFrameworkRepositoryContext _efContext;


        public virtual List<TEntity> HideEntityToEntity<TEntity>(IList hideEntityList) where TEntity : class, new()
        {
            if (hideEntityList == null) return null;

            var entityList = new List<TEntity>();
            if (hideEntityList.Count == 0) return entityList;

            entityList.AddRange(
                  from object hideEntity in hideEntityList
                  select HideEntityToEntity<TEntity>(hideEntity)
                );

            return entityList;
        }

        /// <summary>
        /// 匿名类型实体转为实体类（属性名称必须一致）
        /// </summary>
        /// <typeparam name="TEntity">转换类型</typeparam>
        /// <param name="hideEntity">匿名类型</param>
        /// <returns>实体类</returns>
        public virtual TEntity HideEntityToEntity<TEntity>(object hideEntity) where TEntity : class, new()
        {
            if (hideEntity == null) return null;

            var entity = new TEntity();

            var hideType = hideEntity.GetType();
            var entityType = entity.GetType();

            var hidePropertyInfo = hideType.GetProperties();
            //var entityPropertyList = entityType.GetProperties();

            for (int i = 0; i < hidePropertyInfo.Count(); i++)
            {
                var value = hidePropertyInfo[i].GetValue(hideEntity, null);
                entityType.GetProperty(hidePropertyInfo[i].Name).SetValue(entity, value, null);
            }

            return entity;
        }
        protected EntityFrameworkRepository(IRepositoryContext context)
        {
            var efContext = context as IEntityFrameworkRepositoryContext;
            if (efContext != null)
                this._efContext = efContext;
        }

        private MemberExpression GetMemberInfo(LambdaExpression lambda)
        {
            if (lambda == null)
                throw new ArgumentNullException("lambda");

            MemberExpression memberExpr = null;

            switch (lambda.Body.NodeType)
            {
                case ExpressionType.Convert:
                    memberExpr =
                        ((UnaryExpression)lambda.Body).Operand as MemberExpression;
                    break;
                case ExpressionType.MemberAccess:
                    memberExpr = lambda.Body as MemberExpression;
                    break;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr;
        }

        private string GetEagerLoadingPath(Expression<Func<TAggregateRoot, dynamic>> eagerLoadingProperty)
        {
            var memberExpression = this.GetMemberInfo(eagerLoadingProperty);
            var parameterName = eagerLoadingProperty.Parameters.First().Name;
            var memberExpressionStr = memberExpression.ToString();
            var path = memberExpressionStr.Replace(parameterName + ".", "");
            return path;
        }

        protected IEntityFrameworkRepositoryContext EfContext
        {
            get { return this._efContext; }
        }

        public void Add(TAggregateRoot aggregateRoot)
        {
            // 调用IEntityFrameworkRepositoryContext的RegisterNew方法将实体添加进DbContext.DbSet对象中
            _efContext.RegisterNew(aggregateRoot);
        }

        public TAggregateRoot GetByKey(long key)
        {
            return _efContext.DbContext.Set<TAggregateRoot>().First(a => a.ID == key);
        }

        public TAggregateRoot GetByExpression(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return _efContext.DbContext.Set<TAggregateRoot>().FirstOrDefault(expression);
        }

        public IEnumerable<TAggregateRoot> GetAll()
        {
            Expression<Func<TAggregateRoot, bool>> expression = u => true;
            return GetAll(expression, null, SortOrder.Unspecified);
        }
        public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> expression)
        {
            return GetAll(expression, null, SortOrder.Unspecified);
        }

        public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            Expression<Func<TAggregateRoot, bool>> expression = u => true;
            return GetAll(expression, sortPredicate, sortOrder);
        }

        public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> expression, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            var query = _efContext.DbContext.Set<TAggregateRoot>().Where(expression);
            if (sortPredicate != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        return query.SortBy(sortPredicate).ToList();
                        break;
                    case SortOrder.Descending:
                        return query.SortByDescending(sortPredicate).ToList();
                        break;
                    default:
                        break;
                }
            }

            return query.ToList();
        }

        public bool Exists(Expression<Func<TAggregateRoot, bool>> expression)
        {
            var count = _efContext.DbContext.Set<TAggregateRoot>().Count(expression);
            return count != 0;
        }

        public void Remove(TAggregateRoot aggregateRoot)
        {
            _efContext.RegisterDeleted(aggregateRoot);
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            _efContext.RegisterModified(aggregateRoot);
        }

        #region 饥饿加载方式实现
        public TAggregateRoot GetByExpression(Expression<Func<TAggregateRoot, bool>> expression, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            var dbset = _efContext.DbContext.Set<TAggregateRoot>();
            if (eagerLoadingProperties != null &&
                eagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = eagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.Include(eagerLoadingPath);
                for (var i = 1; i < eagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = eagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                return dbquery.Where(expression).FirstOrDefault();
            }
            else
                return dbset.Where(expression).FirstOrDefault();
        }

        //public IEnumerable<TAggregateRoot> GetAll(params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        //{
        //    Expression<Func<TAggregateRoot, bool>> expression = u => true;
        //    return GetAll(expression, null, SortOrder.Unspecified, eagerLoadingProperties);
        //}

        public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            Expression<Func<TAggregateRoot, bool>> expression = u => true;
            return GetAll(expression, sortPredicate, sortOrder, eagerLoadingProperties);
        }


        public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> expression, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            var dbset = _efContext.DbContext.Set<TAggregateRoot>();
            IQueryable<TAggregateRoot> queryable = null;
            if (eagerLoadingProperties != null &&
                eagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = eagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.Include(eagerLoadingPath);
                for (var i = 1; i < eagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = eagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                queryable = dbquery.Where(expression);
            }
            else
                queryable = dbset.Where(expression);

            if (sortPredicate != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        return queryable.SortBy(sortPredicate).ToList();
                    case SortOrder.Descending:
                        return queryable.SortByDescending(sortPredicate).ToList();
                    default:
                        break;
                }
            }
            return queryable.ToList();
        }
        #endregion

        #region 分页支持
        public PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
        {
            Expression<Func<TAggregateRoot, bool>> expression = u => true;

            return GetAll(expression, sortPredicate, sortOrder, pageNumber, pageSize);
        }

        // 分页也就是每次只取出每页展示的数据大小
        public PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> expression, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "页码必须大于等于1");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "每页大小必须大于或等于1");

            var query = _efContext.DbContext.Set<TAggregateRoot>()
                .Where(expression);
            var skip = (pageNumber - 1) * pageSize;
            var take = pageSize;
            if (sortPredicate == null)
                throw new InvalidOperationException("基于分页功能的查询必须指定排序字段和排序顺序。");
            var count = query.Count();
            if (count == 0)
                return null;
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    var pagedGroupAscending = query.SortBy(sortPredicate).Skip(skip).Take(take);
                    if (pagedGroupAscending == null||!pagedGroupAscending.Any())
                        return null;
                    return new PagedResult<TAggregateRoot>(count, (count + pageSize - 1) / pageSize, pageSize, pageNumber, pagedGroupAscending.Select(p => p).ToList());
                case SortOrder.Descending:
                    var pagedGroupDescending = query.SortByDescending(sortPredicate).Skip(skip).Take(take);
                    if (pagedGroupDescending == null||!pagedGroupDescending.Any())
                        return null;
                    return new PagedResult<TAggregateRoot>(count, (count + pageSize - 1) / pageSize, pageSize, pageNumber, pagedGroupDescending.Select(p => p).ToList());
                default:
                    break;
            }

            throw new InvalidOperationException("基于分页功能的查询必须指定排序字段和排序顺序。");
        }

        public PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            Expression<Func<TAggregateRoot, bool>> expression = u => true;
            return GetAll(expression, sortPredicate, sortOrder, pageNumber, pageSize, eagerLoadingProperties);
        }

        public PagedResult<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> expression, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "页码必须大于等于1");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "每页大小必须大于或等于1");

            // 将需要饥饿加载的内容添加到Include方法参数中
            var dbset = _efContext.DbContext.Set<TAggregateRoot>();

            IQueryable<TAggregateRoot> query = null;
            if (eagerLoadingProperties != null &&
                eagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = eagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.Include(eagerLoadingPath);
                for (var i = 1; i < eagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = eagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }

                query = dbquery.Where(expression);
            }
            else
                query = dbset.Where(expression);

            var skip = (pageNumber - 1) * pageSize;
            var take = pageSize;
            var count = query.Count();
            if (count == 0)
                return null;
            if (sortPredicate == null)
                throw new InvalidOperationException("基于分页功能的查询必须指定排序字段和排序顺序。");

            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    var pagedGroupAscending = query.SortBy(sortPredicate).Skip(skip).Take(take);
                    if (pagedGroupAscending == null || !pagedGroupAscending.Any())
                        return null;
                    return new PagedResult<TAggregateRoot>(count, (count + pageSize - 1) / pageSize, pageSize, pageNumber, pagedGroupAscending.Select(p => p).ToList());
                case SortOrder.Descending:
                    var pagedGroupDescending = query.SortByDescending(sortPredicate).Skip(skip).Take(take);
                    if (pagedGroupDescending == null || !pagedGroupDescending.Any())
                        return null;
                    return new PagedResult<TAggregateRoot>(count, (count + pageSize - 1) / pageSize, pageSize, pageNumber, pagedGroupDescending.Select(p => p).ToList());
                default:
                    break;
            }

            throw new InvalidOperationException("基于分页功能的查询必须指定排序字段和排序顺序。");
        }

        #endregion
    }
}
