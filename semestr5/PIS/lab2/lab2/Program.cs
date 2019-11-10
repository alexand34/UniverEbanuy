using lab2.DataAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            CountriesDataAdapter cda = new CountriesDataAdapter();

            Console.WriteLine("Countries");
            var countries = cda.GetData();
            foreach (var country in countries)
            {
                Console.WriteLine($"[{country.Id}] {country.Name}");
            }

            int randomNum = random.Next(3, 5);

            var lastId = countries.Last().Id;
            for (int i = 0; i < randomNum; i++)
            {
                lastId += 1;
                cda.InsertData(lastId, RandomString(random.Next(5, 15)) + " - randomed new");
            }

            randomNum = random.Next(2, 3);

            for (int i = 0; i < randomNum; i++)
            {
                int rand = random.Next(countries.Count);
                var countryId = countries[rand].Id;

                cda.UpdateData(countryId, RandomString(random.Next(5, 15)) + " - randomed updated");
            }

            for (int i = 0; i < 2; i++)
            {
                int rand = random.Next(countries.Count);
                var countryId = countries[rand].Id;

                cda.DeleteData(countryId);
            }

            countries = cda.GetData();


            Console.WriteLine("\n\n Countries upated");
            foreach (var country in countries)
            {
                Console.WriteLine($"[{country.Id}] {country.Name}");
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
