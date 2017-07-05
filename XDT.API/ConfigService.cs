using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XDT.Domain.Repositories;
using XDT.Model.Contracts;
using XDT.Repositories.EntityFramework;
using XDT.Service.ServiceImplementations;

namespace XDT.API
{
    public class ConfigService
    {
        public static void Init(IServiceCollection services)
        {
            services.AddSingleton(typeof(IRepositoryContext), typeof(EntityFrameworkRepositoryContext));
            services.AddSingleton(typeof(IUserRepository), typeof(UserRepository));
            services.AddSingleton(typeof(IUserService), typeof(UserServiceImp));
            services.AddSingleton(typeof(IBoxItemService), typeof(BoxItemServiceImp));
            services.AddSingleton(typeof(IWareItemService), typeof(WareItemServiceImp));
            services.AddSingleton(typeof(IUrlHistoryItemRepository), typeof(UrlHistoryItemRepository));
            services.AddSingleton(typeof(IUserAdviceRepository), typeof(UserAdviceRepository));
            services.AddSingleton(typeof(IPriceItemRepository), typeof(PriceItemRepository));
            services.AddSingleton(typeof(IBoxRepository), typeof(BoxRepository));
            services.AddSingleton(typeof(IWareItemDiscussRepository), typeof(WareItemDiscussRepository));
            services.AddSingleton(typeof(IWareItemRepository), typeof(WareItemRepository));
            services.AddSingleton(typeof(INoticeMessageRepository), typeof(BoxItemRepository));
            services.AddSingleton(typeof(INoticeMessageRepository), typeof(NoticeMessageRepository));
        }
    }
}
