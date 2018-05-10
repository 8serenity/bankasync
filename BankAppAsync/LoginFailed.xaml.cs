using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BankAppAsync
{
    /// <summary>
    /// Interaction logic for LoginFailed.xaml
    /// </summary>
    public partial class LoginFailed : Window
    {
        public LoginFailed()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += OnTimedEvent;
            timer.Start();
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
