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
            //var queryBox = EfContext.DbContext.PPBox.Where(x => x.User.Id == userId);
            //var querBoxItem = EfContext.DbContext.PPBoxItem.AsQueryable();
            //var queryItem = EfContext.DbContext.PPismItem.AsQueryable();
            //var queryJoin = from b in queryBox
            //                join i in querBoxItem.DefaultIfEmpty()
            //                on b.Id
            //                equals i.PPBox.Id into queryJ
            //                from q in queryJ.DefaultIfEmpty()
            //                select new
            //                {
            //                    PPBox = b
            //                    //User = b.User
            //                    //PPismItem = q == null ? null : q.PPismItem
            //                };
            //return HideEntityToEntity<PPBoxItem>(queryJoin.ToList());
            var ppBox = EfContext.DbContext.Box.SingleOrDefault(x => x.User.ID == userId);
            var pageList = trend == 0 ? GetAll(
                x => x.Box.ID == ppBox.ID,
                x => x.CreateTime,
                System.Data.SqlClient.SortOrder.Descending,
                pageIndex,
                pageSize
                ) : GetAll(
                x => x.Box.ID == ppBox.ID && x.WareItem.Trend == (DictPriceTrend)trend,
                x => x.CreateTime,
                System.Data.SqlClient.SortOrder.Descending,
                pageIndex,
                pageSize
                );

            //var ppBoxItem = EfContext.DbContext.PPBoxItem.Where(x => x.PPBox.Id == ppBox.Id).OrderByDescending(x => x.CreateTime).Take(pageSize).Skip(pageSize * (pageIndex - 1)).ToList();
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
