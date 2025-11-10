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
            InitializeStaff();
            ShowStaff();
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
                return $"Код:{Code} - ФИО:{Name,40}, Пол:{Gender,7}, Должность:{Post,45}, Стаж работы:{Exp,50:F1} лет, Оклад:{Salary,7:F2}.";
            }
        }

        Staff[] staff1;

        private void InitializeStaff()
        {
            staff1 = new Staff[7]
            {
                new Staff(0, "", "", "", 0, 0),
                new Staff(1, "", "", "", 0, 0),
                new Staff(2, "", "", "", 0, 0),
                new Staff(3, "", "", "", 0, 0),
                new Staff(4, "", "", "", 0, 0),
                new Staff(5, "", "", "", 0, 0),
                new Staff(6, "", "", "", 0, 0)
            };
        }
        private void ShowStaff()
        {
            lbStaff.ItemsSource = staff1;
        }
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            lbStaff.ItemsSource = null;
            int pos = Convert.ToInt32(tbCode.Text);
            staff1[pos].Code = Convert.ToInt32(tbCode.Text); 
            staff1[pos].Name = tbFullName.Text;
            staff1[pos].Gender = tbGender.Text;
            staff1[pos].Post = tbPost.Text;
            staff1[pos].Exp = Convert.ToDouble(tbExp.Text);
            staff1[pos].Salary = Convert.ToDouble(tbSalary.Text);
            lbStaff.ItemsSource = staff1;

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №8\r\nРабота с типом данных структура.\r\nЗаполнить таблицу со списком сотрудников на 7 человек с полями: ФИО, пол, \r\nдолжность, стаж работы, оклад. Вывести результат на экран.\r\nВывести средний оклад.\r\nВыполнила:\r\nСтудентка гр.ИСП-31\r\nКирюшова В.");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbCode.Text, out int pos) && pos >= 0 && pos < staff1.Length)
            {
                // Reset the staff member at the specified position
                staff1[pos] = new Staff(pos, "", "", "", 0, 0);

                // Refresh the display
                lbStaff.ItemsSource = null;
                lbStaff.ItemsSource = staff1;

                // Clear input fields
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Введите корректный код сотрудника");
            }
        }

        private void ClearInputFields()
        {
            tbCode.Text = "";
            tbFullName.Text = "";
            tbGender.Text = "";
            tbPost.Text = "";
            tbExp.Text = "";
            tbSalary.Text = "";
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            double sal = 0;
            int count = 0;
            for (int i = 0; i<7; i++)
            {
                sal += staff1[i].Salary;      
                count++;
            }
            sal = sal / count;
            tbSal.Text = sal.ToString();
            
        }
    }
}