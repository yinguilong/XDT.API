using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using XDT.Domain.Repositories;

namespace XDT.Repositories.EntityFramework
{
    public class UserAdviceRepository : EntityFrameworkRepository<UserAdvice>, IUserAdviceRepository
    {
        public UserAdviceRepository(IRepositoryContext context) : base(context)
        { }
    }
}

