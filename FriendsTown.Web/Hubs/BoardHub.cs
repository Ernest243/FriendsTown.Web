using Microsoft.AspNetCore.SignalR;

namespace FriendsTown.Web.Hubs
{
    public class BoardHub : Hub
    {
        public async Task SendMessage(string newsId)
        {
            await Clients.All.SendAsync(newsId);
        }
    }
}