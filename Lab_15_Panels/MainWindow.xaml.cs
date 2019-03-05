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

namespace Lab_15_Panels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int index;
        string headerName;
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize() {
            index = 1;
            DisplayPanel(index);
        }

        private void ButtonChangePanel_Click(object sender, RoutedEventArgs e)
        {
            index++;
            if (index == 4) index = 1;
            DisplayPanel(index);
        }

        void DisplayPanel(int index) {
            switch (index)
            {
                case 1:
                    StackedPanel01.Visibility = Visibility.Visible;
                    StackedPanel02.Visibility = Visibility.Collapsed;
                    StackedPanel03.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    StackedPanel02.Visibility = Visibility.Visible;
                    StackedPanel01.Visibility = Visibility.Collapsed;
                    StackedPanel03.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    StackedPanel03.Visibility = Visibility.Visible;
                    StackedPanel02.Visibility = Visibility.Collapsed;
                    StackedPanel01.Visibility = Visibility.Collapsed;
                    break;

                default:
                    break;
            }
        }

        private void ButtonChangeTab_Click(object sender, RoutedEventArgs e)
        {
            if (TabControl01.SelectedIndex == TabControl01.Items.Count-1)
            {
                TabControl01.SelectedIndex = 0;
            }
            else {
                TabControl01.SelectedIndex++;
            }
            
        }

        private void ButtonChangeTabByName_Click(object sender, RoutedEventArgs e)
        {
            headerName = ((TabControl01.SelectedItem as TabItem).Header.ToString());
            switch (headerName)
            {
                case "First":
                    TabItem02.IsSelected = true;
                    break;
                case "Second":
                    TabItem03.IsSelected = true;
                    break;
                case "Third":
                    TabItem01.IsSelected = true;
                    break;
                default:
                    break;
            }
        }
    }
}
