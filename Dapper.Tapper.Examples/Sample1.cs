using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Tapper.Examples
{
    public class Sample1Database
    {
        public class table<T>
        {
            public QueryMapper<T> QueryMapper { get; private set; }
            public table<T> UsesQueryMapper(QueryMapper<T> queryMapper)
            {
                this.QueryMapper = queryMapper;

                return this;
            }
        }
        public static table<Foo> FooTable;
        public static table<Bar> BarTable;

        static Sample1Database()
        {
            FooTable = new table<Foo>()
                                  .UsesQueryMapper(new QueryMapper<Foo>().SimpleMap());

            BarTable = new table<Bar>()
                                  .UsesQueryMapper(new QueryMapper<Bar>().MultiMap<Bar,Foo>((b,f)=>{b.Foo = f; return b;}));

        }
    }
}
