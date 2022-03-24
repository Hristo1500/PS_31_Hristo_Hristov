using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            
            bool displayMenu = true;
            User user = null;

            LoginValidation LoginValidation = new LoginValidation(username,
                password,ActionOnError);


            if (LoginValidation.ValidateUserInput(ref user))
            {
                Console.WriteLine("Name: " + user.Username + "\nPassword: " + user.Password + "\nFaculty Number: " +
                    user.FacNumber + "\nRole: " + user.Role);

                switch (Convert.ToInt32(LoginValidation.CurrentUserRole))
                {
                    case 0:
                        Console.WriteLine("Role: Anonymos");
                        break;
                    case 1:
                        Console.WriteLine("Role: Admin");
                        while (displayMenu)
                        {
                            displayMenu = DisplayAdminMenu();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Role: Inspector");
                        break;
                    case 3:
                        Console.WriteLine("Role: Professor");
                        break;
                    case 4:
                        Console.WriteLine("Role: Student");
                        break;
                }

            }
           
        }
        public static bool DisplayAdminMenu()
        {


            string username;
            Console.WriteLine("Choose an option");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change the role of User");
            Console.WriteLine("2: Change the activity of User");
            Console.WriteLine("3: Show all users");
            Console.WriteLine("4: Show log activity");
            Console.WriteLine("5: Show log current activity");
            int optionNumber =Int32.Parse(Console.ReadLine());
            
           
            switch (optionNumber)
            {
                case 0:
                    Console.WriteLine("Exited");
                    return false;
           
                case 1:
                    Console.WriteLine("User: ");
                    username = Console.ReadLine();
                    Console.WriteLine("New Role: ");
                    UserRoles newRole = (UserRoles)Convert.ToInt32(Console.ReadLine());
                    UserData.AssignUserData(username, newRole);
                    return true;
                    
                case 2:
                    Console.WriteLine("User: ");
                    username = Console.ReadLine();
                    Console.WriteLine("Activity expires on: ");
                    string dateStr = Console.ReadLine();
                    DateTime date = DateTime.Parse(dateStr);
                    UserData.SetUserActiveTo(username, date);
                    return true;
                case 3:

                    return true;
                case 4:
                    PrintLogSessionActivities();
                    return true;
                case 5: 
                   string filter = Console.ReadLine();
                   PrintCurrentSessionActivities(filter);
                    return true;
            }
            return false;

        }
        public static void PrintCurrentSessionActivities(string filter)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> currentActivities =
                Logger.GetCurrentSessionActivities(filter);

            foreach (string message in currentActivities)
            {
                sb.Append(message).Append(Environment.NewLine);
            }
            Console.WriteLine(sb.ToString());
        }
        public static void PrintLogSessionActivities()
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<string> LogActivity =
                Logger.GetLogActivities();
            foreach (string message in LogActivity)
            {
                sb.Append(message).Append(Environment.NewLine);
            }

            Console.WriteLine(sb.ToString());
        }
        public static void ActionOnError(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }
    }
}
