using Nexus.Entities;

namespace Nexus.Services.Interface
{
    public interface IPrivateChatService
    {
        Task SendPrivateMessageAsync(Guid senderId, Guid receiverId, string message);
        Task<List<Message>> GetMessageHistoryAsync(Guid senderId, Guid receiverId, int count);
    }
}
