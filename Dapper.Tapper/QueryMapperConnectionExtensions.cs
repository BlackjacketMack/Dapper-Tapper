using Dapper.Tapper;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Dapper.Tapper
{
    public static class QueryMapperConnectionExtensions
    {
        public static IEnumerable<T> Query<T>(this IDbConnection cnn,
                                                string sql,
                                                object param,
                                                QueryMapper<T> mapper,
                                                IDbTransaction transaction = null,
                                                int? commandTimeout = null,
                                                CommandType commandType = CommandType.Text)
        {
            var q = (IEnumerable<T>)null;

            if (mapper == null)
            {
                mapper = new QueryMapper<T>();
                mapper.SimpleMap();
            }

            var qm = cnn.QueryMultiple(sql, param, transaction, commandTimeout, commandType);

            q = mapper.MappingFunc.Invoke(qm);

            return q;
        }
    }

}