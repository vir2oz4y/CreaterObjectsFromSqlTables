using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parser.Tables.LineElement
{
    public class TypeLine
    {
        public string Name { get; set; }
        public string Length { get; set; }


        public TypeLine(string value)
        {
            GetType(value);
        }

        private void GetType(string value)
        {
            var regexLen = new Regex(@"(\(\w*\))");
            if (regexLen.IsMatch(value))
            {
                this.Length = DelFirstAndLast(regexLen.Match(value).Value);
            }

            var regexType = new Regex(@"(\[\w*])");
            this.Name = this.GetNameType(DelFirstAndLast(regexType.Match(value).Value));
        }

        private string DelFirstAndLast(string value)
        {
            return value.Substring(1,value.Length-2);
        }

        private string GetNameType(string typeName)
        {
            typeName = typeName.ToUpper();
            string[] ints = new string[]
            {
                "TINYINT", "SMALLINT", "INT"
            };

            if (ints.Contains(typeName))
            {
                return "int";
            }

            string[] bools = new string[]
            {
                "BIT"
            };
            if (bools.Contains(typeName))
            {
                return "bool";
            }

            string[] longs = new string[]
            {
                "BIGINT","TIMESTAMP"
            };
            if (longs.Contains(typeName))
            {
                return "long";
            }

            string[] decimals = new string[]
            {
                "DECIMAL", "NUMERIC", "SMALLMONEY", "MONEY"
            };
            if (decimals.Contains(typeName))
            {
                return "decimal";
            }

            string[] floats = new string[]
            {
                "FLOAT", "REAL"
            };
            if (floats.Contains(typeName))
            {
                return "float";
            }

            string[] dates = new string[]
            {
                "DATE", "TIME", "DATETIME", "DATETIME2", "SMALLDATETIME", "DATETIMEOFFSET"
            };
            if (dates.Contains(typeName))
            {
                return "DateTime";
            }

            string[] strings = new string[]
            {
                "CHAR", "VARCHAR", "NCHAR","NVARCHAR","TEXT","NTEXT"
            };
            if (strings.Contains(typeName))
            {
                return "string";
            }

            string[] bytes = new string[]
            {
                "BINARY","VARBINARY"
            };
            if (bytes.Contains(typeName))
            {
                return "byte[]";
            }

            string[] GUID = new string[]
            {
                "UNIQUEIDENTIFIER"
            };
            if (GUID.Contains(typeName))
            {
                return "GUID";
            }

            return "string";
        }
    }
}
