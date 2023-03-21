using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_4
{
    public  abstract  class User
    {


     public int UserId;
    public string Type { get; set; }
   public string Name { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
}
