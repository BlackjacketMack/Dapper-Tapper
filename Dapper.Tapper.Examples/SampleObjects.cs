using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Tapper.Examples
{
    public class Foo
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Bar
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Foo Foo { get; set; }
    }
}
