using Nexus.Entities;

namespace Nexus.Services.Interface
{
    public interface IPrivateChatService
    {
        Task SendMessageAsync(string sender, string receiver, string message);
        Task<List<Message>> GetMessageHistoryAsync(string sender, string receiver, int count);
        Task<string?> GetConnectionIdAsync(string userId);
    }
}
