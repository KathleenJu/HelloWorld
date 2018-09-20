using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace HelloWorld.Tests
{
    public class GreeterShould
    {
        private readonly Greeter Greeter = new Greeter();
        
        [Fact]
        public void GreetInCorrectFormatAndTimeWhenThereIsOnlyOneName()
        {
            var names = new List<string>{"Kathleen"};
            var time = DateTime.Now.ToString("hh:mmtt").ToLower();
            var date = DateTime.Now.Day + " " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year;
            
            var expectedGreeting = "Hi Kathleen - the time on the server is " + time + " on " + date;
            var actualGreeting = Greeter.Greet(names, DateTime.Now);
            
            Assert.Equal(expectedGreeting, actualGreeting);
        }
        
        [Fact]
        public void GreetInCorrectFormatAndTimeWhenThereAreTwoNames()
        {
            var names = new List<string>{"Kathleen", "Bob"};
            var time = DateTime.Now.ToString("hh:mmtt").ToLower();
            var date = DateTime.Now.Day + " " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year;
            
            var expectedGreeting = "Hi Kathleen and Bob - the time on the server is " + time + " on " + date;
            var actualGreeting = Greeter.Greet(names, DateTime.Now);
            
            Assert.Equal(expectedGreeting, actualGreeting);
        }
        
        [Fact]
        public void GreetInCorrectFormatAndTimeWhenThereAreThreeNames()
        {
            var names = new List<string>{"Kathleen", "Bob", "Will"};
            var time = DateTime.Now.ToString("hh:mmtt").ToLower();
            var date = DateTime.Now.Day + " " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year;
            
            var expectedGreeting = "Hi Kathleen, Bob and Will - the time on the server is " + time + " on " + date;
            var actualGreeting = Greeter.Greet(names, DateTime.Now);
            
            Assert.Equal(expectedGreeting, actualGreeting);
        }
    }
}