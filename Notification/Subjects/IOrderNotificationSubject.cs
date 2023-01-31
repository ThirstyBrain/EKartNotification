using Notification.Entities;
using Notification.ListenerInterface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Subjects
{
    public interface IOrderNotificationSubject
    {
        // Attach an order observer to the subject.
        public void Subscribe(IOrderObserver observer);

        // Detach an order observer from the subject.
        public void UnSubscribe(IOrderObserver observer);

        // Notify all order observers about an event.
        public void Notify(Order order);
    }
}
