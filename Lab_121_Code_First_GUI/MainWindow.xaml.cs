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
using System.Data.Entity;

namespace Lab_121_Code_First_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Student> students = new List<Student>();
        public static Student student = new Student();

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize() {
            People.SelectionChanged -= People_SelectionChanged;
            using (var db = new PeopleContext()) {
                students = db.Students.ToList();
            }
            People.ItemsSource = students;
            People.DisplayMemberPath = "StudentName";
            People.SelectionChanged += People_SelectionChanged;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PeopleContext()) {
                var student = new Student();
                if (!NewName.Text.Equals(""))
                {
                    student.StudentName = NewName.Text;
                    db.Students.Add(student);
                    db.SaveChanges();
                }
                else MessageBox.Show("Enter a Name!");
            }
            Initialize();
        }

        private void People_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            student = People.SelectedItem as Student;
            Person.Items.Clear();
            Person.Items.Add($"ID: {student.StudentID}");
            Person.Items.Add($"Name: {student.StudentName}");
            Person.Items.Add($"Height: {student.height}cm");
            Person.Items.Add($"Weight: {student.weight}kg");
        }
    }

    public class Student {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int height;
        public double weight;

        public Student() { SetHeightWeight(); }

        void SetHeightWeight() {
            //var random = new Random();
            height = RandomNumber(160, 210);
            weight = RandomNumber(50,90);
        }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }

    public class PeopleContext : DbContext {
        public PeopleContext() : base("PeopleDB") { } // bounce responsibility  back up to entity dbcontext to do all the work
        public DbSet<Student> Students { get; set; }
    }
}
