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
        static async Task Main(string[] args)
        {
            await SeedAsync();
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

        private static async Task SeedAsync()
        {
            using (var session = new LeantrainingDbContext())
            {
                bool anyRoundWithId2 = await session.Set<Round>().AnyAsync(x => x.Id == 2);
                if (!anyRoundWithId2)
                {
                    var round = new Round
                    {
                        Id = 2,
                        Start = new DateTime(2020, 01, 01),
                        End = null
                    };

                    session.Add(round);
                    await session.SaveChangesAsync();
                }
            }
        }
    }
}
