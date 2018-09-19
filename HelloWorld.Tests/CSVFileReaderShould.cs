using System.Collections.Generic;
using System.IO;
using System.Net;
using FluentAssertions;
using Xunit;

namespace HelloWorld.Tests
{
    public class CSVFileReaderShould
    {
        private readonly CSVFileIO _csvFileIO = new CSVFileIO();
        private readonly TestHelper _testHelper = new TestHelper();
        private const string _filePath = "../../../../HelloWorld.Tests/Files/testUsers.csv";

        [Fact]
        public void ReadTheFileContents()
        {
            _testHelper.PopulateCSVWithInitialState(_filePath);
            
            var expectedFileContent = new List<string> {"Name", "Kathleen"} ;
            var actualFileContent =  _csvFileIO.ReadFileContent(_filePath);

            expectedFileContent.Should().BeEquivalentTo(actualFileContent);
        }

        [Fact]
        public void AppendNewNameToFile()
        {
            _testHelper.PopulateCSVWithInitialState(_filePath);
            
            const string newName = "Bob";
            _csvFileIO.AppendToFile(_filePath, newName);
            
            var expectedFileContent = new List<string> {"Name", "Kathleen", "Bob"};
            var actualFileContent =  _csvFileIO.ReadFileContent(_filePath);

            expectedFileContent.Should().BeEquivalentTo(actualFileContent);
        }
        
        [Fact]
        public void RewriteNewContentToTheFile()
        {
            _testHelper.PopulateCSVWithInitialState(_filePath);
            
            var newContent = new List<string> {"Name", "Kathleen", "Bob"};
            _csvFileIO.RewriteFileWithNewContent(_filePath, newContent);
            
            var expectedFileContent = new List<string> {"Name", "Kathleen", "Bob"};
            var actualFileContent =  _csvFileIO.ReadFileContent(_filePath);

            expectedFileContent.Should().BeEquivalentTo(actualFileContent);
        }
    }
}