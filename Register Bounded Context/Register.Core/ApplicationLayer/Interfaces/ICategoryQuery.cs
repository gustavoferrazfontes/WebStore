using Register.Core.ApplicationLayer.Queries;
using System.Collections.Generic;

namespace Register.Core.ApplicationLayer.Interfaces
{
    public interface ICategoryQuery
    {
        IEnumerable<ListOfCategory> GetCategories();
    }
}
