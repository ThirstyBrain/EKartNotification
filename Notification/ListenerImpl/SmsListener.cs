using Notification.Entities;
using Notification.ListenerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.ListenerImpl
{
    public class SmsListener : IOrderObserver
    {
        public void Update(Order order)
        {
            Console.WriteLine("Order No '{0}' status is updated to '{1}'. SMS message sent to customer.",
                order.OrderNumber, order.OrderStatus.ToString());
        }
        
    }
}
