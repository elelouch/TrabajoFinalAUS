using MissTortas.Desktop.Model;

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
