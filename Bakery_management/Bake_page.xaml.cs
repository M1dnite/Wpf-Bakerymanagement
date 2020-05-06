using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
    /// Interaction logic for Bake_page.xaml
    /// </summary>
    public partial class Bake_page : Page
    {
        public Bake_page()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Lbx_orders.ItemsSource == null;
            Lbx_orders.ItemsSource = App._breads;
            Dgrid_dough.ItemsSource = App._doughdata;
           
        }

        private void Lbx_orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bread bd = Lbx_orders.SelectedItem as Bread;
            if (bd == null)
            {
                return;
            }
            else
            {
                int doquant = bd.quantity;

                // const int dqun = 1;

                var doquantity = (from c in App._doughdata where c.breadid == bd.id select c).ToArray();


                foreach (var item in doquantity)
                {

                    item.doughquantity = item.doughquantmul;
                    item.doughquantity = item.doughquantity * doquant;
                }
                // Dgrid_dough.ItemsSource = null;
                Dgrid_dough.ItemsSource = doquantity;
            }
            //Bread bd = Lbx_orders.SelectedItem as Bread;
            //int doid = bd.id;
            

           

        }

        //search filter
         private void Tbx_search_filter(object sender, TextChangedEventArgs e)
        {
            var filter = (sender as TextBox).Text.ToLower();
            var lst = from s in App._breads where s.breadName.ToLower().Contains(filter) select s;
            Lbx_orders.ItemsSource = lst;
        }

        private void Btn_add_click(object sender, RoutedEventArgs e)
        {
            Bread bd = new Bread { breadName = "Edit..." ,quantity = 0 };


            App._breads.Add(bd);
            Lbx_orders.SelectedItem = bd;
            Lbx_orders.ScrollIntoView(bd);
        }

        private void Btn_del_click(object sender, RoutedEventArgs e)
        {
            var itm = Lbx_orders.SelectedItem;

            if (itm == null)
            {
                MessageBox.Show("Please select a order to be deleted first!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var toDelete = itm as Bread;

            var res = MessageBox.Show($"Are you sure you want to {toDelete.breadName} {toDelete.quantity}?", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (res == MessageBoxResult.OK)
                App._breads.Remove(toDelete);
        }
    }
}
