using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rpm8
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

        struct Staff
        {
            public int Code;
            public string Name;
            public string Gender;
            public string Post;
            public double Exp;
            public double Salary;

            public Staff(int code, string name, string gender, string post, double exp, double salary)
            {
                Code = code;
                Name = name;
                Gender = gender;
                Post = post;
                Exp = exp;
                Salary = salary;
            }
            public override string ToString()
            {
                return $"ФИО:{Name,40}, Пол:{Gender,7}, Должность:{Post,45}, Стаж работы:{Exp,50:F1} лет, Оклад:{Salary,7:F2}.";
            }
        }

        Staff[] staff;

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            lbStaff.ItemsSource = null;
            int pos = Convert.ToInt32(tbCode.Text);
            //staff[pos].Code = Convert.ToInt32(tbCode.Text); не работает
            staff[pos].Name = tbFullName.Text;
            staff[pos].Gender = tbGender.Text;
            staff[pos].Post = tbPost.Text;
            staff[pos].Exp = Convert.ToDouble(tbExp.Text);
            staff[pos].Salary = Convert.ToDouble(tbSalary.Text);
            lbStaff.ItemsSource = staff;

        }
    }
}