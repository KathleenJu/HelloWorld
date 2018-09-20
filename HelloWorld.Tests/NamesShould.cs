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
        public void AddNewName()
        {
            const string user = "Bob";
            Names.Add(user);
            
            var actualUsers = Names.GetNames();
            var expectedUsers = new List<string> {"Kathleen", "Bob"};

            expectedUsers.Should().BeEquivalentTo(actualUsers);
        }
        
        [Fact]
        public void RemoveAnExistingName()
        {
            const string user = "Bob";
            Names.Remove(user);
            
            var actualUsers = Names.GetNames();
            var expectedUsers = new List<string> {"Kathleen"};

            expectedUsers.Should().BeEquivalentTo(actualUsers);
        }
        
        [Fact]
        public void UpdateNameOfExistingName()
        {
            const string nameToBeUpdated = "Bob";
            Names.Add(nameToBeUpdated);
            const string newName = "Dave";
            Names.Update(nameToBeUpdated, newName);
            
            var actualUsers = Names.GetNames();
            var expectedUsers = new List<string> {"Kathleen", "Dave"};

            expectedUsers.Should().BeEquivalentTo(actualUsers);
        }
    }
}