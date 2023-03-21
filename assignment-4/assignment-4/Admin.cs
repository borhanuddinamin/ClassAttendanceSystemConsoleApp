using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_4
{
    public  class Admin:User
    {
   
       public int AdminId { get; set; }
        public Admin()
        {
          
           

        }



        enum enu
        {
            Account = 1,
            Course,
            AssignSchedule,
            Classschedule
        }
        public void WelcomeAdmin()
        {
        
            // Process.Start("cmd");
            Console.WriteLine(" Welcome To Admin Panel");
        Start:
            Console.WriteLine("  1. Creat Account");
            Console.WriteLine("  2. Create Course");
            Console.WriteLine("  3. Assign Course");
            Console.WriteLine("  4. Class schedule");
            int AdminInput = Convert.ToInt16(Console.ReadLine());
            if (AdminInput == Convert.ToInt16(enu.Account))
            {
                CreatAccount();
                goto Start;
            }
            else if (AdminInput == 2)
            {
                CreatCourse();
                goto Start;
            }
            else if (AdminInput == 3)
            {
                AssignCourse();
                goto Start;
            }
            else if (AdminInput == 4)
            {
                classSchedule();
                goto Start;
            }

        }

       
        public void CreatAccount()
        {
            Console.WriteLine("  Creat Account");
            Console.WriteLine("  1. Teacher");
            Console.WriteLine("  2. Student");
            int AdminInput = Convert.ToInt16(Console.ReadLine());

            if (AdminInput == 1)
            {
                Console.Write("Enter Teacher Name ");
                string teacherName = Console.ReadLine();
                Console.Write("Enter user Name ");
                string teacherUserName = Console.ReadLine();
                Console.Write("Enter password ");
                string teacherPass = Console.ReadLine();

                Creat(teacherName, teacherUserName, teacherPass, AdminInput);

            }
            else if (AdminInput == 2)
            {
                Console.Write("Enter Student Name ");
                string studentName = Console.ReadLine();
                Console.Write("Enter user Name ");
                string studentUserName = Console.ReadLine();
                Console.Write("Enter password ");
                string studentPass = Console.ReadLine();
                Creat(studentName, studentUserName, studentPass, AdminInput);
            }
        }


        public void CreatCourse()
        {
            Console.Write("Enter Course Name ");
            string CourseName = Console.ReadLine();
            Console.Write("Enter Course Fees ");
            string Coursefees = Console.ReadLine();

            Creat(CourseName, Coursefees);
        }

        private void AssignCourse()
        {
            Console.Write("Assign a Course To ");

            Console.Write("1. Teacher ");
            Console.Write("2. Student ");
            int AssignNo = Convert.ToInt16(Console.ReadLine());

            if (AssignNo == 1)
            {
                Console.WriteLine("Teacher UserName ");
                string A_UserNameTeacher = Console.ReadLine();
                Console.Write("Course Name ");
                string A_CourseName = Console.ReadLine();
                Assigncourse((A_UserNameTeacher, A_CourseName, AssignNo));

            }
            if (AssignNo == 2)
            {
                Console.WriteLine("Student UserName ");
                string A_UserNameStudent = Console.ReadLine();
                Console.Write("Course Name ");
                string A_CourseName = Console.ReadLine();
                Assigncourse((A_UserNameStudent, A_CourseName, AssignNo));
            }

        }
        private void classSchedule()
        {



            Console.WriteLine("  class schedule for a course");
            Console.Write(" course Name: ");
            var courseName = Console.ReadLine().Trim();
            Console.Write("course Days in a week: ");
            var courseInWeek = Convert.ToInt16(Console.ReadLine().Trim());
            Console.WriteLine("  example, Sunday 8PM - 10PM");

            string[] DayandTime = new string[courseInWeek];
            int i = 0;
            while (i < courseInWeek)
            {
                Console.Write("course Day and Time: ");
                string dayandTime = Console.ReadLine();
                DayandTime[i] = dayandTime;
                i++;
            }
            Console.Write("\n Tottal Class ");
            var tottalClass = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("  Class start Date ");
            DateTime ClassstartDate = DateTime.Parse(Console.ReadLine());
            int classStart = 1;
            DateTime[] Startclasses = classSchedule(new { courseInWeek, DayandTime, tottalClass, ClassstartDate, classStart });
             classStart = 2;

           
            DateTime[] Endclasses = classSchedule(new { courseInWeek, DayandTime, tottalClass, ClassstartDate, classStart });
            ScheduleCreat(new { courseName, tottalClass, Startclasses, Endclasses });

        }





        private void Creat(params object[] obj)
        {
            InstituteDb context = new InstituteDb();
            if (obj.Length>2)
            {
                if (Convert.ToInt32(obj[3]) == 1)
                {
                    string teacher = "Teacher";
                    Teacher NewTeacher = new Teacher(obj[0].ToString(), obj[1].ToString().ToLower(), obj[2].ToString(), teacher);
                    context.Teacher.Add(NewTeacher);

                }
                else if (Convert.ToInt32(obj[3]) == 2)
                {
                    string student = "Student";
                    Student NewStudent = new Student(obj[0].ToString(), obj[1].ToString().ToLower(), obj[2].ToString(), student);
                    context.Student.Add(NewStudent);
                   

                }

            }
            
           
            
            
            if (obj.Length == 2)
            {
                Course NewCourse = new Course(obj[0].ToString().ToLower(), Convert.ToInt16(obj[1]));
                context.Course.Add(NewCourse);
        
            }
            
           

            context.SaveChanges();
            Console.WriteLine("Susscessful  creat");

            
        }


        private void Assigncourse((string, string, int) assign)
        {
            InstituteDb context = new InstituteDb();


            if (assign.Item3 == 1)
            {
                var data = context.Teacher.Where(s => s.UserName == assign.Item1).FirstOrDefault();
                var data2 = context.Course.Where(s => s.CourseName == assign.Item2).FirstOrDefault();
                AssignTeacher assignTeacher = new AssignTeacher
                {
                    TeacherId = data.UserId,
                    CourseId = data2.CourseId
                };
                context.AssignTeacher.Add(assignTeacher);

            }

            else if (assign.Item3 == 2)
            {
                var data = context.Student.Where(s => s.UserName == assign.Item1).FirstOrDefault();
                var data2 = context.Course.Where(s => s.CourseName == assign.Item2).FirstOrDefault();
                AssignStudent assignStudent = new AssignStudent
                {
                    StudentId = data.UserId,
                    CourseId = data2.CourseId
                };
                context.AssignStudent.Add(assignStudent);

            }


            context.SaveChanges();
            Console.WriteLine("Susscessful  Assign Course");
        }



        private void ScheduleCreat(dynamic Schedule)
        {
            

            string CourseName = Schedule.courseName.ToLower();
            InstituteDb context = new InstituteDb();

            var data = context.Course.Where(s => s.CourseName == CourseName).FirstOrDefault();

            //var data2 = context.ClassSchedule.Where(s => s.CourseId==data.CourseId).Include(s => s.ClassScheduleId).ToList();

            data.TottalClass = Schedule.tottalClass;




            int v = 0;
            for (int n = 0; n < Schedule.Startclasses.Length; n++)
            {
               
                string Dayofweek = Schedule.Startclasses[n].DayOfWeek.ToString();


                ClassSchedule newschedule = new ClassSchedule(data.CourseId, Dayofweek, Schedule.Startclasses[n], Schedule.Endclasses[n], n + 1);

                context.ClassSchedule.Add(newschedule);



            }

            context.SaveChanges();

            Console.WriteLine("Susscessful  Schedule create");



        }





        private DateTime[] classSchedule(dynamic classSchedulestart)

        {

            DateTime[] weekClass = new DateTime[classSchedulestart.courseInWeek];


            int ii = 0;
            string[] CourseDayss = new string[classSchedulestart.courseInWeek * 3];
            foreach (var ss in classSchedulestart.DayandTime)
            {

                string[] CourseDays = ss.Split(" ");
                int j = 0;
                 
                foreach (var er in CourseDays)
                {
                    if (ii >= (classSchedulestart.courseInWeek * 3))
                    {
                        break;
                    }
                        CourseDayss[ii] = CourseDays[j];
                    ii++;
                    j++;
                }

            }
            DateTime[] Startweeks = new DateTime[classSchedulestart.tottalClass];
            DateTime[] Endweeks = new DateTime[classSchedulestart.tottalClass];

            DateTime[] Demo = new DateTime[1];
            Demo[0] = classSchedulestart.ClassstartDate;
   


            int yy = 0;
            int z = 0;



            for (int d = 0; d < classSchedulestart.tottalClass;)
            {

                if (yy > (CourseDayss.Length - 2))
                {
                    yy = 0;
                }

                if (string.Equals((Demo[0].DayOfWeek).ToString().ToUpper(), CourseDayss[yy].ToString().ToUpper()))
                {
                    DateTime time = DateTime.ParseExact(CourseDayss[yy + 1], "htt", CultureInfo.InvariantCulture);
                    DateTime time2 = DateTime.ParseExact(CourseDayss[yy + 2], "htt", CultureInfo.InvariantCulture);
                    Demo[0] = Demo[0].Date;
                    Endweeks[z] = Demo[0];
                    Demo[0] = Demo[0].AddHours(time.Hour);

                    Startweeks[z] = Demo[0];
                    Endweeks[z] = Endweeks[z].AddHours(time2.Hour);
                    Demo[0] = Demo[0].Date.AddDays(1);


                    z++;
                    d++;


                    yy = yy + 3;


                }
                else
                {

                    Demo[0] = Demo[0].AddDays(1);

                }





            }
            
            DateTime[] returnArrray = new DateTime[Startweeks.Length];
            if (classSchedulestart.classStart == 1)
            {
                returnArrray = Startweeks;

            }
            else if (classSchedulestart.classStart == 2)
            {
                returnArrray = Endweeks;
            }
            return returnArrray;

        }






















    }



}
