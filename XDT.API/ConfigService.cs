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
        }
    }
}
