using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UserLogin
{
    public class LoginValidation
    {
        static public UserRoles CurrentUserRole { get; private set; }
        private string _username;
        private string _password;
        private string _errorMessage;
        private int minLength = 5;

        public static string CurrentUserUsername { get; private set; }
        public static string CurrentErrorMessage { get; private set; }


        public delegate void ActionOnError(string errorMsg);
        private ActionOnError _errorFunction;

        public LoginValidation(string username,string password,ActionOnError errorFunction)
        {
            _username = username;
            _password = password;
            _errorFunction = errorFunction;
        }
        public bool ValidateUserInput(ref User user)
        {

            Boolean emptyUserName;
            emptyUserName = _username.Equals(String.Empty);
            if (emptyUserName)
            {
                _errorMessage = "Username is blank";
                CurrentErrorMessage = "Username is blank";
                _errorFunction(_errorMessage);
                CurrentUserRole = UserRoles.ANONYMOUS;
               
                return false;
            }
            Boolean emptyPassword;
            emptyPassword = _username.Equals(String.Empty);
            if (emptyPassword)
            {
                _errorMessage = "Password is blank";
                CurrentErrorMessage = "Password is blank";
                _errorFunction(_errorMessage);
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            if (_username.Length<minLength)
            {
                _errorMessage = "Username is too short";
                CurrentErrorMessage = "Username is too short";
                _errorFunction(_errorMessage);
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
            if (_password.Length<minLength)
            {
                _errorMessage = "Password is too short";
                CurrentErrorMessage = "Password is too short";
                _errorFunction(_errorMessage);
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            user = UserData.IsUserPassCorrect(_username, _password);
                if(user == null)
            {
                _errorMessage = "Username is not found. Please check your username or password";
                CurrentErrorMessage = "Username is not found. Please check your username or password";
                _errorFunction(_errorMessage);
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            



            

            CurrentUserRole = (UserRoles)user.Role;
            CurrentUserUsername = _username;
            Logger.LogActivity("Successful Login");
            return true;
        }
    }
}
