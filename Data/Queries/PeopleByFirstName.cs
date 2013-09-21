using System.Linq;
using Highway.Data;
using ProvenStyle.Entities;

namespace ProvenStyle.Data
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
