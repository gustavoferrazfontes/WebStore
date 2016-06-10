using ClotheStore.SharedKernel.Events.Interfaces;
using System;

namespace ClotheStore.SharedKernel.Interfaces
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
      
    }
}
