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
        public string Greet(IEnumerable<string> names, DateTime dateTime)
        {
            var listOfNames = GetFormattedListOfUsers(names);
            var time = GetFormattedTime(dateTime);
            var date = GetFormattedDate(dateTime);
            var greeting = "Hi " + listOfNames;
            greeting += " - the time on the server is " + time + " on " + date;
            
            return greeting;
        }

        private string GetFormattedListOfUsers(IEnumerable<string> allUsers)
        {
            var readableListOfNames = string.Join(", ", allUsers);
            var lastCommaIndex = readableListOfNames.LastIndexOf(',');
            readableListOfNames = lastCommaIndex > 0 ? readableListOfNames.Remove(lastCommaIndex, 2).Insert(lastCommaIndex, " and ") : readableListOfNames;

            return readableListOfNames;
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

    }
}