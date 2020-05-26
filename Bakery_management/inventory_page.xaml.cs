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

namespace Bakery_management
{
    /// <summary>
    /// Interaction logic for inventory_page.xaml
    /// </summary>
    public partial class Inventory_page : Page
    {
        public Inventory_page()
        {
            InitializeComponent();

            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            Dgrid_inventory.ItemsSource = App._inventory;

        }

        private void Btn_click_add(object sender, RoutedEventArgs e)
        {
            Inventory inv = new Inventory { invitemName= Tbx_prodName.Text, invQuantity= Tbx_quantity.Text, category= Tbx_category.Text };
            App._inventory.Add(inv);
        }

        private void Btn_click_del(object sender, RoutedEventArgs e)
        {
            var dg = Dgrid_inventory.SelectedItem;

            if (dg == null)
            {
                MessageBox.Show("Please select an item to be deleted first!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var toDelete = dg as Inventory;

            var res = MessageBox.Show($"Are you sure to delete {toDelete.invitemName}?", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (res == MessageBoxResult.OK)
                App._inventory.Remove(toDelete);
        }
    }
}
