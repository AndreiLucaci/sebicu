using System.Windows;
using System.Windows.Controls;
using CommonServiceLocator;
using DesktopApp.Wpf.Repository;

namespace DesktopApp.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for ReteteWindow.xaml
    /// </summary>
    public partial class ReteteWindow : Window
    {
        private readonly IFoodRepository _foodRepository;

        public ReteteWindow()
        {
            InitializeComponent();

            _foodRepository = ServiceLocator.Current.GetInstance<IFoodRepository>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var retetes = _foodRepository.GetReteteVegetariene();

            this.reteteList.ItemsSource = retetes;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var retes = _foodRepository.GetReteteWithoutCiuperci();

            this.reteteList.ItemsSource = retes;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var retes = _foodRepository.GetRetetaVegetarianaWithMinTimpPreparare();

            this.reteteList.ItemsSource = retes;
        }
    }
}
