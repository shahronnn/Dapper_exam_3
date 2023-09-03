using System.Text.RegularExpressions;
using Npgsql;
using Dapper;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class GroupService
{
    private readonly DataContext _context;
    public GroupService()
    {
        _context = new DataContext();
    }
    public string AddGroup(Domain.Models.Group group)
    {
        using (var connection = _context.CreateConnection())
        {
            string sql = $"insert into groups(groupname, title) values('{group.GroupName}', '{group.Title}')";
            var response  = connection.Execute(sql);
            if (response == 1)
            {
                return "Group added!";
            }
            return "Error";
        }
    }
    public List<Domain.Models.Group> GetGroups()
    {
        using (var connection = _context.CreateConnection())
        {
            var sql = "select * from groups";
            var response = connection.Query<Domain.Models.Group>(sql);
            return response.ToList();
        }
    }
    public string GetGroupById(int id)
    {
        using (var connection = _context.CreateConnection())
        {
            var sql = $"select * from groups where id = {id}";
            var response = connection.QueryFirstOrDefault(sql);
            return response;
        }
    }
    public string UpdateGroup(Domain.Models.Group group)
    {
        using (var connection = _context.CreateConnection())
        {
            string sql = $"update groups set groupname = '{group.GroupName}', title = '{group.Title}' where id = {group.Id}";
            var response = connection.Execute(sql);
            if (response == 1)
            {
                return "Group Updated!";
            }
            return "Error";
        }
    }
    public string DeleteGroup(int id)
    {
        using (var connection = _context.CreateConnection())
        {
            var sql = $"delete groups where id = {id}";
            var response = connection.Execute(sql);
            if (response == 1)
            {
                return "Group deleted!";
            }
            return "Error";
        }
    }
    // public List<GroupWithStudentsDTO> GetGroupsWithStudents()
    // {
    //     using (var connection = _context.CreateConnection())
    //     {
    //         var sql = $"select groupname from groups;";
    //         var sqlen = $"select concat(firstname, ' ', lastname) from students";
    //         var response = connection.QueryFirstOrDefault<GroupWithStudentsDTO>(sql);
    //         var ress = connection.Query<GroupWithStudentsDTO>(sqlen).ToList();
    //         return response;
    //     }
    // }
    public GroupWithStudentsDTO GetGroupWithStudents(int id)
    {
        using (var connection = _context.CreateConnection())
        {
            var sql = $"select groupname from groups where id = {id};";
            var sqlen = $"select concat(firstname, ' ', lastname) from students where groupid = {id}";
            var response = connection.QueryFirstOrDefault<GroupWithStudentsDTO>(sql);
            var ress = connection.Query<GroupWithStudentsDTO>(sqlen).ToList();
            return response;
        }
    }
}