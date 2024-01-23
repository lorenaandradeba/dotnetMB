namespace Escambo.Domain.Entities;
public sealed class Message: BaseEntity
{
    
    public int MessageId { get; set; }
    public string? Text { get; set; }
    public DateTime SendDate { get; set; }

    public int ChatId {get;set;}
    public required Chat Chat {get;set;}
}