using Register.Core.ApplicationLayer.Commands;

namespace Register.Core.ApplicationLayer.Interfaces
{
    public interface IProductManager
    {
        void RegisterProduct(RegisterProductCommand command);
    }
}
