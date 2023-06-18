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
    /// Логика взаимодействия для ApplicationListWindow.xaml
    /// </summary>
    public partial class ApplicationListWindow : Window
    {
        public ApplicationListWindow()
        {
            InitializeComponent();
            lbxApplications.ItemsSource = DB.KeeperPROEntities.GetContext().Application.Where(c => c.employeeId == Manager.employeeId).ToList();
            if (lbxApplications.ItemsSource == null)
            {
                lblNoResults.Visibility = Visibility.Visible;
            }
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.isCheckingOpen == false)
            {
                try
                {

                    EditingWindow editingWindow = new EditingWindow((sender as Button).DataContext as DB.Application);
                    editingWindow.Show();
                    Manager.isCheckingOpen = true;
                }
                catch
                {

                }
            }
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            DB.LogAutho newLogAutho = new DB.LogAutho();
            DateTime dateTime = new DateTime();
            dateTime = DateTime.UtcNow;
            newLogAutho.dateTimeLog = dateTime;
            newLogAutho.employeeId = Manager.employeeId;
            DB.KeeperPROEntities.GetContext().LogAutho.Add(newLogAutho);
            DB.KeeperPROEntities.GetContext().SaveChanges();
            MessageBox.Show("Запись успешно сохранена в истории входа.", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentApplications = DB.KeeperPROEntities.GetContext().Application.ToList();
            if (!string.IsNullOrWhiteSpace(tbxSearch.Text))
            {
                currentApplications = currentApplications.Where(p => p.Visitor.fName.ToLower().Contains(tbxSearch.Text.ToLower()) || p.Visitor.lName.ToLower().Contains(tbxSearch.Text.ToLower()) || p.Visitor.patronymic.ToLower().Contains(tbxSearch.Text.ToLower())).ToList();
            }
            lbxApplications.ItemsSource = currentApplications;
            if (currentApplications.Count() == 0)
            {
                lblNoResults.Visibility = Visibility.Visible;
            }
            else
            {
                lblNoResults.Visibility = Visibility.Hidden;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var applicationForReceiving = lbxApplications.SelectedItems.Cast<DB.Application>().ToList();
            if (applicationForReceiving.Count() > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить выбранную заявку?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        DB.KeeperPROEntities.GetContext().Application.RemoveRange(applicationForReceiving);
                        DB.KeeperPROEntities.GetContext().SaveChanges();
                        MessageBox.Show("Заявка успешно удалена.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        lbxApplications.ItemsSource = DB.KeeperPROEntities.GetContext().Application.ToList();
                        if (lbxApplications.ItemsSource == null)
                        {
                            lblNoResults.Visibility = Visibility.Visible;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                    
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow logInWindow = new LogInWindow();
            logInWindow.Show();
            this.Close();
        }

        private void btnDiagram_Click(object sender, RoutedEventArgs e)
        {
            DiagramWindow diagramWindow = new DiagramWindow();
            diagramWindow.Show();
        }
    }

    }

