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

namespace Lab_117_Entity_Tabs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Customer customer = new Customer();
        Order order = new Order();
        Order_Detail orderDetail = new Order_Detail();
        Product product = new Product();
        List<Customer> customers = new List<Customer>();
        List<Order> orders = new List<Order>();
        List<Order_Detail> orderDetails = new List<Order_Detail>();
        TabItem tab = new TabItem() { Header = "Customers" };
        TabItem tab1 = new TabItem() { Header = "Orders" };
        TabItem tab2 = new TabItem() { Header = "Order Details" };
        TabItem tab3 = new TabItem() { Header = "Product Details" };
        ListBox customerList = new ListBox();
        ListBox orderList = new ListBox();
        ListBox orderDetailsList = new ListBox();
        ListBox productDetailsList = new ListBox();
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {

            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
            }

            customerList.ItemsSource = customers;
            customerList.DisplayMemberPath = "ContactName";
            tab.Content = customerList;
            TabController.Items.Add(tab);
            TabController.Items.Add(tab1);
            TabController.Items.Add(tab2);
            TabController.Items.Add(tab3);            
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customer = customerList.SelectedItem as Customer;
            using (var db = new NorthwindEntities())
            {
                orders = db.Orders.Where(c => c.CustomerID == customer.CustomerID).ToList();
            }

            orderList.ItemsSource = orders;
            orderList.DisplayMemberPath = "OrderID";
            tab1.Content = orderList;
        }

        private void OrderSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            order = orderList.SelectedItem as Order;
            using (var db = new NorthwindEntities())
            {
                orderDetails = db.Order_Details.Where(o => o.OrderID == order.OrderID).ToList();
            }

            orderDetailsList.ItemsSource = orderDetails;
            orderDetailsList.DisplayMemberPath = "ProductID";
            tab2.Content = orderDetailsList;
            orderDetail = new Order_Detail();
        }

        private void ProductSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            orderDetail = orderDetailsList.SelectedItem as Order_Detail;
            using (var db = new NorthwindEntities()) {
                product = db.Products.Where(p => p.ProductID == orderDetail.ProductID).FirstOrDefault();
                productDetailsList.Items.Clear();
                productDetailsList.Items.Add(product.ProductID);
                productDetailsList.Items.Add(product.ProductName);
            }
            product = new Product();
            tab3.Content = productDetailsList;
        }

        void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tab.IsSelected && e.Source is TabControl)
            {
                customerList.SelectionChanged += SelectionChanged;
                orderList.SelectionChanged -= OrderSelectionChanged;
                orderDetailsList.SelectionChanged -= ProductSelectionChanged;
            }
            else if (tab1.IsSelected && e.Source is TabControl)
            {
                customerList.SelectionChanged -= SelectionChanged;
                orderList.SelectionChanged += OrderSelectionChanged;
                orderDetailsList.SelectionChanged -= ProductSelectionChanged;
            }
            else if (tab2.IsSelected && e.Source is TabControl)
            {
                customerList.SelectionChanged -= SelectionChanged;
                orderList.SelectionChanged -= OrderSelectionChanged;
                orderDetailsList.SelectionChanged += ProductSelectionChanged;
            }
            else if (tab3.IsSelected && e.Source is TabControl)
            {
                customerList.SelectionChanged -= SelectionChanged;
                orderList.SelectionChanged -= OrderSelectionChanged;
                orderDetailsList.SelectionChanged -= ProductSelectionChanged;
            }
        }

    }
}
