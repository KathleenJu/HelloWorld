using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Internal;

namespace HelloWorld
{
    public class CSVFileParser
    {
        private readonly string _filePath;
        private readonly string _permanentUser = "Kathleen";

        public CSVFileParser(string filePath)
        {
            _filePath = filePath;
        }

        public string GetUsers()
        {
            var fileContent = File.ReadAllText(_filePath).Split(Environment.NewLine)
                .Where(s => !string.IsNullOrWhiteSpace(s)).Skip(1);
            var users = GetFormattedListOfUsers(fileContent);

            return users;
        }

        private static string GetFormattedListOfUsers(IEnumerable<string> allUsers)
        {
            var users = string.Join(", ", allUsers);
            var lastCommaIndex = users.LastIndexOf(',');
            users = lastCommaIndex > 0 ? users.Remove(lastCommaIndex, 2).Insert(lastCommaIndex, " and ") : users;

            return users;
        }

        public void AddNewUser(string user)
        {
            user = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.ToLower());
            if (!File.ReadAllText(_filePath).Contains(user))
            {
                File.AppendAllText(_filePath, Environment.NewLine + user);
            }
        }

        public void RemoveUser(string user)
        {
            user = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.ToLower());
            if (user != _permanentUser)
            {
                var fileContent = File.ReadAllLines(_filePath).Where(s => !string.IsNullOrWhiteSpace(s));
                var fileWriter = new StreamWriter(_filePath);
                foreach (var existingName in fileContent)
                {
                    fileWriter.WriteLine(Regex.Replace(existingName, @"\b"+user+ @"\b", String.Empty));
                }

                fileWriter.Close();
            }
        }

        public void UpdateUser(string nameToBeUpdated, string newUserName)
        {
            nameToBeUpdated = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nameToBeUpdated.ToLower());
            if (nameToBeUpdated != _permanentUser)
            {
                var fileContent = File.ReadAllLines(_filePath).Where(s => !string.IsNullOrWhiteSpace(s));
                var fileWriter = new StreamWriter(_filePath);
                foreach (var existingName in fileContent)
                {
                    fileWriter.WriteLine(Regex.Replace(existingName, @"\b" + nameToBeUpdated + @"\b", newUserName));
                }

                fileWriter.Close();
            }
        }
    }
}