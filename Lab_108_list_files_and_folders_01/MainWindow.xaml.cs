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
using System.Windows.Threading;

namespace Lab_108_list_files_and_folders_01
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

        public void ListFolders()
        {
            string[] allfiles = Directory.GetDirectories("/Labs", "*.*", SearchOption.TopDirectoryOnly);
            foreach (var item in allfiles)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = item;
                ListOfFolders.Items.Add(itm);
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListOfFolders.SelectedItem as ListBoxItem);
            string folder = (item.Content as string).Replace("\\", "/");
            string[] allFiles = Directory.GetDirectories(folder, "*.*", SearchOption.TopDirectoryOnly);
            ListOfFiles.Items.Clear();
            foreach (var items in allFiles)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = items;
                ListOfFiles.Items.Add(itm);
            }
        }
    }
}
