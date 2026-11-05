using Sharek.API.Areas.OrdersAndCommunication.Models;

public class Conversation
{
    public int ConversationId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastMessageAt { get; set; }
    public ICollection<Message> Messages { get; set; }
    public ICollection<ConversationParticipant> Participants { get; set; }
}