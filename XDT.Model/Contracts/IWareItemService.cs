using System;
using System.Collections.Generic;
using System.Text;
using XDT.Model.DTO;

namespace XDT.Model.Contracts
{
    public interface IWareItemService
    {
        /// <summary>
        /// 添加收藏商品
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        IList<WareItemDTO> AddBoxItems(List<BoxItemDTO> items);
        /// <summary>
        /// 获取收藏品的价格变化
        /// </summary>
        /// <param name="wareItemId"></param>
        /// <returns></returns>
        IList<PriceItemDTO> GetPriceItemsByWareItem(long wareItemId);
    }
}
