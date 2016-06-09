using ClotheStore.SharedKernel.Events.Interfaces;
using System;
using System.Collections.Generic;

namespace ClotheStore.SharedKernel.Interfaces
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
    }
}
