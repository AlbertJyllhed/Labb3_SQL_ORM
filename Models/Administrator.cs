namespace Labb3_SQL_ORM.Models;

public partial class Administrator
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
