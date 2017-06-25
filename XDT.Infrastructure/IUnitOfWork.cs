using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
