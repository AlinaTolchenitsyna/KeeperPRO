using KeeperPRO.UI.Cls;
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

namespace KeeperPRO.UI.Wnds
{
    /// <summary>
    /// Логика взаимодействия для EditingWindow.xaml
    /// </summary>
    public partial class EditingWindow : Window
    {
        public DB.Application currentApplication = new DB.Application();
        public EditingWindow(DB.Application selectedApplication)
        {
            InitializeComponent();

            

            currentApplication = selectedApplication;
            DataContext = currentApplication;
            cbStatus.ItemsSource = DB.KeeperPROEntities.GetContext().Status.ToList();

            if (DB.KeeperPROEntities.GetContext().Visitor.Where(c => c.blacklisted == true && c.id == currentApplication.visitorId).Count() > 0)
            {
                currentApplication.statusId = 2;
                DB.KeeperPROEntities.GetContext().SaveChanges();
                MessageBox.Show("Посетитель находится в чёрном списке. Заявка отклонена.");
                this.Close();
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (cbStatus.SelectedItem != null)
            {
                try
                {
                    DB.KeeperPROEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Выберите статус заявки");
            }
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            Manager.isCheckingOpen = false;
        }
    }
}
