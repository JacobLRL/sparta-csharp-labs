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
using System.IO;

namespace Lab_105_game_name_and_score
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = new TextRange((sender as RichTextBox).Document.ContentStart, (sender as RichTextBox).Document.ContentEnd).Text;
            if (!text.Equals("")) {
                File.WriteAllText("username.txt", text);
            } 
        }
        private void Level_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = new TextRange((sender as RichTextBox).Document.ContentStart, (sender as RichTextBox).Document.ContentEnd).Text;
            if (!text.Equals("")) {
                File.WriteAllText("level.txt", text);
            } 
        }
        private void Score_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = new TextRange((sender as RichTextBox).Document.ContentStart, (sender as RichTextBox).Document.ContentEnd).Text;
            if (!text.Equals("")) {
                File.WriteAllText("score.txt", text);
            } 
        }
        


        // create a gaming homepage
        // name of the gamer saved to text file
        // level reached
        // top score
        // prize for best presented interface

    }
}
