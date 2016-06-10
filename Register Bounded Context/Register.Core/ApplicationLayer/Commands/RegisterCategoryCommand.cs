namespace Register.Core.ApplicationLayer.Commands
{
    public sealed class RegisterCategoryCommand
    {

        public RegisterCategoryCommand(string title)
        {
            Title = title;
        }

        public string Title { get; private set; }
    }
}
