using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace HelloWorld.Tests
{
    public class UserManagerShould
    { 
        private readonly Greeter _greeter = new Greeter();
        
        
        [Fact]
        public void AddNewUser()
        {
            var fileContent = new List<string>{"Name", "Kathleen"};
            _greeter.SetCurrentNames(fileContent);
            const string user = "Bob";
            _greeter.AddNewUser(user);
            
            var actualUsers = _greeter.CurrentNames;
            var expectedUsers = new List<string> {"Kathleen", "Bob"};

            expectedUsers.Should().BeEquivalentTo(actualUsers);
        }
        
        [Fact]
        public void RemoveAUserFromCSVFile()
        {
            var fileContent = new List<string>{"Name", "Kathleen", "Bob"};
            _greeter.SetCurrentNames(fileContent);
            const string user = "Bob";
            _greeter.RemoveName(user);
            
            var actualUsers = _greeter.CurrentNames;
            var expectedUsers = new List<string> {"Kathleen"};

            expectedUsers.Should().BeEquivalentTo(actualUsers);
        }
        
        [Fact]
        public void UpdateNameOfUserFromCSVFile()
        {
            var fileContent = new List<string>{"Name", "Kathleen", "Bob"};
            _greeter.SetCurrentNames(fileContent);
            const string nameToBeUpdated = "Bob";
            const string newName = "Dave";
            _greeter.UpdateUser(nameToBeUpdated, newName);
            
            var actualUsers = _greeter.CurrentNames;
            var expectedUsers = new List<string> {"Kathleen", "Dave"};

            expectedUsers.Should().BeEquivalentTo(actualUsers);
        }
        
//        [Fact]
//        public void GetAllUsersInTheCorrectFormatWhenThereIsOnlyOneUser()
//        {
//            _userManager.RemoveUser("Will");
//            _userManager.RemoveUser("Bob");
//            var actualUsers = _userManager.GetUsers();
//            var expectedUsers = "Kathleen";
//            
//            Assert.Equal(expectedUsers, actualUsers);
//        }
//        
//        [Fact]
//        public void GetAllUsersInTheCorrectFormatWhenThereIsTwoUsers()
//        {
//            _userManager.RemoveUser("Will");
//            _userManager.AddNewUser("Bob");
//            var actualUsers = _userManager.GetUsers();
//            var expectedUsers = "Kathleen and Bob";
//            
//            Assert.Equal(expectedUsers, actualUsers);
//        }
//        
//        [Fact]
//        public void GetAllUsersInTheCorrectFormatWhenThereIsThreeUsers()
//        {
//            _userManager.AddNewUser("Bob");
//            _userManager.AddNewUser("Will");
//            var actualUsers = _userManager.GetUsers();
//            var expectedUsers = "Kathleen, Bob and Will";
//            
//            Assert.Equal(expectedUsers, actualUsers);
//        }
    }
}