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

namespace BankAppAsync
{
    /// <summary>
    /// Interaction logic for OperationsUI.xaml
    /// </summary>
    public partial class OperationsUI : Window
    {
        public Account CurrentAccount { get; private set; }
        private delegate bool OperationAsync(Account a, double s);

        public OperationsUI(Account account)
        {
            CurrentAccount = account;
            InitializeComponent();
            RefreshInfo();
        }

        private void RefreshInfo()
        {
            CurrentAccount = ATMService.Bank.Accounts.SingleOrDefault(a => a.Id == CurrentAccount.Id);
            accountNumberInfo.Text = "Операции со счетом с номером " + CurrentAccount.Id;
            currentSumInfo.Text = "Текущий баланс: " + CurrentAccount.Balance;
            errorInfo.Text = "";
            currencyInfo.Text = CurrentAccount.Currency;
            accountNumberInfo.Text = "Операции со счетом с номером " + CurrentAccount.Id;
            currentSumInfo.Text = "Текущий баланс: " + CurrentAccount.Balance;
        }

        private void DepositClicked(object sender, RoutedEventArgs e)
        {
            foreach (char c in enteredAmount.Text)
            {
                if (c < '0' || c > '9')
                    if (c != ',')
                    {
                        errorInfo.Text = "Введите число (деление через запятую)";
                        return;
                    }
            }

            OperationAsync deposit = ATMService.Deposit;
            var result = deposit.BeginInvoke(CurrentAccount, double.Parse(enteredAmount.Text), null, null);

            if (!deposit.EndInvoke(result))
            {
                errorInfo.Text = "Произошла ошибка. Попробуйте позднее";
                return;
            }
            RefreshInfo();
        }
        private void WithdrawClicked(object sender, RoutedEventArgs e)
        {
            foreach (char c in enteredAmount.Text)
            {
                if (c < '0' || c > '9')
                    if (c != ',')
                    {
                        errorInfo.Text = "Введите число (деление через запятую)";
                        return;
                    }
            }

            OperationAsync withdraw = ATMService.Withdraw;
            var result = withdraw.BeginInvoke(CurrentAccount, double.Parse(enteredAmount.Text), null, null);

            if (!withdraw.EndInvoke(result))
            {
                errorInfo.Text = "Введена некорректная сумма или ошибка соединения";
                return;
            }
            RefreshInfo();
        }
        private void BackClicked(object sender, RoutedEventArgs e)
        {
            UserUI userUI = new UserUI(ATMService.Bank.Clients.SingleOrDefault(c => c.Id == CurrentAccount.ClientId));
            userUI.Show();
            Close();
        }
    }
}
