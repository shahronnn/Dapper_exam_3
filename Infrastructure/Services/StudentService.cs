using Infrastructure.Data;
using Npgsql;
using Dapper;
using Domain.Models;
namespace Infrastructure.Services;

public class StudentService
{
    private readonly DataContext _context;
    public StudentService()
    {
        _context = new DataContext();
    }
    public string AddStudent(Domain.Models.Student student)
    {
        using (var connection = _context.CreateConnection())
        {
            string sql = $"insert into students(firstname, lastname, phone, groupid) values('{student.FirstName}', '{student.LastName}', '{student.Phone}', {student.GroupId})";
            var response  = connection.Execute(sql);
            if (response == 1)
            {
                return "Student added!";
            }
            return "Error";
        }
    }
    public List<Domain.Models.Student> GetStudents()
    {
        using (var connection = _context.CreateConnection())
        {
            var sql = "select * from students";
            var response = connection.Query<Domain.Models.Student>(sql);
            return response.ToList();
        }
    }
    public string GetStudentById(int id)
    {
        using (var connection = _context.CreateConnection())
        {
            var sql = $"select * from students where id = {id}";
            var response = connection.QueryFirstOrDefault(sql);
            return response;
        }
    }
    public string UpdateStudent(Domain.Models.Student student)
    {
        using (var connection = _context.CreateConnection())
        {
            string sql = $"update students set firstname = '{student.FirstName}', lastname = '{student.LastName}', phone = '{student.Phone}', groupid = {student.GroupId} where id = {student.Id}";
            var response = connection.Execute(sql);
            if (response == 1)
            {
                return "Student Updated!";
            }
            return "Error";
        }
    }
    public string DeleteStudent(int id)
    {
        using (var connection = _context.CreateConnection())
        {
            var sql = $"delete students where id = {id}";
            var response = connection.Execute(sql);
            if (response == 1)
            {
                return "Student deleted!";
            }
            return "Error";
        }
    }
    public List<Student> GetStudentsByGroup(int id)
    {
        using (var connection = _context.CreateConnection())
        {
            var sql = $"select * from students where groupid = {id}";
            var response = connection.Query<Student>(sql);
            return response.ToList();
        }
    }
    public Student GetRandomStudent()
    {
        using (var connection = _context.CreateConnection())
        {
            var sql = "select * from students order by random() limit 1";
            var response = connection.QueryFirstOrDefault<Student>(sql);
            return response;
        }
    }
    public List<StudentsWithGroupNameDTO> GetStudentsWithGroupName()
    {
        using (var connection = _context.CreateConnection())
        {
            var sql = $"select concat(firstname, ' ', lastname) as Name, groups.groupname from students join groups on groups.id = students.groupid";
            var response = connection.Query<StudentsWithGroupNameDTO>(sql);
            return response.ToList();
        }
    }
}
