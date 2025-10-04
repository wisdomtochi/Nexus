using Nexus.Entities;

namespace Nexus.Services.Interface
{
    public interface IGroupService
    {
        Task AddMemberToGroupAsync(Guid groupId, string memberId);
        Task RemoveMemberFromGroupAsync(Guid groupId, string memberId);
        Task<List<string>> GetGroupMembersAsync(Guid groupId);
        Task SendMessageToGroupAsync(string groupName, string senderId, string message);
        Task<List<Message>> GetGroupMessageHistoryAsync(Guid groupId, int count);
    }
}
