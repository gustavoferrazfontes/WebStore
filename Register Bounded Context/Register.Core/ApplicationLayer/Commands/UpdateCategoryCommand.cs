using System;

namespace Register.Core.ApplicationLayer.Commands
{
    public sealed class UpdateCategoryCommand
    {


        public UpdateCategoryCommand(string title, string id)
        {
            Title = title;
            Id = Guid.Parse(id);
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
    }
}
