namespace LeadMaster.Persistance;

public class Chat
{
    public Guid Id { get; set; } = Guid.Empty;
    
    public required string ChatDescription { get; set; }

    public List<ChatMessage> Messages { get; set; } = [];
}