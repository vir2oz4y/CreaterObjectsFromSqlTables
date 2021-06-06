using Parser.Tables.LineElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parser.Tables
{
    public class TableColumn
    {
        public string Name { get; set; }
        public TypeLine Type { get; set; }
        public bool Nulable { get; set; }

        public TableColumn(string Script)
        {
            this.GetLine(Script);
        }

        private void GetLine(string script)
        {
            var regex = new Regex(@"(?<tableName>\[\w*\])\s*(?<type>\[\w*\])\s*((\(\d*\))|(IDENTITY\(\d,\s*\d*\))|()|(\(\d*\s*,\s*\d*\)))\s*(?<nullable>(NOT NULL)|(NULL))");

            this.Name = regex.Match(script).Groups["tableName"].Value[1..^1];
            this.Type = new TypeLine (regex.Match(script).Groups["type"].Value);
            this.Nulable = this.CheckNullable(regex.Match(script).Groups["nullable"].Value);
        }

        private bool CheckNullable(string value)
        {
            return value == "NULL";
        }

        public override string ToString()
        {
            if (Nulable)
            {
                return $"\r\n\t\tpublic {Type.Name}? {this.Name} {{ get; set; }}";
            }
            return $"\r\n\t\tpublic {Type.Name} {this.Name} {{ get; set; }}";
        }
    }
}
