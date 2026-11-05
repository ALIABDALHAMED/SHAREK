public class Message
{
    public int MessageId { get; set; }
    public int SenderUserId { get; set; }
    public int ConversationId { get; set; }
    public string Content { get; set; }
    public bool IsRead { get; set; }
    public DateTime SentAt { get; set; }
}