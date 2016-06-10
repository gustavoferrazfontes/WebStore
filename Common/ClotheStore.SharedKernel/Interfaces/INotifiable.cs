using ClotheStore.SharedKernel.Events.Interfaces;
using System;
using System.Collections.Generic;

namespace ClotheStore.SharedKernel.Interfaces
{
    public interface INotifiable<T> : IDisposable where T : IDomainEvent
    {
        IEnumerable<T> Notify();
        bool HasNotifications();
    }
}
