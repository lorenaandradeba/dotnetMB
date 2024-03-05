namespace Escambo.Domain.Entities;

public abstract class BaseEntity
{
    //public int Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Updated { get; set; }
    public DateTimeOffset Deleted { get; set; }

}
