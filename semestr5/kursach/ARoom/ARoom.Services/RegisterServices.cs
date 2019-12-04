using System;
using System.Collections.Generic;
using System.Text;
using ARoom.Data;
using ARoom.Services.Contracts;
using ARoom.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ARoom.Services
{
    public static class RegisterServices
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IGoodService, GoodsService>();
            services.AddTransient<IWarehouseZonesService, WarehouseZoneService>();
            services.AddTransient<ICategoryService, CategoryService>();
        }
    }
}
