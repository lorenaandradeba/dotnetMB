namespace Escambo.Dommain.Model;

public abstract class BaseEntity
{
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Updated { get; set; }
    public DateTimeOffset Deleted { get; set; }

}
