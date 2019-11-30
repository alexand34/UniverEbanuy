using System;
using System.Collections.Generic;
using System.Text;
using ARoom.Data.IRepository;
using ARoom.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ARoom.Data
{
    public static class ConfigureServices
    {
        public static void ConfigureRepositories(this IServiceCollection service)
        {
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IGoodsRepository, GoodsRepository>();
            service.AddScoped<IRoleRepository, RoleRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IWarehouseZoneRepository, WarehouseZoneRepository>();
        }
    }
}
