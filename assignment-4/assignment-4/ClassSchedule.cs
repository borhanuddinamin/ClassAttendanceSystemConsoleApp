using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_4
{
    public  class ClassSchedule
    {
        public int ClassScheduleId { get; set; }

        public int CourseId { get; set; }
        public String Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NumberofClass { get; set; }



        public ClassSchedule(int CourseId, string Day, DateTime StartTime, DateTime EndTime, int NumbersClass) : this(CourseId, Day, StartTime, EndTime)
        {

            this.NumberofClass = NumbersClass;



        }
        public ClassSchedule(int CourseId, string Day, DateTime StartTime, DateTime EndTime) : this(CourseId, StartTime, EndTime)
        {
            this.Day = Day;




        }
        public ClassSchedule(int CourseId, DateTime StartTime, DateTime EndTime) : this()
        {
            this.CourseId = CourseId;
            this.StartTime = StartTime;
            this.EndTime = EndTime;



        }
        public ClassSchedule()
        {





        }

    }
}
