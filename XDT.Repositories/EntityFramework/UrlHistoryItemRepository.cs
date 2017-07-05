using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using XDT.Domain.Repositories;

namespace XDT.Repositories.EntityFramework
{
    public class UrlHistoryItemRepository : EntityFrameworkRepository<UrlHistoryItem>, IUrlHistoryItemRepository
    {
        public UrlHistoryItemRepository(IRepositoryContext context)
            : base(context)
        {
        }
    }
}

