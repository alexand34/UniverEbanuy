using System;
using lab5.Data.IRepository;
using lab5.Data.Models;
using lab5.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<lab8Context>(options =>
                    {
                        options.UseSqlServer(
                            "Server=DESKTOP-TLN6RA2;initial catalog=lab8;integrated security=True;MultipleActiveResultSets=True;");
                    })
                .AddScoped<ICountryRepository, CountryRepository>()
                .AddScoped<ICityRepository, CityRepository>()
                .AddScoped<ICinemaRepository, CinemaRepository>()
                .BuildServiceProvider();

            var cinemaRepo = serviceProvider.GetService<ICinemaRepository>();

            foreach (var cinema in cinemaRepo.Query())
            {
                Console.WriteLine($"{cinema.Name}");
            }

            Console.ReadKey();
        }
    }
}
