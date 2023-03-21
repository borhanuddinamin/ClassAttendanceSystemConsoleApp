using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_4
{
    public  class Attendance
    {
      
        public int AttendanceId { get; set; }

        

         public int StudentId { get; set; }
        
          public int CourseId { get; set; }
        

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Ispresent { get; set; }



        public Attendance(int StudentId, int courseId):this()
        {
            this.StudentId = StudentId;
            this.CourseId = courseId;


        }

        public Attendance()
        {


        }


        public bool IsPresent(int CourseId)
        {
            bool ispresent = false;
            InstituteDb context = new InstituteDb();
            DateTime currentTime = DateTime.Now;
            var classSchedule = context.ClassSchedule.Where(s => s.CourseId == CourseId && s.StartTime < currentTime && s.EndTime> currentTime).FirstOrDefault();
            

            if (classSchedule == null)
            {
                Console.WriteLine("you have no class in Time.");
                ispresent = false;
            }else if (classSchedule != null)
            {
                Console.WriteLine("Are you Present ");
                Console.Write("Yes or No ");
                string present = Console.ReadLine().ToLower();
                if (present != "yes" && present != "no")
                {
                    Console.WriteLine("you are wrong input");

                }
                else if (present == "no")
                {
                    Console.WriteLine("Okay");
                    
                }
                else if(present=="yes")
                {
                    ispresent = true;

                }


            }
          
            


            return ispresent;

            }

        }




        }








   

