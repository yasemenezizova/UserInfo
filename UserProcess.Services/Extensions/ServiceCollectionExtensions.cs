using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProcess.Data.Abstract;
using UserProcess.Data.Concrete;
using UserProcess.Data.Concrete.Contexts;
using UserProcess.Services.Abstract;
using UserProcess.Services.Concrete;

namespace UserProcess.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<UserProcessContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IPersonService, PersonManager>();
            serviceCollection.AddScoped<IAddressService, AddressManager>();
            return serviceCollection;
        }
    }
}
