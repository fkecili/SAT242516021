using System.Threading.Tasks;
using MyDbModels;

namespace Providers
{
    public interface IMyDbModel_Provider
    {
        ValueTask<IMyDbModel<T>> Execute<T>(
            IMyDbModel<T> model,
            string spName,
            bool pagination = true
        ) where T : class, new();
    }
}
