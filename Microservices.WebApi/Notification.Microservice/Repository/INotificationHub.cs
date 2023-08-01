using ReadIt.Core.ViewModels;

namespace Notification.Microservice.Repository
{
    public interface INotificationHub
    {
        Task BroadcastMessage(NotificationModel notification);
    }
}
