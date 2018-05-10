using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BankAppAsync
{
    /// <summary>
    /// Interaction logic for UserUI.xaml
    /// </summary>
    public partial class UserUI : Window
    {
        public Client CurrentClient { get; private set; }
        private delegate IEnumerable<Account> GetClientAccountAsync(Client a);
        public UserUI(Client client)
        {
            InitializeComponent();
            CurrentClient = client;
            greetingUserUI.Text = "Добро пожаловать, " + CurrentClient.Name;

            GetClientAccountAsync getClientAccountAsync = ATMService.GetClientAccount;
            var result = getClientAccountAsync.BeginInvoke(client, null, null);
            userAccountsGrid.ItemsSource = getClientAccountAsync.EndInvoke(result).ToList();
        }

        private void SelectedAccountUI(object sender, MouseButtonEventArgs e)
        {
            OperationsUI operationsUI = new OperationsUI(userAccountsGrid.SelectedItem as Account);
            Close();
            operationsUI.Show();
        }
    }
}
