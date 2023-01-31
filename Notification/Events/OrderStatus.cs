using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Events
{
    public enum OrderStatus
    {
        PendingPayment = 1,
        OnHold = 2,
        Processing = 3,
        Shipped = 4,
        Cancelled = 5,
        Refunded = 6,
        Failed = 7,
        Completed = 8
    }
}
