using assignment_4;

Console.Title = "Deen Institute";

Console.WriteLine("  Assalamu Alikum");
Console.WriteLine("    Deen Institude\n");
Console.WriteLine("Please Confirm your Identity by number");
Console.Write($"1. Admin");
Console.Write($" 2. Teacher");
Console.Write($" 3. Student\n");
Console.Write($"You are ");
int Identity = Convert.ToInt16(Console.ReadLine());
start:
Console.Write("Pleae Enter User Name: ");
string userName = Console.ReadLine();
Console.Write("Pleae Enter Password: ");
string Password = Console.ReadLine();
Query login = new Query(userName, Password);

bool logins = login.LoginCheck(Identity);

switch(logins )
{
    case true:
        distribution();
        break;

    case false:
        Console.WriteLine("You are wrong input");
        goto start;
        break;


}

void distribution()
{
    switch (Identity)
    {
        case 1:
            Admin admin = new Admin();
            admin.WelcomeAdmin();
            break;

        case 2:
            Teacher Te = new Teacher();
            Te.WelcomeTeacher(userName);
            break;
        case 3:
           
            Student stu = new Student();
            stu.WelcomeStudent(userName);
            break;

        default:
            break;
    }

}





