using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parser
{
    public abstract class Parser
    {
        protected string Script;

        protected Regex Regex;

        public Parser(string script)
        {
            this.Script = script;
        }

        public abstract string[] Parse();
    }
}
