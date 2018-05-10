using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace BankAppAsync
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate bool IsValidAccountAsync(string iin, string checkPassword);
        private delegate Client GetUserAsync(Func<Client, bool> asd);
        public int LoginAttempts { get; private set; }
        public NavigationService navigation { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            LoginAttempts = 3;
            navigation = NavigationService.GetNavigationService(this);
            passwordBox.Password = "sfsfsefsef";
            iinBox.Text = "234234234221";
        }

        private void LoginAttempt(object sender, RoutedEventArgs e)
        {
            IsValidAccountAsync validator = ATMService.IsAccountValid;
            IAsyncResult asyncResult = validator.BeginInvoke(iinBox.Text, passwordBox.Password, null, null);
            LoginAttempts--;
            if (!validator.EndInvoke(asyncResult))
            {
                if (LoginAttempts <= 0)
                {
                    LoginFailed nextPage = new LoginFailed();
                    nextPage.Show();
                    this.Close();
                }
                attemptsLeft.Visibility = Visibility.Visible;
                attemptsLeft.Text = "Неверный пароль или логин. Осталось попыток: " + LoginAttempts;
            }
            else
            {
                UserUI userUI = new UserUI(ATMService.Bank.Clients.SingleOrDefault(c => c.IIN == iinBox.Text));
                userUI.Show();
                this.Close();
            }
        }
    }
}
