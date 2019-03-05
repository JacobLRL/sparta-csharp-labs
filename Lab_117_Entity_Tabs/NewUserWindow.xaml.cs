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
using System.Windows.Shapes;

namespace Lab_117_Entity_Tabs
{
    /// <summary>
    /// Interaction logic for NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        public static List<string> cities = new List<string>();
        public static SortedDictionary<string, string> cityDict = new SortedDictionary<string, string>();
        public static List<Customer> customers = new List<Customer>();
        public static List<string> titles = new List<string>();
        public static List<string> ids = new List<string>();

        public NewUserWindow()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize() {
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                foreach (var customer in customers)
                {
                    if (!cityDict.ContainsKey(customer.City)) cityDict.Add(customer.City, customer.Country);
                    if (!titles.Contains(customer.ContactTitle)) titles.Add(customer.ContactTitle);
                    ids.Add(customer.CustomerID);
                }
                foreach (var elem in cityDict)
                {
                    City.Items.Add(elem.Key);
                }
                foreach (var elem in titles) {
                    Title.Items.Add(elem);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            string company = Company.Text;
            string contactTitle;
            try
            {
                contactTitle = Title.SelectedItem.ToString();
            }
            catch {
                contactTitle = "";
            }            
            string address = Address.Text;
            string postCode = PostCode.Text;
            string region = Region.Text;
            string city;
            string country;
            try
            {
                city = City.SelectedItem.ToString();
                country = cityDict[city];
            }
            catch
            {
                city = "";
                country = "";
            }
            string id;

            while (true) {
                id = RandomID();
                if (!ids.Contains(id)) break;
            }
            ids.Add(id);
            int.TryParse(ContactNum.Text, out int contactNum);
            int.TryParse(FaxNum.Text, out int faxNum);
            MessageBox.Show(contactNum.ToString() + " " + faxNum);
            MessageBox.Show(id);
            if (name == "" || company == "" || contactTitle == "" || address == "" || postCode == "" || region == "" || city == "")
            {
                MessageBox.Show("All fields mush be completed");
            }
            else
            {
                using (var db = new NorthwindEntities()) {
                    Customer customer = new Customer()
                    {
                        CustomerID = id,
                        ContactName = name,
                        CompanyName = company,
                        ContactTitle = contactTitle,
                        Phone = contactNum.ToString(),
                        Fax = faxNum.ToString(),
                        Address = address,
                        PostalCode = postCode,
                        Region = region,
                        City = city,
                        Country = country
                    };

                    db.Customers.Add(customer);
                    db.SaveChanges();
                }
            }
            
        }

        public string RandomID() {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var stringChars = new char[5];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            string finalString = new String(stringChars);
            return finalString;
        }

        /*
         *      Address = c.Address;
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
         * 
         */
    }
}
