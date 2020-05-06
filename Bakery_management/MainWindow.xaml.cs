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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string language;
        bool firstTime = true;
        public MainWindow()
        {
            language = Properties.Settings.Default.language;
            CultureInfo.CurrentCulture = new CultureInfo(language);
            CultureInfo.CurrentUICulture = new CultureInfo(language);
            
            InitializeComponent();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var lst = new List<string> { "en English", "de German" };


            Cbx_language.ItemsSource = lst;
            var itm = (from l in lst where l.Contains(language) select l).FirstOrDefault();
            Cbx_language.SelectedItem = itm;
        }

        // Side Panel Buttons

        private void Btnclick_inventory(object sender, RoutedEventArgs e)
        {
            Main_frame.Content = new Inventory_page();
        }

        private void Btnclick_bake(object sender, RoutedEventArgs e)
        {
            Main_frame.Content = new Bake_page();
        }

        private void Cbx_changelang_selection(object sender, SelectionChangedEventArgs e)
        {
            if (firstTime)
            {
                firstTime = false;
                return;
            }

            language = Cbx_language.SelectedItem.ToString().Substring(0, 2);

            Properties.Settings.Default.language = language;
            Properties.Settings.Default.Save();

            Process.Start(Application.ResourceAssembly.Location);
            App.Current.Shutdown();
        }

       
        //datagrid object





    }
}
