using Highway.Data;

namespace ProvenStyle.Data
{
    public interface IRepositoryFactory
    {
        IRepository Create();
        void Release(IRepository repository);
    }
}