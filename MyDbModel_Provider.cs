using MyDbModels;
using System.Threading.Tasks;

namespace Providers
{
    public class MyDbModel_Provider : IMyDbModel_Provider
    {
        private readonly IMyDbModel_UnitOfWork _uow;

        public MyDbModel_Provider(IMyDbModel_UnitOfWork uow)
        {
            _uow = uow;
        }

        public async ValueTask<IMyDbModel<T>> Execute<T>(
            IMyDbModel<T> model,
            string spName,
            bool pagination = true
        ) where T : class, new()
        {
            await _uow.Execute(model, spName, pagination);
            return model;
        }
    }
}
