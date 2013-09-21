using System.Linq;
using Entities;
using Highway.Data;

namespace Data.Queries
{
    public class PeopleByFirstName : Query<Person>
    {
        public PeopleByFirstName(string firstName)
        {
            ContextQuery = context => context.AsQueryable<Person>()
                .Where(x => x.FirstName == firstName);
        }
    }
}
