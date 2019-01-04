using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CommonServiceLocator;
using DesktopApp.Wpf.DataAccess;
using DesktopApp.Wpf.Repository;

namespace DesktopApp.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for ReteteControl.xaml
    /// </summary>
    public partial class ReteteControl : UserControl
    {
        private readonly IFoodRepository _foodRepository;

        private ObservableCollection<Reteta> _retetas;

        public ICollection<Reteta> Retetes
        {
            get => _retetas ?? (_retetas = new ObservableCollection<Reteta>());
            set => _retetas = new ObservableCollection<Reteta>(value.ToList());
        }

        public ReteteControl()
        {
            InitializeComponent();

            _foodRepository = ServiceLocator.Current.GetInstance<IFoodRepository>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var retetes = _foodRepository.GetReteteVegetariene();

            Retetes = retetes;
            this.reteteList.ItemsSource = retetes;
        }
    }
}
