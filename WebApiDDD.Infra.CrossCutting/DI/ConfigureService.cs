using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDDD.Domain.Interfaces;
using WebApiDDD.Infra.Data.Context;
using WebApiDDD.Infra.Data.Repository;
using WebApiDDD.Service.Services;

namespace WebApiDDD.Infra.CrossCutting.DI
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
        }
        public static void ConfigureDbCOntext(this IServiceCollection serviceCollection, string conn)
        {
            serviceCollection.AddDbContext<MyContext>(
             options => options.UseSqlServer(conn)
         );
        }
}
}
