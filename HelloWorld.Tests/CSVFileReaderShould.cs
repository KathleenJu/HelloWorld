using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace HelloWorld.Tests
{
    public class CSVFileReaderShould
    {
        private readonly CSVFileIO _csvFileIO = new CSVFileIO();
        private const string _filePath = "../../../../HelloWorld.Tests/Files/testUsers.csv";

        [Fact]
        public void ReadTheFileContents()
        {
            var expectedFileContent = new List<string> {"Name", "Kathleen"} ;
            var actualFileContent =  _csvFileIO.ReadFileContent(_filePath);

            expectedFileContent.Should().BeEquivalentTo(actualFileContent);
        }
        
        [Fact]
        public void AppendNewNameToFile()
        {
            var newName = "Will";
            _csvFileIO.AppendToFile(_filePath, newName);
            
            var expectedFileContent = new List<string> {"Name", "Kathleen", "Will"};
            var actualFileContent =  _csvFileIO.ReadFileContent(_filePath);

            expectedFileContent.Should().BeEquivalentTo(actualFileContent);
        }
    }
}