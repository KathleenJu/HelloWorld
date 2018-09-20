using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Internal;

namespace HelloWorld
{
    public class UserManager
    {
        private readonly string _filePath;
        private const string _permanentUser = "Kathleen";
        private IEnumerable<string> _currentNames;

        public IEnumerable<string> CurrentNames => _currentNames;

        public UserManager(string filePath)
        {
            //_currentUsers = SetCurrentUsers();
            _filePath = filePath;
            _currentNames = new List<string>();
        }

        public string Greet(IEnumerable<string> users)
        {
            var foo = GetFormattedListOfUsers(users);
            var greeting = "Hi " + foo;
            return greeting;
        }
        
        private string GetFormattedListOfUsers(IEnumerable<string> allUsers)
        {
            var users = string.Join(", ", allUsers);
            var lastCommaIndex = users.LastIndexOf(',');
            users = lastCommaIndex > 0 ? users.Remove(lastCommaIndex, 2).Insert(lastCommaIndex, " and ") : users;

            return users;
        }
        public string GetUsers()
        {
            var fileContent = File.ReadAllText(_filePath).Split(Environment.NewLine)
                .Where(s => !string.IsNullOrWhiteSpace(s)).Skip(1);
            var users = GetFormattedListOfUsers(fileContent);

            return users;
        }

        public void SetCurrentNames(IEnumerable<string> fileContent)
        {
            var names = fileContent.ToList();
            names.Remove("Name");
            _currentNames = names;
        }

        public IEnumerable<string> GetNewFileContent()
        {
            var fileContent = _currentNames.ToList();
            fileContent.Insert(0, "Name");
            
            return fileContent;
        }

        public void AddNewUser(string name)
        {
            var names = _currentNames.ToList();
            if (!names.Contains(name))
            {
                names.Add(name);
            }

            _currentNames = names;
        }

        public void RemoveUser(string name)
        {
            var names = _currentNames.ToList();
            if (names.Contains(name))
            {
                names.Remove(name);
            }

            _currentNames = names;
        }

        public void UpdateUser(string nameToBeUpdated, string newName)
        {
            var names = _currentNames.ToList();
            var updatedUsers = names.Select(name => name == nameToBeUpdated ? newName : name);

            _currentNames = updatedUsers;
        }
    }
}