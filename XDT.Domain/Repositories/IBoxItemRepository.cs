using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using XDT.Infrastructure;

namespace XDT.Domain.Repositories
{
    public interface IBoxItemRepository : IRepository<BoxItem>
    {
        PagedResult<BoxItem> GetBoxItemsByUserId(long userId, byte trend, int pageIndex, int pageSize);
    }
}
