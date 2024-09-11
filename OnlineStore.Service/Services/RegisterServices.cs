using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Services
{
    public static class RegisterServices
    {
        public static void AddRegisterServices(IServiceCollection serivce)
        {
            serivce.AddScoped<IUnitOfWork, UnitOfWork>();
            serivce.AddScoped<ICategoryServices, CategoryServices>();
            
        }
    }
}
