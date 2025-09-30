using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.Entities
{
    [Table(name: "chat_users")]
    public class ChatUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public Guid SenderId { get; set; }

        [ForeignKey("SenderId")]
        public ChatUser Sender { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
