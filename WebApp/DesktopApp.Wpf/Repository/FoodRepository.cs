using System.Collections.Generic;
using System.Linq;
using DesktopApp.Wpf.DataAccess;
using DesktopApp.Wpf.DataAccess.Contracts;

namespace DesktopApp.Wpf.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly IAppEntities _entities;

        public FoodRepository(IAppEntities entities)
        {
            _entities = entities;
        }

        public ICollection<Reteta> GetReteteVegetariene()
        {
            var retete = 
                from reteta in _entities.Retetas
                where reteta.vegetariana == "D"
                orderby reteta.timp_preparare descending
                select reteta;

            return retete.ToList();
        }
    }
}
