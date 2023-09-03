using Domain.Models;
using Infrastructure.Services;

var studentService = new StudentService();
var groupService = new GroupService();

while (true)
{
    System.Console.WriteLine();
    System.Console.WriteLine("group         open group commands");
    System.Console.WriteLine("student       open student commands");
    System.Console.WriteLine();

    System.Console.Write("Enter command: ");
    string command = Console.ReadLine();

    if (command == "group")
    {
        while (true)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("add            add group");
            System.Console.WriteLine("get            get groups");
            System.Console.WriteLine("getbyid        get group");
            System.Console.WriteLine("update         update group");
            System.Console.WriteLine("delete         delete group");
            System.Console.WriteLine("exit           exit from here");
            System.Console.WriteLine();

            System.Console.Write("Enter command: ");
            string command1 = Console.ReadLine();
            System.Console.WriteLine();

            if (command1 == "add")
            {
                var group = new Group();
                System.Console.Write("Enter group name: ");
                group.GroupName = Console.ReadLine();
                System.Console.WriteLine("Enter title: ");
                group.Title = Console.ReadLine();
                var add = groupService.AddGroup(group);
                System.Console.Write(add);
            }
            else if (command1 == "2")
            {
                System.Console.Write("Enter group ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var gr = groupService.GetGroupWithStudents(id);
                System.Console.WriteLine(gr.GroupName);
                
            }
            else if (command1 == "get")
            {
                var groups = groupService.GetGroups();
                foreach (var group in groups)
                {
                    System.Console.Write("Group name: ");
                    System.Console.WriteLine(group.GroupName);
                    System.Console.Write("Title: ");
                    System.Console.WriteLine(group.Title);
                    System.Console.WriteLine();
                }
            }
            else if (command1 == "update")
            {
                var group = new Group();
                System.Console.Write("Enter ID: ");
                group.Id = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Enter group name: ");
                group.GroupName = Console.ReadLine();
                System.Console.Write("Enter title: ");
                group.Title = Console.ReadLine();
                var update = groupService.UpdateGroup(group);
                System.Console.WriteLine(update);
            }
            else if (command1 == "delete")
            {
                System.Console.Write("Enter ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var delete = groupService.DeleteGroup(id);
                System.Console.WriteLine(delete);
            }
            else if (command1 == "exit")
            {
                break;
            }
        }
    }
    else if (command == "student")
    {
        while (true)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("add            add student");
            System.Console.WriteLine("get            get students");
            System.Console.WriteLine("getbyid        get student");
            System.Console.WriteLine("random         get random student");
            System.Console.WriteLine("update         update student");
            System.Console.WriteLine("delete         delete student");
            System.Console.WriteLine("exit           exit from here");
            System.Console.WriteLine();

            System.Console.Write("Enter command: ");
            string command2 = Console.ReadLine();
            System.Console.WriteLine();

            if (command2 == "add")
            {
                var student = new Student();
                System.Console.Write("Enter firstname: ");
                student.FirstName = Console.ReadLine();
                System.Console.Write("Enter lastname: ");
                student.LastName = Console.ReadLine();
                System.Console.WriteLine("Enter phone: ");
                student.Phone = Console.ReadLine();
                System.Console.WriteLine("Enter group id: ");
                student.GroupId = Convert.ToInt32(Console.ReadLine());
                var add = studentService.AddStudent(student);
                System.Console.Write(add);
                System.Console.WriteLine();
            }
            else if (command2 == "get")
            {
                var students = studentService.GetStudents();
                foreach (var student in students)
                {
                    System.Console.Write("Firstname: ");
                    System.Console.WriteLine(student.FirstName);
                    System.Console.Write("Lastname: ");
                    System.Console.WriteLine(student.LastName);
                    System.Console.Write("Phone: ");
                    System.Console.WriteLine(student.Phone);
                    System.Console.Write("Group ID: ");
                    System.Console.WriteLine(student.GroupId);
                    System.Console.WriteLine();
                }
            }
            else if (command2 == "random")
            {
                var student = studentService.GetRandomStudent();
                System.Console.Write("Firstname: ");
                System.Console.WriteLine(student.FirstName);
                System.Console.Write("Lastname: ");
                System.Console.WriteLine(student.LastName);
                System.Console.Write("Phone: ");
                System.Console.WriteLine(student.Phone);
                System.Console.WriteLine();
            }
            else if (command2 == "update")
            {
                var student = new Student();
                System.Console.Write("Enter ID: ");
                student.Id = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Firstname: ");
                student.FirstName = Console.ReadLine();
                System.Console.Write("Lastname: ");
                student.LastName = Console.ReadLine();
                System.Console.Write("Phone: ");
                student.Phone = Console.ReadLine();
                System.Console.Write("Group ID: ");
                student.GroupId = Convert.ToInt32(Console.ReadLine());
                var update = studentService.UpdateStudent(student);
                System.Console.WriteLine(update);
                System.Console.WriteLine();
            }
            else if (command2 == "delete")
            {
                System.Console.Write("Enter ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var delete = studentService.DeleteStudent(id);
                System.Console.WriteLine(delete);
                System.Console.WriteLine();
            }
            else if (command2 == "exit")
            {
                break;
            }
        }
    }
}