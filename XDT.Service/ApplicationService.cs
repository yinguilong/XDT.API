using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain;
using XDT.Domain.Repositories;

namespace XDT.Service
{
    public class ApplicationService
    {
        private readonly IRepositoryContext _repositoryContext;

        protected ApplicationService(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        protected IRepositoryContext RepositorytContext
        {
            get { return this._repositoryContext; }
        }

        #region Protected Methods

        // 判断给定字符串是否是Guid.Empty
        protected bool IsEmptyGuidString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return true;
            var guid = new Guid(s);
            return guid == Guid.Empty;
        }


        // 处理简单的聚合创建逻辑。
        protected TDtoList PerformCreateObjects<TDtoList, TDto, TAggregateRoot>(TDtoList dataTransferObjects,
            IRepository<TAggregateRoot> repository,
            Action<TDto> processDto = null,
            Action<TAggregateRoot> processAggregateRoot = null)
            where TDtoList : List<TDto>, new()
            where TAggregateRoot : class, IAggregateRoot
        {
            if (dataTransferObjects == null)
                throw new ArgumentNullException("dataTransferObjects");
            if (repository == null)
                throw new ArgumentNullException("repository");
            TDtoList result = new TDtoList();
            if (dataTransferObjects.Count <= 0) return result;
            var ars = new List<TAggregateRoot>();

            foreach (var dto in dataTransferObjects)
            {
                if (processDto != null)
                    processDto(dto);
                var ar = Mapper.Map<TDto, TAggregateRoot>(dto);
                if (processAggregateRoot != null)
                    processAggregateRoot(ar);
                ars.Add(ar);
                repository.Add(ar);
            }

            RepositorytContext.Commit();
            ars.ForEach(ar => result.Add(Mapper.Map<TAggregateRoot, TDto>(ar)));
            return result;
        }

        // 处理简单的聚合更新操作。
        protected TDtoList PerformUpdateObjects<TDtoList, TDataObject, TAggregateRoot>(TDtoList dataTransferObjects,
            IRepository<TAggregateRoot> repository,
            Func<TDataObject, long> idFunc,
            Action<TAggregateRoot, TDataObject> updateAction)
            where TDtoList : List<TDataObject>, new()
            where TAggregateRoot : class, IAggregateRoot
        {
            if (dataTransferObjects == null)
                throw new ArgumentNullException("dataTransferObjects");
            if (repository == null)
                throw new ArgumentNullException("repository");
            if (idFunc == null)
                throw new ArgumentNullException("idFunc");
            if (updateAction == null)
                throw new ArgumentNullException("updateAction");
            TDtoList result = null;
            if (dataTransferObjects.Count > 0)
            {
                result = new TDtoList();
                foreach (var dto in dataTransferObjects)
                {
                    if (idFunc(dto)<=0)
                        throw new ArgumentNullException("Id");
                    var id = idFunc(dto);
                    var ar = repository.GetByKey(id);
                    updateAction(ar, dto);
                    repository.Update(ar);
                    result.Add(Mapper.Map<TAggregateRoot, TDataObject>(ar));
                }

                RepositorytContext.Commit();
            }
            return result;
        }

        // 处理简单的删除聚合根的操作。
        protected void PerformDeleteObjects<TAggregateRoot>(IList<long> ids, IRepository<TAggregateRoot> repository, Action<long> preDelete = null, Action<long> postDelete = null)
            where TAggregateRoot : class, IAggregateRoot
        {
            if (ids == null)
                throw new ArgumentNullException("ids");
            if (repository == null)
                throw new ArgumentNullException("repository");
            foreach (var id in ids)
            {
                if (preDelete != null)
                    preDelete(id);
                var ar = repository.GetByKey(id);
                repository.Remove(ar);
                if (postDelete != null)
                    postDelete(id);
            }

            RepositorytContext.Commit();
        }

        #endregion
    }
}