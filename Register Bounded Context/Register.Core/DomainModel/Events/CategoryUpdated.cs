using ClotheStore.SharedKernel.Events.Interfaces;
using System;

namespace Register.Core.DomainModel.Events
{
    public sealed class CategoryUpdated : IDomainEvent
    {
        public string Title { get; private set; }

        public string Id { get; private set; }
        public DateTime DateOccurred
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private DateTime _dateOccurred;

        public CategoryUpdated(Category category)
        {
            _dateOccurred = DateTime.Now;
            Title = category.Title;
            Id = category.Id.ToString();
        }
    }
}
