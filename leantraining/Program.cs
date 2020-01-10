using System;
using System.Linq;
using System.Threading.Tasks;
using leantraining.DataAccess;
using leantraining.Models;
using Microsoft.EntityFrameworkCore;

namespace leantraining
{
    class Program
    {
        static async void Main(string[] args)
        {
            var product = await GetLastProductAsync();

            System.Console.WriteLine(product);
            Console.ReadLine();
        }

        private static async Task<Product> GetLastProductAsync()
        {
            using (var session = new LeantrainingDbContext())
            {
                var date = DateTime.Now;
                var first = await session.Set<Product>()
                                   .Where(x => x.Start < date)
                                   .OrderByDescending(x => x.Id)
                                   .Include(x => x.Round)
                                   .FirstOrDefaultAsync();
                
                return first;
            }
        }
    }
}
