using FileCreator;
using Parser;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Creator.CreateFileFromSql(@"C:\Users\nickls0n\Desktop\Script.sql", @"C:\Users\nickls0n\Desktop\test");
        }
    }
}
