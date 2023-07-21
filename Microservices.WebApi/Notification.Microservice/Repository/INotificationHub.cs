using ReadIt.Core.ViewModels;

namespace Notification.Microservice.Repository
{
    public interface INotificationHub
    {
        public Task BroadcastMessage(NotificationModel notification);
    }
}
