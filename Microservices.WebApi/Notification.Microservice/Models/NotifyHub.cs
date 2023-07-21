using Microsoft.AspNetCore.SignalR;
using Notification.Microservice.Repository;

namespace Notification.Microservice.Models
{
    public class NotifyHub: Hub<INotificationHub>
    {
    }
}
