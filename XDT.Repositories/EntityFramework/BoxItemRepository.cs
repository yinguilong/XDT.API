using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XDT.Domain.Model;
using XDT.Domain.Repositories;
using XDT.Infrastructure;
using XDT.Model.Enums;

namespace XDT.Repositories.EntityFramework
{
    public class BoxItemRepository : EntityFrameworkRepository<BoxItem>, IBoxItemRepository
    {
        public BoxItemRepository(IRepositoryContext context) : base(context)
        {
        }
        public PagedResult<BoxItem> GetBoxItemsByUserId(long userId, byte trend, int pageIndex, int pageSize)
        {
            var ppBox = EfContext.DbContext.Box.SingleOrDefault(x => x.User.ID == userId);
            var pageList = trend == 0 ? GetAll(
                x => x.Box.ID == ppBox.ID,
                x => x.CreateTime,
                System.Data.SqlClient.SortOrder.Descending,
                pageIndex,
                pageSize,
                x=>x.WareItem,x=>x.Box.User
                ) : GetAll(
                x => x.Box.ID == ppBox.ID && x.WareItem.Trend == (DictPriceTrend)trend,
                x => x.CreateTime,
                System.Data.SqlClient.SortOrder.Descending,
                pageIndex,
                pageSize,
                x=>x.WareItem, x => x.Box.User
                );
            if (pageList != null && pageList.Any())
            {
                var listIds = pageList.PageData.Select(x => x.WareItem.ID).ToList();
                var ppismItems = EfContext.DbContext.WareItem.Where(x => listIds.Contains(x.ID)).ToList();
                if (ppismItems != null && ppismItems.Any())
                {
                    pageList.PageData.ForEach(x =>
                    {
                        var ppism = ppismItems.SingleOrDefault(o => o.ID == x.WareItem.ID);
                        if (ppism != null) x.WareItem = ppism;
                    });
                }
            }
            return pageList;
        }
    }
}
