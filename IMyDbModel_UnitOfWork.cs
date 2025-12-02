using MyDbModels;
using System.Threading.Tasks;

namespace Providers
{
    public interface IMyDbModel_UnitOfWork
    {
        Task Execute<T>(IMyDbModel<T> model, string spName, bool pagination)
            where T : class, new();
    }
}
