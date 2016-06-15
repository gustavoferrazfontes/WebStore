using System;

namespace Register.Core.ApplicationLayer.Commands
{
    public sealed class RemoveCategoryCommand
    {
        

        public RemoveCategoryCommand(string id)
        {
            Id = Guid.Parse(id);
        }

        public Guid Id { get; internal set; }
    }
}
