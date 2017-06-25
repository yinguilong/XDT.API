using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;

namespace XDT.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User CheckPassword(string loginAccount, string password);
    }
}
