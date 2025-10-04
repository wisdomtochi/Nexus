using Nexus.Data.GenericRepository;
using Nexus.Entities;
using Nexus.Services.Interface;

namespace Nexus.Services.Implementation
{
    public class PrivateChatService(IGenericRepository<Message> messageRepository) : IPrivateChatService
    {
        private readonly IGenericRepository<Message> _messageRepository = messageRepository;

        public Task<string?> GetConnectionIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> GetMessageHistoryAsync(string sender, string receiver, int count)
        {
            throw new NotImplementedException();
        }

        public async Task SendMessageAsync(string sender, string receiver, string message)
        {
            var newMessage = new Message
            {
                Id = Guid.NewGuid(),
                Text = message,
                SenderId = sender,
                ReceiverId = receiver,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _messageRepository.AddAsync(newMessage);
            await _messageRepository.SaveChangesAsync();
        }
    }
}
