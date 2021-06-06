using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parser
{
    //(CREATE TABLE (\[dbo].(\[\w*]))[\(])(\D*\d*)*(^)
    //(CREATE TABLE (\[dbo].(\[\w*]))[\(])(\D*\d*\))* was
    //(CREATE TABLE (\[dbo].(\[\w*]))[\(])((((\D*\[\w*\]\s+\[\w*\]\s*)))((\(\d*,\s*\d*\))|()|(IDENTITY\(\d*,\s*\d*\))|(\(\d*\)))\s*((NOT NULL)|(NULL)))*
    public class ParserTables : Parser
    {
        public ParserTables(string script) : base(script)
        {
            this.Regex = new Regex(@"(CREATE TABLE (\[dbo].(\[\w*]))[\(])((((\D*\[\w*\]\s+\[\w*\]\s*)))((\(\d*,\s*\d*\))|()|(IDENTITY\(\d*,\s*\d*\))|(\(\d*\)))\s*((NOT NULL)|(NULL)))*");
        }

        public override string[] Parse()
        {
            Regex identity = new Regex(@"(IDENTITY\(\d,\d\))");
            this.Script = identity.Replace(this.Script, "");
            return this.Regex.Matches(this.Script).Select(el => el.Value).ToArray(); ;
        }
    }
}
