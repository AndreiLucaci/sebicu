using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CommonServiceLocator;
using DesktopApp.Wpf.UnityConfiguration;
using Unity;
using Unity.ServiceLocation;

namespace DesktopApp.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var unityContainer = new UnityContainer();

            unityContainer
                .ConfigureWithDbContext()
                .ConfigureWithRepository();

            var unityServiceLocator = new UnityServiceLocator(unityContainer);
            var serviceLocator = new ServiceLocatorProvider(() => unityServiceLocator);
            ServiceLocator.SetLocatorProvider(serviceLocator);
        }
    }
}
