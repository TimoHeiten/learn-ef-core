using leantraining.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace leantraining.UseCases
{
    public class UpdateUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            using (var session = CreateSession())
            {
                // Get round with demo id
                var round = await session.Set<Round>()
                                         .FirstOrDefaultAsync(x => x.Id == ROUND_ID_FOR_DEMO);
                if (round == null)
                    return $"NOT_FOUND: {ROUND_ID_FOR_DEMO}";
                // update end
                round.End = round.Start.AddHours(8);
                session.Update(round);
                // commit to database
                await session.SaveChangesAsync();

                return "updated round with id " + ROUND_ID_FOR_DEMO.ToString();
            }
        }
    }
}