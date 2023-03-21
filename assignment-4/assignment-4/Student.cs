using Microsoft.EntityFrameworkCore;
using System;
using Twilio.TwiML.Voice;

namespace assignment_4
{
    public class Student : User
    {

        public int StudentId { get; set; }
       






        public Student(string name, string username, string pass, string Type) : this(username, pass, Type)
        {
            this.Name = name;


        }
        public Student(string username, string pass, string Type) : this()
        {

            this.UserName = username;
            this.Password = pass;
            this.Type = Type;

        }

        public Student()
        {

        }



        public void WelcomeStudent(string userName)
        {
            start:
            Console.WriteLine("Chose your Course for Attendance");
            int stuId= studentCourse(userName);
            Console.Write("Enter CourseId ");
            var CourseId = int.Parse(Console.ReadLine());
            Attendance Present= new Attendance(stuId, CourseId);
            bool ispresent= Present.IsPresent(CourseId);

            if (ispresent == false)
            {
                //Environment.Exit(0);
                goto start;


            }
            else
            {
                AssignAttandence(stuId, CourseId, ispresent);
                goto start;
            }
            





        }


        public int  studentCourse(string userName)
        {

            InstituteDb context = new InstituteDb();

            var data = context.Student.Where(s => s.UserName == userName).FirstOrDefault();
            var data2 = context.AssignStudent.Where(s => s.StudentId == data.UserId).ToList();


            foreach( var ss in data2)
            {
                var courseName = context.Course.Where(s => s.CourseId == ss.CourseId).FirstOrDefault();
                Console.WriteLine($"{courseName.CourseId}   {courseName.CourseName}");

            }


            return data.UserId;
        }


        public void AssignAttandence(int stuId,int CourseId, bool ispresent)
        {
            InstituteDb context = new InstituteDb();
            DateTime current = DateTime.Now;
            //var data = context.ClassSchedule.Where(x => x.CourseId == CourseId && x.StartTime <= current && x.EndTime >= current).FirstOrDefault();
            var classSchedule = context.ClassSchedule.Where(s => s.CourseId == CourseId && s.StartTime.Date < current && s.EndTime > current).FirstOrDefault();
            Attendance attendanceAdd = new Attendance();
            attendanceAdd.StudentId = stuId;
            attendanceAdd.CourseId = CourseId;
            attendanceAdd.StartTime = classSchedule.StartTime;
            attendanceAdd.EndTime = classSchedule.EndTime;
            attendanceAdd.Ispresent = ispresent;
            context.Attendance.Add(attendanceAdd);
            context.SaveChanges();

            Console.WriteLine("your Present Done");

        }





    }
}
