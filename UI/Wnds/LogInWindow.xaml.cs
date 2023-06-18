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
using System.Windows.Shapes;
using KeeperPRO.DB;
using KeeperPRO.UI.Cls;
using KeeperPRO.UI.Wnds;

namespace KeeperPRO.UI
{
    /// <summary>
    /// Логика взаимодействия для LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        
        public LogInWindow()
        {
            InitializeComponent();
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (tbxLogin.Foreground == Brushes.Gainsboro)
            {
                errors.AppendLine("Введите логин");
            }
            if (pswBox.Password == "")
            {
                errors.AppendLine("Введите пароль");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                foreach (DB.Employee employee in DB.KeeperPROEntities.GetContext().Employee.Where(c => c.login.Equals(tbxLogin.Text) && c.password.Equals(pswBox.Password)))
                {
                
                Manager.employeeId = employee.id;
                    ApplicationListWindow applicationListWindow = new ApplicationListWindow();
                    applicationListWindow.Show();
                    this.Close();
                    return;
                }
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                MessageBox.Show("Невозможно подключиться к базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        

        private void tbxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxLogin.Foreground == Brushes.Gainsboro)
            {
                tbxLogin.Text = "";
                tbxLogin.Foreground = Brushes.Black;
            }
        }

        private void tbxLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxLogin.Text == "")
            {
                tbxLogin.Text = "Введите логин";
                tbxLogin.Foreground = Brushes.Gainsboro;

            }
        }

        

        private void tbxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            pswBox.Visibility = Visibility.Visible;
            tbxPassword.Visibility = Visibility.Collapsed;
            pswBox.Focus();
        }

        private void pswBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pswBox.Password == "")
            {
                tbxPassword.Visibility = Visibility.Visible;
                pswBox.Visibility = Visibility.Collapsed;
            }
        }
    }
}
