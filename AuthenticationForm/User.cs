using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationForm
{
    class User
    {
        public string Name { get; private set; }
        public string Password { get; private set; }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public User()
        {
            Name = null;
            Password = null;
        }




    }
}
