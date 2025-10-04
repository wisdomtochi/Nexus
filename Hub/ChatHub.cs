using Microsoft.AspNetCore.SignalR;
using Nexus.Services.Interface;

namespace Nexus
{
    public class ChatHub : Hub
    {
        private readonly IPrivateChatService _privateChatService;
        private readonly IGroupService _groupService;

        public ChatHub(IGroupService groupService, IPrivateChatService privateChatService)
        {
            _groupService = groupService;
            _privateChatService = privateChatService;
        }

        public async Task SendPrivateMessage(string receiver, string message)
        {
            var sender = Context.User?.Identity?.Name ?? "Anonymous";

            await _privateChatService.SendMessageAsync(sender, receiver, message);
            var receiverConnectionId = await _privateChatService.GetConnectionIdAsync(receiver);

            if (receiverConnectionId != null)
            {
                await Clients.Client(receiverConnectionId).SendAsync("ReceivePrivateMessage", sender, message);
            }

            await Clients.Caller.SendAsync("ReceivePrivateMessage", sender, message);
        }

        public async Task SendGroupMessage(string groupName, string message)
        {
            var sender = Context.User?.Identity?.Name ?? "Anonymous";
            await _groupService.SendMessageToGroupAsync(groupName, sender, message);

            await Clients.Group(groupName).SendAsync("ReceiveGroupMessage", groupName, sender, message);
        }
    }
}
