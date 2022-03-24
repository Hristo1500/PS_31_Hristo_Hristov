using System;
namespace UserLogin
{
    public class User
    {

        public String Username { get; set; }
        public String Password { get; set; }
        public String FacNumber { get; set; }
        public UserRoles Role { get; set; }
       public DateTime CreatedDate { get; set; }
        public DateTime ActiveTo { get; set; }  
    }
}