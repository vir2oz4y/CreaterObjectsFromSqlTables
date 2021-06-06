using System;
using System.IO;

namespace FileCreator
{
    public abstract class BaseFile
    {
        protected string file = "using System;\r\n\r\nnamespace {0}\r\n{\r\n\tpublic class {1}\r\n\t{{2}\r\n\t}\n}";

        private string ClassName;
        public BaseFile(string namespase, string className) {

            this.ClassName = className;

            this.file = this.file.Replace("{0}", namespase).Replace("{1}", className);
        }

        public void SaveFile(string pathToSave)
        {
            string filePath = pathToSave + @$"\\{ClassName}.cs";

            File.WriteAllText(filePath, this.file);
        }
    }
}
