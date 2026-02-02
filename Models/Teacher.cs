namespace Labb3_SQL_ORM.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual Employee? Employee { get; set; }
}
