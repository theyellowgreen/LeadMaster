namespace LeadMaster.Persistance;

public class ChatMessage
{
    public Guid Id { get; set; }
    
    public required Chat Chat { get; set; }
    
    public bool IsClient { get; set; }
    
    public required string MessageContent { get; set; }
}