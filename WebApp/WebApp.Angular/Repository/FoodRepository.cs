using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApp.Angular.Database;

namespace WebApp.Angular.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext _dbContext;

        public FoodRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Reteta> GetAllRetetas()
        {
            return _dbContext.Retetas.Include(o => o.Categorie).Include(o => o.Set_ingrediente).ToList();
        }
    }
}
