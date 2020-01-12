using System;
using System.Threading.Tasks;
using leantraining.Models;

namespace leantraining.UseCases
{
    public class CreateUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            // creates an INSERT Statement inside the database
            var nextRound = new Round 
            { 
                Start = DateTime.Now, 
                End = DateTime.Now.AddHours(4),
                Id = ROUND_ID_FOR_DEMO
            };

            using (var session = CreateSession())
            {
                // activates the changetracking and sets the state to 
                // added for the Round Property
                session.Add(nextRound);
                // commits to the database and sets off the command
                await session.SaveChangesAsync();
            }
            return $"added Round with id [{nextRound.Id}]";
        }
    }
}