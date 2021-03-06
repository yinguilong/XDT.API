﻿using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using XDT.Domain.Repositories;

namespace XDT.Repositories.EntityFramework
{
    public class WareItemDiscussRepository : EntityFrameworkRepository<WareItemDiscuss>, IWareItemDiscussRepository
    {
        public WareItemDiscussRepository(IRepositoryContext context) : base(context)
        {
        }
    }
}
