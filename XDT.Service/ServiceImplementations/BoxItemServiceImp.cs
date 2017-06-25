using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Repositories;
using XDT.Infrastructure;
using XDT.Model.Contracts;
using XDT.Model.DTO;
using System.Linq;

namespace XDT.Service.ServiceImplementations
{
    /// <summary>
    /// 收藏盒子具体服务类
    /// </summary>
    public class BoxItemServiceImp : ApplicationService, IBoxItemService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWareItemRepository _wareItemRepository;
        private readonly IBoxItemRepository _boxItemRepository;
        public BoxItemServiceImp(IRepositoryContext repositoryContext,
            IUserRepository userRepository, IWareItemRepository ppismItemRepository, IBoxItemRepository ppBoxItemRepository)
            : base(repositoryContext)
        {
            _userRepository = userRepository;
            _wareItemRepository = ppismItemRepository;
            _boxItemRepository = ppBoxItemRepository;
        }
        #region IPPBoxItemService Members
        public PagedResult<BoxItemDTO> GetBoxItemsByUserId(long userId, byte trend, int pageIndex, int pageSize)
        {
            var pageList = _boxItemRepository.GetBoxItemsByUserId(userId, trend, pageIndex, pageSize);

            if (pageList != null && pageList.Any())
            {
                var listDtos = new List<BoxItemDTO>();
                pageList.PageData.ForEach(x => listDtos.Add(AutoMapper.Mapper.Map<BoxItemDTO>(x)));
                var listRet = new PagedResult<BoxItemDTO>(pageList.TotalRecords, pageList.TotalPages, pageSize, pageIndex, listDtos);
                return listRet;
            }
            return null;
        }

        #endregion
    }
}

