using System;
using Xunit;

namespace HelloWorld.Tests
{
    public class CSVFileParserShould
    { 
        private readonly CSVFileParser _csvFileParser = new CSVFileParser(@"../../../../HelloWorld.Tests/Files/testUsers.csv");
        
        
        [Fact]
        public void AddNewUserToCSVFile()
        {
            _csvFileParser.AddNewUser("Bob");
            var actualUsers = _csvFileParser.GetUsers();
            var expectedUsers = "Kathleen and Bob";
            
            Assert.Equal(expectedUsers, actualUsers);
        }
        
        [Fact]
        public void RemoveAUserFromCSVFile()
        {
            _csvFileParser.RemoveUser("Bob");
            var actualUsers = _csvFileParser.GetUsers();
            var expectedUsers = "Kathleen";
            
            Assert.Equal(expectedUsers, actualUsers);
        }
        
        [Fact]
        public void UpdateNameOfUserFromCSVFile()
        {
            _csvFileParser.AddNewUser("Bob");
            _csvFileParser.UpdateUser("Bob", "Bobby");
            var actualUsers = _csvFileParser.GetUsers();
            var expectedUsers = "Kathleen and Bobby";
            
            Assert.Equal(expectedUsers, actualUsers);
        }
        
        [Fact]
        public void GetAllUsersInTheCorrectFormatWhenThereIsOnlyOneUser()
        {
            _csvFileParser.RemoveUser("Will");
            _csvFileParser.RemoveUser("Bob");
            var actualUsers = _csvFileParser.GetUsers();
            var expectedUsers = "Kathleen";
            
            Assert.Equal(expectedUsers, actualUsers);
        }
        
        [Fact]
        public void GetAllUsersInTheCorrectFormatWhenThereIsTwoUsers()
        {
            _csvFileParser.RemoveUser("Will");
            _csvFileParser.AddNewUser("Bob");
            var actualUsers = _csvFileParser.GetUsers();
            var expectedUsers = "Kathleen and Bob";
            
            Assert.Equal(expectedUsers, actualUsers);
        }
        
        [Fact]
        public void GetAllUsersInTheCorrectFormatWhenThereIsThreeUsers()
        {
            _csvFileParser.AddNewUser("Bob");
            _csvFileParser.AddNewUser("Will");
            var actualUsers = _csvFileParser.GetUsers();
            var expectedUsers = "Kathleen, Bob and Will";
            
            Assert.Equal(expectedUsers, actualUsers);
        }
    }
}