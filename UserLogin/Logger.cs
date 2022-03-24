using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class Logger
    {
       static private List<string> currentSessionActivities = new List<string>();
        static public void LogActivity(string activity)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now + "; ");
            sb.Append(LoginValidation.CurrentUserUsername + "; ");
            sb.Append(LoginValidation.CurrentUserRole + "; ");
            sb.Append(activity).Append(Environment.NewLine);

            string activityLine = sb.ToString();

            currentSessionActivities.Add(activityLine);

            if (File.Exists("../../../Logs.txt"))
            {
                
                File.AppendAllText("../../../Logs.txt", activityLine);
            }
        }
        public static IEnumerable<string> GetLogActivities() 
        {
            StreamReader sr = new StreamReader("../../../Logs.txt");
            string line = String.Empty;
            IEnumerable<string> LogActivity = sr.ReadToEnd().Split(new char[] { '\u002C' });
            StringBuilder sb = new StringBuilder();

            

             sr.Close();
            return LogActivity;
        }
        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            return from activity in currentSessionActivities 
                   where activity.Contains(filter)
                   select activity;
            
        }

    }
}
