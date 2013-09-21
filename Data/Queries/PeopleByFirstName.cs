using System.Linq;
using Entities;
using Highway.Data;

namespace Data
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
