using Parser.Tables;
using System;
using System.IO;
using System.Linq;

namespace Parser
{
    public class ParserFromSql
    {
        private string Script;
        public ParserFromSql(string pathToScript)
        {
            if (!File.Exists(pathToScript))
            {
                throw new Exception("Неверный путь к файлу!");
            }

            Script =  File.ReadAllText(pathToScript);       
        }

        public SqlModel GetSqlModel()
        {
            return new SqlModel() {
                Tables = new ParserTables(this.Script).Parse().Select(el => new SqlTable(el)).ToArray()
            };
        }
    }
}
