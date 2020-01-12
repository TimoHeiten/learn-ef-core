using System.Linq;
using System.Threading.Tasks;
using leantraining.Models;
using Microsoft.EntityFrameworkCore;

namespace leantraining.UseCases
{
    public class ReadUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            using (var session = CreateSession())
            {
                var rounds = await session.Set<Round>()
                                          // readOptiomized!
                                          .AsNoTracking()
                                          .ToListAsync();
                // or
                var round = await session.Set<Round>()
                                         // readOptiomized!
                                         .AsNoTracking()
                                         .SingleOrDefaultAsync(x => x.Id == ROUND_ID_FOR_DEMO);

                string found = round != null ? "found" : "did not find";

                return $"{found} round with Id {ROUND_ID_FOR_DEMO}\n" 
                       + $"Also found rounds with Ids\n{string.Join("\n", rounds.Select(x => x.Id))}";
            }
        }
    }
}