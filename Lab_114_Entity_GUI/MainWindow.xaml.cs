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

namespace Lab_114_Entity_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Customer> customers = new List<Customer>();
        public static Customer customer = new Customer();
        public static List<string> cities = new List<string>();
        public static SortedDictionary<string, string> cityDict = new SortedDictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize() {
            using (var db = new NorthwindEntities()) {
                customers = db.Customers.ToList();
                Users.ItemsSource = customers;
                Users.DisplayMemberPath = "ContactName";
                foreach (var customer in customers) {
                    if (!cityDict.ContainsKey(customer.City)) cityDict.Add(customer.City, customer.Country);
                }
                foreach (var elem in cityDict)
                {
                    Cities.Items.Add(elem.Key);
                }

            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Users.SelectionChanged -= Users_SelectionChanged;
            
            using (var db = new NorthwindEntities()) {
                Customer customerToUpdate =
                    db.Customers.Where(c => c.ContactName == customer.ContactName).FirstOrDefault();
                if (!UpdateName.Text.Equals("")) customerToUpdate.ContactName = UpdateName.Text;
                customerToUpdate.City = Cities.SelectedItem.ToString();
                customerToUpdate.Country = cityDict[Cities.SelectedItem.ToString()];
                db.SaveChanges();
            }
            if (!UpdateName.Text.Equals("")) customer.ContactName = UpdateName.Text;
            customer.City = Cities.SelectedItem.ToString();
            customer.Country = cityDict[Cities.SelectedItem.ToString()];
            Initialize();
            Users.SelectedItem = customer;
            UpdateSelected();
            Users.SelectionChanged += Users_SelectionChanged;
        }

        private void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customer = Users.SelectedItem as Customer;
            UpdateName.Text = customer.ContactName.ToString();
            Cities.SelectedItem = customer.City;
            UpdateSelected();
        }

        private void UpdateSelected() {
            Selected.Items.Clear();
            Selected.Items.Add($"ID: {customer.CustomerID}");
            Selected.Items.Add($"Name: {customer.ContactName}");
            Selected.Items.Add($"City: {customer.City}");
            Selected.Items.Add($"Country: {customer.Country}");
            Selected.Items.Add($"Company: {customer.CompanyName}");
        }
    }
}
