using Register.Core.ApplicationLayer.Commands;

namespace Register.Core.ApplicationLayer.Interfaces
{
    public interface IRegisterCategory
    {
        void Register(RegisterCategoryCommand command);
    }
}
