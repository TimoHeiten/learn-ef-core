using System.Threading.Tasks;
using leantraining.DataAccess;

namespace leantraining.UseCases
{
    public abstract class UseCase
    {
        public abstract Task<string> ExecuteAsync();


        protected LeantrainingDbContext CreateSession()
            => new LeantrainingDbContext();
    }
}