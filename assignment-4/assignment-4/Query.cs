using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace assignment_4
{
    public class Query:User
    {

        public string _UserName { get; set; }
        public string _password { get; set; }

        public Query(string username, string password) : this()
        {
            _UserName = username;
            _password = password;

        }
        public Query()
        {


        }

        public bool LoginCheck(int id)
        {
            bool check =false;
            if (_UserName == null || _password == null || id == null)
            {
                return check;
            }


            InstituteDb context = new InstituteDb();

            if (id == 1)
            {
                var user = context.User.Where(u => u.UserName.Equals(_UserName)&&  u.Password.Equals(_password) && u.Type == "Admin").FirstOrDefault() ;
               
                
              
                
                if (user !=null ) 
                { return check = true; 
                }
            }
            else if (id == 2)
            {
                var user = context.User.Where(u => u.UserName == _UserName && u.Password == _password && u.Type == "Teacher").FirstOrDefault();
                if (user != null) { check = true; }
            }
            else if (id == 3)
            {
                var user = context.User.Where(u => u.UserName == _UserName && u.Password == _password && u.Type == "Student").FirstOrDefault();
                if (user != null) { check = true; }
            }


            return check;

       
        
        }
    }
}
