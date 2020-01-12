using System.Threading.Tasks;
using leantraining.DataAccess;

namespace leantraining.UseCases
{
    public abstract class UseCase
    {
        public abstract Task<string> ExecuteAsync();

        public const int ROUND_ID_FOR_DEMO = 99;

        protected LeantrainingDbContext CreateSession()
            => new LeantrainingDbContext();
    }
}