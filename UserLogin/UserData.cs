using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UserLogin
{
    public static class UserData
    {

        static List<User> _testUsers;
        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        static private void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>();

                User user1 = new User();
                user1.Username = "Todor";
                user1.Password = "123123";
                user1.FacNumber = "121219000";
                user1.Role = UserRoles.ADMIN;
                user1.CreatedDate = DateTime.Now;
                user1.ActiveTo = DateTime.MaxValue;
                _testUsers.Add(user1);

                User user2 = new User();
                user2.Username = "Gosho";
                user2.Password = "123456Q";
                user2.FacNumber = "121219001";
                user2.Role = UserRoles.STUDENT;
                user2.ActiveTo = DateTime.MaxValue;
                _testUsers.Add(user2);

                User user3 = new User();
                user3.Username = "Pesho";
                user3.Password = "102030!!";
                user3.FacNumber = "121219002";
                user3.Role = UserRoles.STUDENT;
                user3.CreatedDate = DateTime.Now;
                user3.ActiveTo = DateTime.MaxValue;
                _testUsers.Add(user3);
            }
        }
        public static void AssignUserData(string username, UserRoles role)
        {
            foreach (User user in _testUsers)
            {
                if(user.Username.Equals(username))
                {
                    user.Role = role;
                }
            }
            Console.WriteLine("Gsgdisaddksagh");
            Logger.LogActivity("Changed " + username+" to "+role);
        }
        public static void SetUserActiveTo(string username,DateTime date)
        {
            foreach(User user in _testUsers)
            {
                if (user.Username.Equals(username)){
                    user.ActiveTo = date;
                   
                }
            }

            Logger.LogActivity("Changed activity " + username);
        }
        public static User IsUserPassCorrect(string Username,string Password)
        {
           
            return (from t in TestUsers
                   where t.Username.Equals(Username) && t.Password.Equals(Password)
                   select t).First();

            
        }
    }
}
