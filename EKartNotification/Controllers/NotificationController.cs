using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notification;
using Notification.Entities;
using Notification.Events;
using Notification.ListenerImpl;
using Notification.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKartNotification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        public  IOrderNotificationSubject _orderNotificationSubject;

        public NotificationController(IOrderNotificationSubject notificationSubject) {
            _orderNotificationSubject = notificationSubject;
        }

    
        [HttpPost]
        [Route("/api/SubscribeOrderNotification")]
        public async Task<IActionResult> SubscribeOderNotification([FromBody] Order order)
        {
            Console.WriteLine("Attaching Observers...");

            var smsObserver = new SmsListener();
            var emailObserver = new EmailMsgListener(order.Email);

            _orderNotificationSubject.Subscribe(smsObserver);
            _orderNotificationSubject.Subscribe(emailObserver);


            Console.WriteLine("Notify Order Status...");

            _orderNotificationSubject.Notify(order);

            return Ok(order);
        }
        [HttpPost]
        [Route("/api/UnSubscribeOrderNotification")]
        public async Task<IActionResult> UnSubscribeOrderNotification(Order order)
        {
            Console.WriteLine("Attaching Observers...");

            var smsObserver = new SmsListener();
            var emailObserver = new EmailMsgListener(order.Email);



            Console.WriteLine("Notify SMS Observer...");

            _orderNotificationSubject.UnSubscribe(smsObserver);


            Console.WriteLine("Notify Order Status...");

            _orderNotificationSubject.Notify(order);

            return null;
        }

       

    }
}
