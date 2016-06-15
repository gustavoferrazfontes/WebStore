using ClotheStore.SharedKernel.Events.Interfaces;
using System;

namespace Register.Core.DomainModel.Events
{
    public sealed class CategoryRemoved : IDomainEvent
    {


        public CategoryRemoved(Guid id)
        {
            _dateOccured = DateTime.Now;
            Id = id.ToString();
        }


        private DateTime _dateOccured;

        public string Id { get; private set; }
        public DateTime DateOccurred
        {
            get
            {
                return _dateOccured;
            }
        }
    }
}
