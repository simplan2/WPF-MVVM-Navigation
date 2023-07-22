using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMNavigation.Stores
{
    public class PeopleStore
    {

        public event Action<string> PersonAdded;

        public void AddPerson(string Name)
        {
            PersonAdded?.Invoke(Name);
        }
    }
}
