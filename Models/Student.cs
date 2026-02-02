namespace Labb3_SQL_ORM.Models;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string PersonalNumber { get; set; } = null!;

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }
}
