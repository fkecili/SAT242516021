using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyDbModels;
using System.Data;
using System.Threading.Tasks;

namespace Providers
{
    public class MyDbModel_UnitOfWork<TDbContext> : IMyDbModel_UnitOfWork
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public MyDbModel_UnitOfWork(TDbContext context)
        {
            _context = context;
        }

        public async Task Execute<T>(IMyDbModel<T> model, string spName, bool pagination)
            where T : class, new()
        {
            using var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;

            if (pagination)
            {
                cmd.Parameters.Add(new SqlParameter("@Sayfa", model.PageNumber));
                cmd.Parameters.Add(new SqlParameter("@SayfaBoyutu", model.PageSize));
            }

            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var item = new T();
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (!reader.HasColumn(prop.Name)) continue;

                    var val = reader[prop.Name];
                    if (val == DBNull.Value) continue;

                    prop.SetValue(item, val);
                }

                model.Items!.Add(item);
            }
        }
    }

    public static class SqlExtensions
    {
        public static bool HasColumn(this IDataRecord reader, string name)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(name)) return true;
            }
            return false;
        }
    }
}
