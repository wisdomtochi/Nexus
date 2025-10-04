using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public UserAccount User { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<GroupMember> Members { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
