using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Services
{
    public static class RegisterServices
    {
        public static void AddRegisterServices(IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<ICategoryServices, CategoryServices>();
            service.AddScoped<IUserService,UserServices>();
            service.AddScoped<IRoleService,RoleServices>();
            service.AddScoped<IOwnerService,OwnerService>();
            service.AddScoped<IDiscountService, DiscountService>();
        }
    }
}
