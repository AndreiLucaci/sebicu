using System.Collections.Generic;
using DesktopApp.Wpf.DataAccess;

namespace DesktopApp.Wpf.Repository
{
    public interface IFoodRepository
    {
        ICollection<Reteta> GetReteteVegetariene();
    }
}
