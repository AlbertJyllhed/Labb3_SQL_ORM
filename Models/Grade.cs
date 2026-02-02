namespace Labb3_SQL_ORM.Models;

public partial class Grade
{
    public int? StudentId { get; set; }

    public int? ClassId { get; set; }

    public string Score { get; set; } = null!;

    public DateOnly? GradingDate { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Student? Student { get; set; }
}
