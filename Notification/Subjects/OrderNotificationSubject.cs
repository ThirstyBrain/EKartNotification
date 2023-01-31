using Notification.Entities;
using Notification.Events;
using Notification.ListenerInterface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Subjects
{
    public class OrderNotificationSubject: IOrderNotificationSubject
    {
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private readonly ConcurrentBag<IOrderObserver> observers = new ConcurrentBag<IOrderObserver>();

        public void Subscribe(IOrderObserver observer)
        {
            _lock.EnterWriteLock();
            try
            {
                observers.Add(observer);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void UnSubscribe(IOrderObserver observer)
        {
            _lock.EnterWriteLock();
            try
            {
                observers.TryTake(out observer);
               
            }catch (Exception ex) {
                throw; 
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void Notify(Order order)
        {
            _lock.EnterReadLock();
            try
            {
                foreach (var observer in observers)
                {
                    observer.Update(order);
                }
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

      
    }
}
