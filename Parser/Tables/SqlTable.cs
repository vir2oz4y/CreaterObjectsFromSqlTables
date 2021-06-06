using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parser.Tables

    //((\(\d*,\s*\d*\))|(IDENTITY\(\d,\s*\d\))|())\s*((NOT\sNULL)|(NULL)),)
{
    public class SqlTable
    {
        public string Name { get; set; }
        public TableColumn[] Lines { get; set; }

        private Regex RegexName = new Regex(@"((\[dbo].(\[\w*)))");

        private Regex RegexLines = new Regex(@"(?<tableName>\[\w*\])\s*(?<type>\[\w*\])\s*((\(\d*\))|(IDENTITY\(\d,\s*\d*\))|()|(\(\d*\s*,\s*\d*\)))\s*(?<nullable>(NOT NULL)|(NULL))");


        public SqlTable(string queryTable) 
        {
            this.Name = this.RegexName.Match(queryTable).Value.Substring(7).ToLower();
            this.Name =  this.Name[0].ToString().ToUpper()  + this.Name.Substring(1);

            this.Lines = this.RegexLines.Matches(queryTable).Select(el => new TableColumn(el.Value)).ToArray();
        }   
    }
}
