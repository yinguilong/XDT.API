using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using XDT.Domain.Model;
using XDT.Domain.Repositories;
using XDT.Infrastructure;

namespace XDT.Repositories.EntityFramework
{
    public class UserRepository : EntityFrameworkRepository<User>, IUserRepository
    {
        public UserRepository(IRepositoryContext context)
            : base(context)
        {
        }
        public User CheckPassword(string loginAccount, string password)
        {
            Expression<Func<User, bool>> userNameExpression = u => u.LoginAccount.Equals(loginAccount);

            var user = GetByExpression(userNameExpression);
            if (user == null)
            {
                return null;
            }
            if (user.Password.Equals(CryptHelper.Encrypto(password)))//密码相同则返回true
            {
                return user;
            }
            return null;
        }

    }
}

