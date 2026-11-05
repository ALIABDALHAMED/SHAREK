public class ConversationParticipant
{
    public int UserId { get; set; }
    public int ConversationId { get; set; }
    public DateTime JoinedAt { get; set; }
    public DateTime LastReadAt { get; set; }
}