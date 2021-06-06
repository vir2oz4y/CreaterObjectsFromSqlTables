using Parser;
using Parser.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreator
{
    public class SqlFile : BaseFile
    {
        private SqlTable SqlTable;
        public SqlFile(string namespase, SqlTable sqlTable) : base(namespase, sqlTable.Name)
        {
            this.SqlTable = sqlTable;
        }

        public void AddElements()
        {
            var lines = this.SqlTable.Lines.Select(el => {
                return el.ToString();
            });

            var content = string.Join(string.Empty, lines);

            this.file = this.file.Replace("{2}", content);
        } 
    }
}
