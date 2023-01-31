using Notification.Entities;
using Notification.Events;

namespace Notification.ListenerInterface
{
    public interface IOrderObserver{
        public void Update(Order order);
    }
}
