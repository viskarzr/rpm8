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

        //private void InitializeStaff()
        //{
        //    staff = new Staff[7]
        //    {
        //        new Staff(0, "Иванов Иван Иванович", "Муж", "Директор", 15.5, 150000),
        //        new Staff(1, "Петрова Анна Сергеевна", "Жен", "Бухгалтер", 8.2, 80000),
        //        new Staff(2, "Сидоров Петр Михайлович", "Муж", "Программист", 5.0, 120000),
        //        new Staff(3, "Кузнецова Ольга Владимировна", "Жен", "Менеджер", 3.5, 60000),
        //        new Staff(4, "Васильев Алексей Дмитриевич", "Муж", "Аналитик", 7.8, 95000),
        //        new Staff(5, "Николаева Екатерина Павловна", "Жен", "Дизайнер", 4.3, 75000),
        //        new Staff(6, "Морозов Денис Игоревич", "Муж", "Тестировщик", 2.7, 50000)
        //    };
        //}
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            lbStaff.ItemsSource = null;
            int pos = Convert.ToInt32(tbCode.Text);
            staff[pos].Code = Convert.ToInt32(tbCode.Text); 
            staff[pos].Name = tbFullName.Text;
            staff[pos].Gender = tbGender.Text;
            staff[pos].Post = tbPost.Text;
            staff[pos].Exp = Convert.ToDouble(tbExp.Text);
            staff[pos].Salary = Convert.ToDouble(tbSalary.Text);
            lbStaff.ItemsSource = staff;

        }
    }
}