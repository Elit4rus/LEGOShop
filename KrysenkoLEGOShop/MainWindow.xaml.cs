using KrysenkoLEGOShop.Model;
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

namespace KrysenkoLEGOShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Подключение ListBox к бд
            Lst.ItemsSource = App.context.Products.ToList();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Lst.ItemsSource = App.context.Products.ToList();
        }

        private void StreachTb_GotFocus(object sender, RoutedEventArgs e)
        {
            
            if (StreachTb.Text == "Введите название:")
            {
                StreachTb.Text = "";
            }
        }

        private void StreachTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (StreachTb.Text == "")
            {
                StreachTb.Text = "Введите название:";
            }
        }

        private void StreachTb_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (IsLoaded) // Выполнится в случае, если окно полностью загружено
            {
                Search();
            }
        }
        List<Product> product = new List<Product>();

        private void Search()
        {
            product = App.context.Products.ToList();
            if (StreachTb.Text != null)
            {

            }
            else 
            {
                Lst.ItemsSource = product;
                TbNullSearch.Visibility = Visibility.Collapsed;
            }
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();
        }
    }
}
