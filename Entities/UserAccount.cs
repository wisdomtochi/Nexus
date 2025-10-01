using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.Entities
{
    [Table(name: "chat_users")]
    public class UserAccount
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
