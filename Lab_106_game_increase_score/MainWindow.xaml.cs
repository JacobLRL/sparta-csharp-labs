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

namespace Lab_106_game_increase_score
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string text = new TextRange((sender as RichTextBox).Document.ContentStart, (sender as RichTextBox).Document.ContentEnd).Text;
            string text = (sender as TextBox).Text;
            if (!text.Equals(""))
            {
                File.WriteAllText("username.txt", text);
            }
        }
        private void Level_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = (sender as TextBox).Text;
            if (!text.Equals(""))
            {
                File.WriteAllText("level.txt", text);
            }
        }
        private void Score_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = (sender as TextBox).Text;
            if (!text.Equals(""))
            {
                File.WriteAllText("score.txt", text);
            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                scoreT.Text = (int.Parse(scoreT.Text) + 1).ToString();
            }
            catch (Exception)
            { }
        }
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                scoreT.Text = (int.Parse(scoreT.Text) - 1).ToString();
            }
            catch (Exception)
            { }
        }

        private void Start() {
            try
            {
                string username = File.ReadAllLines("username.txt")[0];
                string level = File.ReadAllLines("level.txt")[0];
                string score = File.ReadAllLines("score.txt")[0];

                usernameT.Text = username;
                levelT.Text = level;
                scoreT.Text = score;
            }
            catch (Exception){ }
        }



        // create a gaming homepage
        // name of the gamer saved to text file
        // level reached
        // top score
        // prize for best presented interface
        // create a gaming homepage
        // name of the gamer saved to text file
        // level reached
        // top score
        // prize for best presented interface
    }
}
