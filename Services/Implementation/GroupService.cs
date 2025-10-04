using Microsoft.EntityFrameworkCore;
using Nexus.Data.GenericRepository;
using Nexus.Entities;
using Nexus.Services.Interface;

namespace Nexus.Services.Implementation
{
    public class GroupService(IGenericRepository<Group> groupRepository, IGenericRepository<Message> messageRepository) : IGroupService
    {
        public Task AddMemberToGroupAsync(Guid groupId, string memberId)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetGroupMembersAsync(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> GetGroupMessageHistoryAsync(Guid groupId, int count)
        {
            throw new NotImplementedException();
        }

        public Task RemoveMemberFromGroupAsync(Guid groupId, string memberId)
        {
            throw new NotImplementedException();
        }

        public async Task SendMessageToGroupAsync(string groupName, string senderId, string message)
        {
            var group = await groupRepository.ReadAllQuery().FirstOrDefaultAsync(x => x.Name.ToLower() == groupName.ToLower());

            if(group == null)
                throw new Exception("Group not found");

            var newMessage = new Message
            {
                Id = Guid.NewGuid(),
                Text = message,
                SenderId = senderId,
                GroupId = group.Id,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await messageRepository.AddAsync(newMessage);
            await messageRepository.SaveChangesAsync();
        }
    }
}
