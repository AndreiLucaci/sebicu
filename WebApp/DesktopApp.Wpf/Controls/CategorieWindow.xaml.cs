using System.Windows;
using CommonServiceLocator;
using DesktopApp.Wpf.Repository;

namespace DesktopApp.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for CategorieWindow.xaml
    /// </summary>
    public partial class CategorieWindow : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var items = _foodRepository.GetTimpMediu();

            this.categorieList.ItemsSource = items;
        }

        private readonly IFoodRepository _foodRepository;

        public CategorieWindow()
        {
            InitializeComponent();

            _foodRepository = ServiceLocator.Current.GetInstance<IFoodRepository>();
        }
    }
}
