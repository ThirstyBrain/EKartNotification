using Notification.Entities;
using Notification.Events;
using Notification.ListenerInterface;
using System;

namespace Notification.ListenerImpl
{
    public class EmailMsgListener : IOrderObserver
    {
        private String userName { get; }
        public EmailMsgListener(String userName)
        {
            this.userName = userName;
        }
        
        public void Update(Order order)
        {
            Console.WriteLine("Order No '{0}' status is updated to '{1}'. An email sent to customer.",
                 order.OrderNumber, order.OrderStatus.ToString());
        }
    }
}
