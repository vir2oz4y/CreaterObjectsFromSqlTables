using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Tables;

namespace Parser
{
    public class SqlModel
    {
        public SqlTable[] Tables { get; set; }
        public string[] Procedures { get; set; }
        public string[] Functions { get; set; }
    }
}
