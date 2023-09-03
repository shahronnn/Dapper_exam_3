using Microsoft.VisualBasic;

namespace Domain.Models;

public class GroupWithStudentsDTO : Group
{
    public List<Student> Students { get; set; }
}
