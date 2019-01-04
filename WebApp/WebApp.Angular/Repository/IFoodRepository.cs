using System.Collections.Generic;
using WebApp.Angular.Database;

namespace WebApp.Angular.Repository
{
    public interface IFoodRepository
    {
        ICollection<Reteta> GetAllRetetas();
    }
}
