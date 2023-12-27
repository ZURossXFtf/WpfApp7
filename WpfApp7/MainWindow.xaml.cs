using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
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
using static System.Net.Mime.MediaTypeNames;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetBook(uri.Text);
        }
        void GetBook(string uri)
        {
            WebClient wc = new WebClient();

            wc.DownloadStringCompleted += (s, eArgs) =>
            {
                string theBook = eArgs.Result;
                Dispatcher?.Invoke(() => text.Text = theBook);
            };
            wc.DownloadStringAsync(new Uri(uri));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string theBook = text.Text;
            int sum = 0;
            foreach (char c in theBook)
            {
                sum += (int)c;
            }
            sumLabel.Content = "Сумма кодов всех элементов: " + sum;
        }
    }
}
