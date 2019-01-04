using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApp.Angular.Database;
using WebApp.Angular.Repository;

namespace WebApp.Angular.Controllers
{
    [Route("api/[controller]")]
    public class FoodController : Controller
    {
        private readonly IFoodRepository _foodRepository;

        public FoodController(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        [HttpGet("[action]")]
        public ICollection<Reteta> Retete()
        {
            return _foodRepository.GetAllRetetas();
        }
    }
}
