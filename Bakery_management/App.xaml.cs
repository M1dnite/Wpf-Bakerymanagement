using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bakery_management
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Bread> _breads;
        public static ObservableCollection<doughdata> _doughdata;
        public static ObservableCollection<Inventory> _inventory;
        
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _breads = BreadsStorage.ReadXML<ObservableCollection<Bread>>("breadfile.xml");
            _doughdata = doughstorage.ReadXML<ObservableCollection<doughdata>>("doughfile.xml");
            _inventory = inventorystorage.ReadXML<ObservableCollection<Inventory>>("inventoryfile.xml");








            if (_breads == null)
            {
                _breads = new ObservableCollection<Bread>();
                //_students = GenerateStudents(50);
            }
            if (_doughdata == null)
            {
                _doughdata = new ObservableCollection<doughdata>();
                //_students = GenerateStudents(50);
            }
            if (_inventory == null)
            {
                _inventory = new ObservableCollection<Inventory>();
                //_students = GenerateStudents(50);
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            BreadsStorage.WriteXml<ObservableCollection<Bread>>(_breads, "breadfile.xml");
            doughstorage.WriteXml<ObservableCollection<doughdata>>(_doughdata, "doughfile.xml");
            inventorystorage.WriteXml<ObservableCollection<Inventory>>(_inventory, "inventoryfile.xml");

        }
    }
}
