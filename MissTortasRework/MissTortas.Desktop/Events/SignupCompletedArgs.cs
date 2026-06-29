using MissTortas.Desktop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Events
{
    public class SignupCompletedArgs(User user) : EventArgs
    {
        public User User
        {
            get { return user; }
        }
    }
}
