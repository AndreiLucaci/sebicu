using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesktopApp.Wpf.Controls;

namespace DesktopApp.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadReteteWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var reteteWindow = new ReteteWindow();

            reteteWindow.ShowDialog();

            this.Show();
        }

        private void LoadSIWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var siWindow = new SetIngredienteWindow();

            siWindow.ShowDialog();

            this.Show();
        }

        private void LoadMeniuWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var meniuWindow = new MeniuWindow();

            meniuWindow.ShowDialog();

            this.Show();
        }

        private void LoadCategorieWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var categorieWindow = new CategorieWindow();

            categorieWindow.ShowDialog();

            this.Show();
        }
    }
}
