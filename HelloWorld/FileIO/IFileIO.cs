using System.Collections;
using System.Collections.Generic;

namespace HelloWorld.FileIO
{
    public interface IFileIO
    {
        IEnumerable<string> ReadFileContent(string filepath);
        void AppendToFile(string filePath, string content);
        void RewriteFileWithNewContent(string filepath, IEnumerable<string> newContent);
    }
}