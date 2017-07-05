using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using XDT.Domain.Repositories;

namespace XDT.Repositories.EntityFramework
{
    public class BoxRepository : EntityFrameworkRepository<Box>, IBoxRepository
    {
        public BoxRepository(IRepositoryContext context) : base(context)
        {
        }
    }
}
