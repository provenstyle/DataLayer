using System.Data.Entity.ModelConfiguration;
using Entities;

namespace Data
{
    public class PersonMapping : EntityTypeConfiguration<Person>
    {
        public PersonMapping()
        {
            ToTable("Person");
            HasKey(x => x.Id);
        }
    }
}