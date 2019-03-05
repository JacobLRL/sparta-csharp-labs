using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Lab_115_Northwind_Entity_With_OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Lab 115
    /// read customers
    /// cast to active customers
    /// set IsActive to true for all customers
    /// 
    /// create 2 list boxes and radio button to enable/disable isActive
    /// 
    /// click on customer to select and display all details on screen
    /// 
    /// radio is a toggle
    /// 
    /// first listbox is only for ACTIVE customers
    /// if in active, remove from first listbox and add to second listbox
    /// 
    /// and reverse
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Customer> customers = new List<Customer>();
        static List<ActiveCustomer> activeCustomers = new List<ActiveCustomer>();
        static List<ActiveCustomer> inactiveCustomers = new List<ActiveCustomer>();
        static ActiveCustomer customer = new ActiveCustomer();
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }
        void Initialize() {

            using (var db = new NorthwindEntities()) {
                customers = db.Customers.ToList();
            }
            foreach (var elem in customers) {
                activeCustomers.Add(new ActiveCustomer(elem));
            }

            ActiveUsers.ItemsSource = activeCustomers;
            ActiveUsers.DisplayMemberPath = "ContactName";
            InactiveUsers.ItemsSource = inactiveCustomers;
            InactiveUsers.DisplayMemberPath = "ContactName";
        }
        // interfaces are like tools
        interface IDoThis {
            void DoThis();
        }
        interface IDoThat {
            void DoThat();
        }
        // class customer
        // class ActiveCustomer : Customer
        class ActiveCustomer : Customer {

            public ActiveCustomer() { }
            public ActiveCustomer(Customer c)
            {
                Address = c.Address;
                City= c.City;
                ContactName = c.ContactName;
                CompanyName = c.CompanyName;
                ContactTitle = c.ContactTitle;
                Country = c.Country;
                CustomerID = c.CustomerID;
                Fax = c.Fax;
                Phone = c.Phone;
                PostalCode = c.PostalCode;
                Region = c.Region;
                IsActive = true;
            }
            public bool IsActive;
            public void DoThis() { }
            public void DoThat() { }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customer = ActiveUsers.SelectedItem as ActiveCustomer;
            TrueButton.IsChecked = true;
            UpdateSelected();
        }

        private void SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            customer = InactiveUsers.SelectedItem as ActiveCustomer;
            FalseButton.IsChecked = true;
            UpdateSelected();
        }

        private void UpdateSelected()
        {
            Selected.Items.Clear();
            Selected.Items.Add($"IsActive: {customer.IsActive}");
            Selected.Items.Add($"ID: {customer.CustomerID}");
            Selected.Items.Add($"Name: {customer.ContactName}");
            Selected.Items.Add($"City: {customer.City}");
            Selected.Items.Add($"Country: {customer.Country}");
            Selected.Items.Add($"Company: {customer.CompanyName}");
        }

        private void Active_Checked(object sender, RoutedEventArgs e)
        {
            customer.IsActive = true;
            if (!activeCustomers.Contains(customer)) {
                activeCustomers.Add(customer);
                inactiveCustomers.Remove(customer);
            }
            // update both lists
            ActiveUsers.SelectionChanged -= SelectionChanged;
            InactiveUsers.SelectionChanged -= SelectionChanged2;
            ActiveUsers.Items.Refresh();
            InactiveUsers.Items.Refresh();
            ActiveUsers.SelectionChanged += SelectionChanged;
            InactiveUsers.SelectionChanged += SelectionChanged2;
        }

        private void Inactive_Checked(object sender, RoutedEventArgs e)
        {
            customer.IsActive = false;
            if (!inactiveCustomers.Contains(customer)) {
                inactiveCustomers.Add(customer);
                activeCustomers.Remove(customer);
            }
            //update both lists
            ActiveUsers.SelectionChanged -= SelectionChanged;
            InactiveUsers.SelectionChanged -= SelectionChanged2;
            ActiveUsers.Items.Refresh();
            InactiveUsers.Items.Refresh();
            ActiveUsers.SelectionChanged += SelectionChanged;
            InactiveUsers.SelectionChanged += SelectionChanged2;
        }
    }
}
