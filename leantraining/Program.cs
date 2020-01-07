using System;
using System.Linq;
using leantraining.Models;
using leantraining.DataAccess;
namespace leantraining
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = new LeanTrainingDbContext())
            {
                var product = new Products();
                session.Add(product);

                session.SaveChanges();

                var first = session.Products.First();
                System.Console.WriteLine(first.Id);
            }
        }
    }
}
