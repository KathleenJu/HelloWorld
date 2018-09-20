using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
    public class Names
    {
        private List<string> _currentNames;
        private const string _permanentUser = "Kathleen";

        public Names()
        {
            _currentNames = new List<string> { _permanentUser};
        }

        public IEnumerable<string> GetNames()
        {
            return _currentNames;
        }
        
        public void AddName(string name)
        {
            if (!_currentNames.Contains(name))
            {
                _currentNames.Add(name);
            }

        }

        public void RemoveName(string name)
        {
            if (_currentNames.Contains(name) & name != _permanentUser)
            {
                _currentNames.Remove(name);
            }

        }

        public void UpdateUser(string nameToBeUpdated, string newName)
        {
            _currentNames = _currentNames.Select(name => name == nameToBeUpdated ? newName : name).ToList();

        }
    }
}