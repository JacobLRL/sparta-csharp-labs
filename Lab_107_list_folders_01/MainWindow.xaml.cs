using System;
using System.Collections.Generic;
using System.IO;
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

namespace Lab_107_list_folders_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListFolders();
        }


        public void ListFolders() {
            string[] allfiles = Directory.GetFiles("C:\\Labs", "*.*", SearchOption.AllDirectories);
            foreach (var item in allfiles)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = item;
                ListOfFolders.Items.Add(itm);
            }
        }

    }

    
}
