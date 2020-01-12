using System;
using System.Linq;
using System.Threading.Tasks;
using leantraining.Models;

namespace leantraining.UseCases
{
    public class DeleteUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            using (var session = CreateSession())
            {
                // No AsTracking or it throws exception on save changes
                var toDelete = await session.Set<Round>().FindAsync(ROUND_ID_FOR_DEMO);

                if (toDelete == null)
                    return $"did not find {ROUND_ID_FOR_DEMO}";

                // mark as Deleted with ChangeTracking
                session.Remove(toDelete);
                // commit to database
                await session.SaveChangesAsync();

                return $"removed round with id {ROUND_ID_FOR_DEMO}. Use Read UseaCase to check it out";
            }
        }
    }
}