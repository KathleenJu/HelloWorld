using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using HelloWorld.FileIO;

namespace HelloWorld
{
    public class CSVFileIO : IFileIO
    {
        public IEnumerable<string> ReadFileContent(string filePath)
        {
            var fileContent = File.ReadLines(filePath).Where(s => !string.IsNullOrWhiteSpace(s));
            return fileContent;
        }

        public void AppendToFile(string filePath, string content)
        {
            content = Environment.NewLine + content;
            File.AppendAllText(filePath, content);
        }

        public void RewriteFileWithNewContent(string filePath, IEnumerable<string> newContent)
        {
            File.WriteAllLines(filePath, newContent);
        }
    }
}