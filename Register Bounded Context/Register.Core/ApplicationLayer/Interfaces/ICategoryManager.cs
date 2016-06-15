using Register.Core.ApplicationLayer.Commands;

namespace Register.Core.ApplicationLayer.Interfaces
{
    public interface ICategoryManager
    {
        void Register(RegisterCategoryCommand command);
        void Remove(RemoveCategoryCommand command);
        void Update(UpdateCategoryCommand command);
    }
}
