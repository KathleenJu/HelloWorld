using System;
using HelloWorld;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace HelloWorld.Tests
{
    public class NamesShould
    { 
        private readonly Names Names = new Names();
        
        
        [Fact]
        public void AddNewUser()
        {
            const string user = "Bob";
            Names.AddName(user);
            
            var actualUsers = Names.GetNames();
            var expectedUsers = new List<string> {"Kathleen", "Bob"};

            expectedUsers.Should().BeEquivalentTo(actualUsers);
        }
        
        [Fact]
        public void RemoveAUserFromCSVFile()
        {
            const string user = "Bob";
            Names.RemoveName(user);
            
            var actualUsers = Names.GetNames();
            var expectedUsers = new List<string> {"Kathleen"};

            expectedUsers.Should().BeEquivalentTo(actualUsers);
        }
        
        [Fact]
        public void UpdateNameOfUserFromCSVFile()
        {
            const string nameToBeUpdated = "Bob";
            Names.AddName(nameToBeUpdated);
            const string newName = "Dave";
            Names.UpdateUser(nameToBeUpdated, newName);
            
            var actualUsers = Names.GetNames();
            var expectedUsers = new List<string> {"Kathleen", "Dave"};

            expectedUsers.Should().BeEquivalentTo(actualUsers);
        }
    }
}