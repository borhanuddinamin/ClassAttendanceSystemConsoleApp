using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_4
{
    public  class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }
        //public string CourseCode { get; set; }
        public int Fees { get; set; }
        public int TottalClass { get; set; }
      
      
        public AssignTeacher AssignTeacher { get; set; }
                                                         





        public Course(string name, int fees, int TottalClass) : this(name, fees)
        {
            this.TottalClass = TottalClass;


        }
        public Course(string name, int fees) : this()
        {
            this.CourseName = name;
            this.Fees = fees;

        }


        public Course()
        {


        }
    }
}
