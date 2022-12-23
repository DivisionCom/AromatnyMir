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
using Ароматный_мир.Pages;

namespace Ароматный_мир
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SpHeader.Background = new SolidColorBrush(Color.FromRgb(255, 204, 153));
            btnExit.Background = new SolidColorBrush(Color.FromRgb(204, 102, 0));
            btnBack.Background = new SolidColorBrush(Color.FromRgb(204, 102, 0));
            ConnectOdb.conObj = new TradeEntities();

            FrameObj.frameMain = frmMain;
            frmMain.Navigate(new PageLogin(this));
        }

        /// <summary>
        /// Подстановка в TextBlock ФИО текущего пользователя
        /// </summary>
        public void CurrentUserName()
        {
            tblockUserName.Text = Flag.flag;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть приложение?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                frmMain.GoBack();
            }
            catch
            {
                MessageBox.Show("Переход назад невозможен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
