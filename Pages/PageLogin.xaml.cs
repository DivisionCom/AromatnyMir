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
using Ароматный_мир.AppData;

namespace Ароматный_мир.Pages
{
    /// <summary>
    /// Interaction logic for PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        private MainWindow _window;
        public PageLogin(MainWindow window)
        {
            InitializeComponent();
            _window = window;
            btnGuest.Foreground = new SolidColorBrush(Color.FromRgb(204, 102, 0));
            btnEnter.Background = new SolidColorBrush(Color.FromRgb(204, 102, 0));
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentUser = ConnectOdb.conObj.User.FirstOrDefault(u => u.UserLogin == tboxLogin.Text && u.UserPassword == pwbPassword.Password);
                if (currentUser == null)
                {
                    MessageBox.Show("Такого пользователя не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    Flag.flag = "";
                    _window.CurrentUserName();
                }
                else
                {
                    Flag.role = currentUser.UserRole;
                    switch (Flag.role)
                    {
                        case 1:
                            Flag.flag = currentUser.UserSurname + " " + currentUser.UserName + " " + currentUser.UserPatronymic;
                            FrameObj.frameMain.Navigate(new PageProducts());
                            _window.CurrentUserName();
                            break;
                        case 2:
                            Flag.flag = currentUser.UserSurname + " " + currentUser.UserName + " " + currentUser.UserPatronymic;
                            FrameObj.frameMain.Navigate(new PageProducts());
                            _window.CurrentUserName();
                            break;
                        case 3:
                            Flag.flag = currentUser.UserSurname + " " + currentUser.UserName + " " + currentUser.UserPatronymic;
                            FrameObj.frameMain.Navigate(new PageProducts());
                            _window.CurrentUserName();
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            Flag.role = 4;
            Flag.flag = "Гость";
            _window.CurrentUserName();
            FrameObj.frameMain.Navigate(new PageProducts());
        }
    }
}
