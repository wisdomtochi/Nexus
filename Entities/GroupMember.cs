using System.ComponentModel.DataAnnotations.Schema;

namespace Nexus.Entities
{
    public class GroupMember
    {
        public Guid Id { get; set; }

        public string MemberId { get; set; }
        [ForeignKey("MemberId")]
        public UserAccount Member { get; set; }

        public Guid GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
    }
}
