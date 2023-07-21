using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Notification.Microservice.Models;
using Notification.Microservice.Repository;
using ReadIt.Core.ViewModels;

namespace Notification.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotifyHub, INotificationHub> _hubContext;

        public NotificationController(IHubContext<NotifyHub, INotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public string Get()
        {
            string retMessage = string.Empty;
            NotificationModel notification = new()
            {
                NotificationMessage = "sfgksjbf"
            };
            try
            {
                _hubContext.Clients.All.BroadcastMessage(notification);
                retMessage = "success";
            }
            catch (Exception ex)
            {
                retMessage = ex.Message;
            }
            return retMessage;
        }
    }
}
