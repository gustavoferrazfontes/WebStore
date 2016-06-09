using System;

namespace ClotheStore.SharedKernel.Events.Interfaces
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}
