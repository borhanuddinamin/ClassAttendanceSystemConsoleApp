namespace assignment_4
{
    public class Teacher : User
    {
        public int TeacherId { get; set; }





        public Teacher(string name, string userName, string password, string Type) : this(userName, password, Type)
        {
            this.Name = name;

        }
        public Teacher(string userName, string password, string Type) : this()
        {

            this.UserName = userName;
            this.Password = password;
            this.Type = Type;
        }
        public Teacher()
        {


        }


        public void WelcomeTeacher(string username)
        {
         
            Console.WriteLine("Welcome To Teacher panel");
        start:
            Console.WriteLine("Choise  your course");
            TeacherCourse(username);
            Console.Write("Enter course ID: ");
            int courseid = int.Parse(Console.ReadLine());
            AttendanceReport(courseid);
              goto start;
        }


        InstituteDb context = new InstituteDb();
        public void TeacherCourse(string username)
        {
           
            var userId = context.User.Where(s => s.UserName == username && s.Type == "Teacher").FirstOrDefault();

           var  TId = userId.UserId;
            var courses = context.AssignTeacher.Where(s => s.TeacherId == TId).ToList();
            foreach ( var ss in courses)
            {
                var data = context.Course.Where(s => s.CourseId == ss.CourseId).FirstOrDefault();
                Console.WriteLine($"{data.CourseId}  {data.CourseName}");

            }
        }


        public void AttendanceReport(int courseid)
        {
            var data =context.AssignStudent.Where(s => s.CourseId == courseid).ToList();
            var data1 = context.Course.Where(s => s.CourseId == courseid).FirstOrDefault();
            Console.WriteLine($"Course Id: {data1.CourseId}   Course Name: {data1.CourseName} ");
            DateTime now = DateTime.Now;

            var cross = "X" ;
            var RIGHT = "\u2713";
            Console.WriteLine($"Class No:  Student Name   Date     Time     Present");
            foreach ( var c in data)
            {
                
                var data2 = context.Attendance.Where(s => s.CourseId == c.CourseId && s.StudentId == c.StudentId).FirstOrDefault();
                var Name = context.User.Where(s => s.UserId == c.StudentId && s.Type == "Student").FirstOrDefault();
                var Classes = context.ClassSchedule.Where(s => s.CourseId == c.CourseId && s.StartTime.Date == now.Date).FirstOrDefault();

                
                
                
                if (data2 == null&& Classes.StartTime<now)
                {
                    
                    Console.WriteLine($"  {Classes.NumberofClass}        {Name.UserName}     {Classes.StartTime}   {cross}");

                }
                else if ( data2 != null&& Classes.StartTime < now)
                {
                    
                    Console.WriteLine($"  {Classes.NumberofClass}        {Name.UserName}     {data2.StartTime}   {RIGHT}");

                }



            }

        }





    }
}
