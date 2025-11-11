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

        /// <summary>
        /// Структура
        /// </summary>
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

        /// <summary>
        /// Создание структуры 
        /// </summary>
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

        /// <summary>
        /// Вывод структуры в листбокс
        /// </summary>
        private void ShowStaff()
        {
            lbStaff.ItemsSource = staff1;
        }

        /// <summary>
        /// Изменение значений в структуре
        /// </summary>
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            bool f1, f2,f3;
            lbStaff.ItemsSource = null;
            f1 = Int32.TryParse(tbCode.Text, out int code);
            f2 = Double.TryParse(tbExp.Text, out double exp);
            f3 = Double.TryParse(tbSalary.Text, out double salary);
            if (f1 == f2 == f3 == true && code>=0 && code< staff1.Length && exp>=0 && salary>=0)
            { 
                int pos = code;
                staff1[pos].Code = code; 
                staff1[pos].Name = tbFullName.Text;
                staff1[pos].Gender = tbGender.Text;
                staff1[pos].Post = tbPost.Text;
                staff1[pos].Exp = exp;
                staff1[pos].Salary = salary;
            }
            else
            {
                MessageBox.Show("Проверьте корректность введенных данных!!!");
            }
            lbStaff.ItemsSource = staff1;
        }

        /// <summary>
        /// Кнопка выхода
        /// </summary>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        /// <summary>
        /// Кнопка о программе
        /// </summary>
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №8\r\nРабота с типом данных структура.\r\nЗаполнить таблицу со списком сотрудников на 7 человек с полями: ФИО, пол, \r\nдолжность, стаж работы, оклад. Вывести результат на экран.\r\nВывести средний оклад.\r\nВыполнила:\r\nСтудентка гр.ИСП-31\r\nКирюшова В.");
        }

        /// <summary>
        /// Удаление значений в листбоксе
        /// </summary>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            bool f1 = int.TryParse(tbCode.Text, out int pos);
            if (f1 == true && pos>=0 && pos<7)
            {

                staff1[pos] = new Staff(pos, "", "", "", 0, 0);
                lbStaff.ItemsSource = null;
                lbStaff.ItemsSource = staff1;
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Введите корректный код сотрудника");
            }
        }

        /// <summary>
        /// Метод очистки полей листбокса
        /// </summary>
        private void ClearInputFields()
        {
            tbCode.Clear();
            tbFullName.Clear();
            tbGender.Clear();
            tbPost.Clear();
            tbExp.Clear();
            tbSalary.Clear();
        }

        /// <summary>
        /// Кнопка расчета среднего значения оклада
        /// </summary>
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            double sal = 0;
            int count = 0;
            for (int i = 0; i<7; i++)
            {
                sal += staff1[i].Salary;
                if (staff1[i].Salary>0)
                {  
                    count++; 
                }
            }
            sal = sal / count;
            tbSal.Text = sal.ToString();
            
        }
    }
}