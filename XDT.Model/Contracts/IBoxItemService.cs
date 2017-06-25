using System;
using System.Collections.Generic;
using System.Text;
using XDT.Infrastructure;
using XDT.Model.DTO;

namespace XDT.Model.Contracts
{
    public interface IBoxItemService
    {
        PagedResult<BoxItemDTO> GetBoxItemsByUserId(long userId, byte trend, int pageIndex, int pageSize);
    }
}
