using Microsoft.AspNetCore.SignalR;
using Notification.Microservice.Repository;
using ReadIt.Core.ViewModels;

namespace Notification.Microservice.Models
{
    public class NotifyHub: Hub<INotificationHub>
    {

        //public string GetConnectionId() => Context.ConnectionId;
        public async Task SendMessage(NotificationModel notification)
        {
            await Clients.All.BroadcastMessage(notification);
        }

    }
}
