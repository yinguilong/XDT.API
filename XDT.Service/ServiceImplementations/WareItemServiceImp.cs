using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using XDT.Domain.Repositories;
using XDT.Model.Contracts;
using XDT.Model.DTO;
using System.Linq;

namespace XDT.Service.ServiceImplementations
{
  public  class WareItemServiceImp : ApplicationService, IWareItemService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWareItemRepository _wareItemRepository;
        private readonly IBoxItemRepository _boxItemRepository;
        private readonly IUrlHistoryItemRepository _urlHistoryItemRepository;
        private readonly IPriceItemRepository
            _priceItemRepository;
        //private readonly IDomainService _domainService;
        public WareItemServiceImp(IRepositoryContext repositoryContext,
            IUserRepository userRepository, IWareItemRepository ppismItemRepository, IBoxItemRepository ppboxItemRepository, IUrlHistoryItemRepository urlHistoryItemRepository, IPriceItemRepository priceItemRepository)
            : base(repositoryContext)
        {
            _userRepository = userRepository;
            _wareItemRepository = ppismItemRepository;
            _boxItemRepository = ppboxItemRepository;
            _urlHistoryItemRepository = urlHistoryItemRepository;
            _priceItemRepository = priceItemRepository;
        }
        #region IPPismItemService members
        public IList<WareItemDTO> AddBoxItems(List<BoxItemDTO> items)
        {

            var listInsert = new List<WareItemDTO>();
            //验证数据
            var count = items.Count;
            var userId = 0L;
            for (int i = 0; i < count; i++)
            {
                var item = items[i];

                if (item.UserId>0 && !string.IsNullOrEmpty(item.ListenUrl))
                {
                    userId = item.UserId;
                    var wareItemDto = new WareItemDTO()
                    {
                        Description = item.Description,
                        ItemName = item.ItemName,
                        ListenUrl = item.ListenUrl
                    };
                    listInsert.Add(wareItemDto);
                }
            }
            var ppismItemList = PerformCreateObjects<List<WareItemDTO>, WareItemDTO, WareItem>(listInsert, _wareItemRepository,
               null,
                ar =>
                {
                    ar.Operator = _userRepository.GetByKey(userId);
                    var ppboxitem = ar.CreateBoxItem(userId);
                    _boxItemRepository.Add(ppboxitem);
                    ar.BoxItem = ppboxitem;
                    var urlHistory = ar.CreateHistoryUrl();
                    _urlHistoryItemRepository.Add(urlHistory);
                    ar.Init();
                });
            return ppismItemList;
        }
        public IList<PriceItemDTO> GetPriceItemsByWareItem(long wareItemId)
        {
          
            var list = _priceItemRepository.GetAll(
                x => x.WareItem.ID == wareItemId,
                x => x.UpdateTime,
                System.Data.SqlClient.SortOrder.Ascending)
                .ToList();
            var listRet = new List<PriceItemDTO>();
            list.ForEach(x =>
            {
                listRet.Add(AutoMapper.Mapper.Map<PriceItemDTO>(x));
            });
            return listRet;
        }
        #endregion
    }
}

