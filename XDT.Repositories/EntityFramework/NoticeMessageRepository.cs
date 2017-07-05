using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using XDT.Domain.Repositories;

namespace XDT.Repositories.EntityFramework
{
    public class NoticeMessageRepository : EntityFrameworkRepository<NoticeMessage>, INoticeMessageRepository
    {
        public NoticeMessageRepository(IRepositoryContext context) : base(context)
        { }
    }
}

