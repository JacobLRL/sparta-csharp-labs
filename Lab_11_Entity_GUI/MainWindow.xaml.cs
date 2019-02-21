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
//using System.Windows.Data.MultiBinding;

namespace Lab_11_Entity_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<string> customerList = new List<string>();
        private static List<Customer> customers = new List<Customer>();
        private static Customer customer;
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                foreach (var elem in customers)
                {
                    customerList.Add($"Contactname: {elem.ContactName} has ID {elem.CustomerID}");
                }
                ListBox01.ItemsSource = customerList;
            }

            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                ListBox02.ItemsSource = customers;
            }

            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                ListBox03.ItemsSource = customers;
                ListBox03.DisplayMemberPath = "ContactName";
            }
        }

        private void ListBox03_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customer = ListBox03.SelectedItem as Customer;
            ContactName.Text = customer.ContactName;
        }
    }
}
