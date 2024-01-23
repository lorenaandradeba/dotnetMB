namespace Escambo.Domain.Entities;

public sealed class Poster: BaseEntity{
    
    public int PosterId { get; set; }
    public int UserId { get; set; }
    public required User User {get; set;}

    public int ServiceId { get; set; }
    public required Service Service { get; set; }    
}