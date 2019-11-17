using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using lab4.Model;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new ModelDbContext())
            {
                var cinema = new Cinemas();

                ctx.Cinemas.Add(cinema);

                ctx.SaveChanges();

               
            }

            Console.ReadKey();
        }
    }
}
