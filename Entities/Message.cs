using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.Entities
{
    [Table(name: "messages")]
    public class Message
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        
        public string SenderId { get; set; }
        [ForeignKey("SenderId")]
        public UserAccount Sender { get; set; }
        
        public string? ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public UserAccount Receiver { get; set; }
        
        public Guid? GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
