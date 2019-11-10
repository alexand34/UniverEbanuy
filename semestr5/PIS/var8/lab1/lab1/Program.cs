using lab1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (lab8Entities ctx = new lab8Entities())
            {
                Console.WriteLine("Countries and cities");
                foreach(var country in ctx.Countries)
                {
                    Console.WriteLine($"Country: {country.Name}. \n Citiies");
                    foreach(var city in country.Cities)
                    {
                        Console.WriteLine($"\t • [{city.Id}] - {city.Name}");
                    }
                }

                Console.WriteLine("Enter city id to see cinemas there: ");

                var id = Console.ReadLine();
                int.TryParse(id, out var cityId);

                var cityN = ctx.Cities.FirstOrDefault(x => x.Id == cityId);

                Console.WriteLine($"You have chosen: {cityN.Name}");

                foreach(var cinema in cityN.Cinemas)
                {
                    Console.WriteLine($"\t • {cinema.Name}");
                }

                Console.WriteLine("\n\n\n");
                var cities = ctx.Cities.ToList();
                var randomNumber = random.Next(cities.Count());
                
                var randomCity = cities[randomNumber];
                var cinemaN = new Cinema()
                {
                    CityId = randomCity.Id,
                    Name = RandomString(random.Next(5, 15))
                };

                Console.WriteLine("\n\n\nWill add random cinema to random city: " +
                    $"\n cinema name: {cinemaN.Name} \n city: {randomCity.Name}");
                ctx.Cinemas.Add(cinemaN);
                ctx.SaveChanges();

                Console.WriteLine($"Cinemas from city {randomCity.Name}");
                foreach(var cin in ctx.Cinemas.Where(x => x.CityId == randomCity.Id))
                {
                    Console.WriteLine($"\t• {cin.Name}");
                }

                var newRandomName = RandomString(cinemaN.Name.Length);
                Console.WriteLine($"Rename random cinema {cinemaN.Name} to {newRandomName}");
                cinemaN.Name = newRandomName;
                ctx.SaveChanges();

                Console.WriteLine($"Cinemas from city {randomCity.Name}");
                foreach (var cin in ctx.Cinemas.Where(x => x.CityId == randomCity.Id))
                {
                    Console.WriteLine($"\t• {cin.Name}");
                }

                Console.WriteLine($"Deleting random cinema - {cinemaN.Name}");
                ctx.Cinemas.Remove(cinemaN);
                ctx.SaveChanges();

                Console.WriteLine($"Cinemas from city {randomCity.Name}");
                foreach (var cin in ctx.Cinemas.Where(x => x.CityId == randomCity.Id))
                {
                    Console.WriteLine($"\t• {cin.Name}");
                }


            }

            Console.ReadKey();
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
