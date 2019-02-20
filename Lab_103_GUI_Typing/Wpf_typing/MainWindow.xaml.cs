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

namespace Wpf_typing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool alphabetical = true;
        public static string alphabet = "abcdefghijklmnopqrstuvwxyz";
        public static DateTime finish;
        public static int score = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Typing.Text = "";
            Typing.TextChanged += Typing_TextChanged;
            Typing.IsReadOnly = false;
            finish = DateTime.Now.AddSeconds(int.Parse(Timer.Text));
            UpdateScore(0);
            Keyboard.Focus(Typing);
        }

        private void Alphabetical_Checked(object sender, RoutedEventArgs e)
        {
            alphabetical = true;
        }

        private void Random_Checked(object sender, RoutedEventArgs e)
        {
            alphabetical = false;
        }

        private void ChangeTime(int time) {
            Timer.Text = time.ToString();
        }
        public void UpdateScore(int score) {
            Score.Text = $"Score: {score}";
        }

        private void Typing_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!alphabetical)
            {
                UpdateScore(score += 1);
                ChangeTime((int)(finish-DateTime.Now).TotalSeconds);
                if ((int)(finish - DateTime.Now).TotalSeconds <= 0)
                {
                    Typing.IsReadOnly = true;
                    Typing.TextChanged -= Typing_TextChanged;
                    Timer.Text = "10";
                    MessageBox.Show($"Your score was: {score}", "Score");
                    score = 0;
                }
            }
            else if(alphabetical)
            {
                try
                {
                    if (Typing.Text[Typing.Text.Length - 1] == alphabet[(Typing.Text.Length - 1)%26])
                    {
                        UpdateScore(score += 1);
                        Typing.Foreground = Brushes.Black;
                    }
                    else
                    {
                        string text = Typing.Text;
                        Typing.Foreground = Brushes.Red;
                        Typing.TextChanged -= Typing_TextChanged;
                        Typing.Text = text.Substring(0, text.Length - 1);
                        Typing.SelectionStart = Typing.Text.Length;
                        Typing.TextChanged += Typing_TextChanged;
                    }
                }
                catch {  }
                ChangeTime((int)(finish - DateTime.Now).TotalSeconds);
                if ((int)(finish - DateTime.Now).TotalSeconds <= 0)
                {
                    Typing.IsReadOnly = true;
                    Typing.TextChanged -= Typing_TextChanged;
                    Timer.Text = "10";
                    MessageBox.Show($"Your score was: {score}", "Score");
                    score = 0;
                }
            }
            
        }
    }
}
