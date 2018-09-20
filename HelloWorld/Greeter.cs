using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Internal;

namespace HelloWorld
{
    public class Greeter
    {
        private const string _permanentUser = "Kathleen";
        private IEnumerable<string> _currentNames;

        public IEnumerable<string> CurrentNames => _currentNames;

        public Greeter()
        {
            _currentNames = new List<string>();
        }

        public string Greet(DateTime dateTime)
        {
            var listOfNames = GetFormattedListOfUsers(_currentNames);
            var time = GetFormattedTime(dateTime);
            var date = GetFormattedDate(dateTime);
            var greeting = "Hi " + listOfNames;
            greeting += " - the time on the server is " + time + " on " + date;
            return greeting;
        }

        private static string GetFormattedDate(DateTime dateTime)
        {
            var date = dateTime.Day + " " + dateTime.ToString("MMMM") + " " + dateTime.Year;
            return date;
        }

        private static string GetFormattedTime(DateTime dateTime)
        {
            var time = dateTime.ToString("hh:mmtt").ToLower();
            return time;
        }

        private string GetFormattedListOfUsers(IEnumerable<string> allUsers)
        {
            var readableListOfNames = string.Join(", ", allUsers);
            var lastCommaIndex = readableListOfNames.LastIndexOf(',');
            readableListOfNames = lastCommaIndex > 0 ? readableListOfNames.Remove(lastCommaIndex, 2).Insert(lastCommaIndex, " and ") : readableListOfNames;

            return readableListOfNames;
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

        public void AddName(string name)
        {
            var names = _currentNames.ToList();
            if (!names.Contains(name))
            {
                names.Add(name);
            }

            _currentNames = names;
        }

        public void RemoveName(string name)
        {
            var names = _currentNames.ToList();
            if (names.Contains(name) & name != _permanentUser)
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