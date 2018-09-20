using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HelloWorld
{
    //RENAME CLASS
    public class Names
    {
        private List<string> _currentNames;
        private const string _permanentUser = "Kathleen";

        public Names()
        {
            _currentNames = new List<string> {_permanentUser};
        }

        public IEnumerable<string> GetNames()
        {
            return _currentNames;
        }

        public void Add(string name)
        {
            name = Capitalise(name);
            if (!_currentNames.Contains(name))
            {
                _currentNames.Add(name);
            }
        }

        public void Remove(string name)
        {
            if (_currentNames.Contains(name) & name != _permanentUser)
            {
                _currentNames.Remove(name);
            }
        }

        public void Update(string nameToBeUpdated, string newName)
        {
            nameToBeUpdated = Capitalise(nameToBeUpdated);
            newName = Capitalise(newName);
            if (!_currentNames.Contains(newName) & nameToBeUpdated != _permanentUser)
            {
                _currentNames = _currentNames.Select(name => name == nameToBeUpdated ? newName : name).ToList();
            }
        }

        private static string Capitalise(string name)
        {
            var capitalise = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(name);
            return capitalise;
        }
    }
}