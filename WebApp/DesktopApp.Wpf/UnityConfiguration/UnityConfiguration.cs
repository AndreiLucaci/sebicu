using DesktopApp.Wpf.DataAccess;
using DesktopApp.Wpf.DataAccess.Contracts;
using DesktopApp.Wpf.Repository;
using Unity;

namespace DesktopApp.Wpf.UnityConfiguration
{
    public static class UnityConfiguration
    {
        public static IUnityContainer ConfigureWithDbContext(this IUnityContainer container)
        {
            container.RegisterType<IAppEntities, AppEntities>();

            return container;
        }


        public static IUnityContainer ConfigureWithRepository(this IUnityContainer container)
        {
            container.RegisterType<IFoodRepository, FoodRepository>();

            return container;
        }
    }
}
