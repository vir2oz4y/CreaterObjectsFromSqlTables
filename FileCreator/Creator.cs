using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreator
{
    public static class Creator
    {
        public static void CreateFileFromSql(string scriptPath, string outPath)
        {
            ParserFromSql parser = new ParserFromSql(scriptPath);
            var sqlModel = parser.GetSqlModel();

            foreach (var table in sqlModel.Tables)
            {
                SqlFile sqlFile = new SqlFile("testNamespase", table);
                sqlFile.AddElements();
                sqlFile.SaveFile(outPath);
            }
            
        }
    }
}
