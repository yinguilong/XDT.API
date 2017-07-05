using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using XDT.Domain.Repositories;

namespace XDT.Repositories.EntityFramework
{
    public class PriceItemRepository : EntityFrameworkRepository<PriceItem>, IPriceItemRepository
    {
        public PriceItemRepository(IRepositoryContext context)
            : base(context)
        {
        }
    }
}

