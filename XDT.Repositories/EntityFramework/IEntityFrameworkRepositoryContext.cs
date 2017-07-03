using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Repositories;

namespace XDT.Repositories.EntityFramework
{
    public interface IEntityFrameworkRepositoryContext : IRepositoryContext
    {
        #region Properties
        XDTDbContext DbContext { get; }
        #endregion
    }
}
