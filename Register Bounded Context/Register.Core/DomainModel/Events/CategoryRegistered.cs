using System;
using ClotheStore.SharedKernel.Events.Interfaces;

namespace Register.Core.DomainModel.Events
{
    public sealed class CategoryRegistered : IDomainEvent
    {
        private readonly DateTime _dateOccurred;

        public string CategoryName { get; private set; }

        public DateTime DateOccurred
        {
            get
            {
                return _dateOccurred;
            }
        }

        public CategoryRegistered(Category newCategory)
        {
            _dateOccurred = DateTime.Now;
            CategoryName = newCategory.Title;
        }
    }
}
