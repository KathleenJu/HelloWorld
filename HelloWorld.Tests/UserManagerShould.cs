using System;
using Xunit;

namespace HelloWorld.Tests
{
    public class UserManagerShould
    { 
        private readonly UserManager _userManager = new UserManager(@"../../../../HelloWorld.Tests/Files/testUsers.csv");
        
        
        [Fact]
        public void AddNewUserToCSVFile()
        {
            _userManager.AddNewUser("Bob");
            var actualUsers = _userManager.GetUsers();
            var expectedUsers = "Kathleen and Bob";
            
            Assert.Equal(expectedUsers, actualUsers);
        }
        
        [Fact]
        public void RemoveAUserFromCSVFile()
        {
            _userManager.RemoveUser("Bob");
            var actualUsers = _userManager.GetUsers();
            var expectedUsers = "Kathleen";
            
            Assert.Equal(expectedUsers, actualUsers);
        }
        
        [Fact]
        public void UpdateNameOfUserFromCSVFile()
        {
            _userManager.AddNewUser("Bob");
            _userManager.UpdateUser("Bob", "Bobby");
            var actualUsers = _userManager.GetUsers();
            var expectedUsers = "Kathleen and Bobby";
            
            Assert.Equal(expectedUsers, actualUsers);
        }
        
        [Fact]
        public void GetAllUsersInTheCorrectFormatWhenThereIsOnlyOneUser()
        {
            _userManager.RemoveUser("Will");
            _userManager.RemoveUser("Bob");
            var actualUsers = _userManager.GetUsers();
            var expectedUsers = "Kathleen";
            
            Assert.Equal(expectedUsers, actualUsers);
        }
        
        [Fact]
        public void GetAllUsersInTheCorrectFormatWhenThereIsTwoUsers()
        {
            _userManager.RemoveUser("Will");
            _userManager.AddNewUser("Bob");
            var actualUsers = _userManager.GetUsers();
            var expectedUsers = "Kathleen and Bob";
            
            Assert.Equal(expectedUsers, actualUsers);
        }
        
        [Fact]
        public void GetAllUsersInTheCorrectFormatWhenThereIsThreeUsers()
        {
            _userManager.AddNewUser("Bob");
            _userManager.AddNewUser("Will");
            var actualUsers = _userManager.GetUsers();
            var expectedUsers = "Kathleen, Bob and Will";
            
            Assert.Equal(expectedUsers, actualUsers);
        }
    }
}