using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Castle.Windsor;
using Highway.Data;
using ProvenStyle.Data;

namespace DataMigrations
{
    public class ContextFactory : IDbContextFactory<DbContext>
    {
        public DbContext Create()
        {
            var container = new WindsorContainer();
            container.Install(new DataInstaller());
            var context = container.Resolve<IDataContext>();
            return context as DbContext;
        }
    }
}
