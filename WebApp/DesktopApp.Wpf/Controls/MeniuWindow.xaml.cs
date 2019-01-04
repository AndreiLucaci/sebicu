using System.Collections.ObjectModel;
using System.Windows;
using CommonServiceLocator;
using DesktopApp.Wpf.Repository;
using DesktopApp.Wpf.ViewModels;

namespace DesktopApp.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for MeniuWindow.xaml
    /// </summary>
    public partial class MeniuWindow : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var items = _foodRepository.GetMeniu();

            this.meniuList.ItemsSource = items;
        }

        private readonly IFoodRepository _foodRepository;

        private ObservableCollection<SIViewModel> _meniu;

        public MeniuWindow()
        {
            InitializeComponent();

            _foodRepository = ServiceLocator.Current.GetInstance<IFoodRepository>();
        }
    }
}
