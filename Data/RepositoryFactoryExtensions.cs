using System;
using Highway.Data;

namespace ProvenStyle.Data
{
    public static class RepositoryFactoryExtensions
    {
        public static void WithRepository(this IRepositoryFactory factory, Action<IRepository> action)
        {
            var repo = factory.Create();
            try
            {
                action.Invoke(repo);
            }
            finally
            {
                factory.Release(repo);
            }
        }
    }
}
