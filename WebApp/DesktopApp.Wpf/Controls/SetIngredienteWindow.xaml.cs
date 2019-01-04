using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CommonServiceLocator;
using DesktopApp.Wpf.DataAccess;
using DesktopApp.Wpf.Repository;
using DesktopApp.Wpf.ViewModels;

namespace DesktopApp.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for SetIngredienteWindow.xaml
    /// </summary>
    public partial class SetIngredienteWindow : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var items = _foodRepository.GetSIFaraComentarii();

            this.siList.ItemsSource = items;
        }

        private readonly IFoodRepository _foodRepository;

        private ObservableCollection<SIViewModel> _siViewModel;

        public SetIngredienteWindow()
        {
            InitializeComponent();

            _foodRepository = ServiceLocator.Current.GetInstance<IFoodRepository>();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var items = _foodRepository.GetAllSI();

            this.siList.ItemsSource = items;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var items = _foodRepository.GetSIWithMoreThenCiuperci();

            this.siList.ItemsSource = items;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var items = _foodRepository.GetMaxUsturoi();

            this.siList.ItemsSource = items;
        }
    }
}
