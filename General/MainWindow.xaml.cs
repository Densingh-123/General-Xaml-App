using Microsoft.Win32;
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

namespace General
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            login.Visibility = Visibility.Visible;
            register.Visibility = Visibility.Collapsed;
            home.Visibility = Visibility.Collapsed;

            showdata.Visibility = Visibility.Collapsed;
            showdatas.Visibility = Visibility.Collapsed;

            errormessage.Visibility = Visibility.Collapsed;
            error.Visibility = Visibility.Collapsed;
            todo.Visibility = Visibility.Collapsed;
            calculater.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            errormessage.Visibility = Visibility.Collapsed;
            showdata.Visibility = Visibility.Collapsed;

            string username = usernameinput.Text.Trim();
            string email = emailinput.Text.Trim();
            string password = passwordinput.Password;
            displayName.Text = $"Welcome, {username}!";
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password)){
                errormessage.Visibility = Visibility.Visible;
                errormessage.Text = "Please Enter all Details";
                return;
            }
            UserNameData.Text = username;
            EmailData.Text = email;
            PasswordData.Text = password;
            home.Visibility = Visibility.Visible;
            login.Visibility = Visibility.Collapsed;
            register.Visibility = Visibility.Collapsed;
            usernameinput.Clear();
            emailinput.Clear();
            passwordinput.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            showdata.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string name = NameInput.Text.Trim();
            string email = EmailInput.Text.Trim();
            string password = PasswordInput.Password;
            string confirmpassword = C_PasswordInput.Password;

            if (password != confirmpassword)
            {
                error.Visibility = Visibility.Visible;
                error.Text = "Password does not match";
                return;

            }
            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                error.Text = "Please Fill All This Feilds";
                return;
            }
            UserNameDatas.Text = name;
            EmailDatas.Text = email;
            PasswordDatas.Text = password;
            home.Visibility = Visibility.Visible;
            login.Visibility = Visibility.Collapsed;
            register.Visibility = Visibility.Collapsed;
            NameInput.Clear();
            EmailInput.Clear();
            PasswordInput.Clear();
            C_PasswordInput.Clear();
        }

        private void gotologin_Click(object sender, RoutedEventArgs e)
        {
            login.Visibility = Visibility.Visible;
            register.Visibility = Visibility.Collapsed;
        }

        private void gotoregister_Click(object sender, RoutedEventArgs e)
        {
            login.Visibility = Visibility.Collapsed;
            register.Visibility = Visibility.Visible;
        }

        private void todo_Click(object sender, RoutedEventArgs e)
        {
            todo.Visibility = Visibility.Visible;
            calculater.Visibility = Visibility.Collapsed;
            currencyConverter.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string task = todoInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(task))
            {
                MessageBox.Show("Please Enter a Task");
                return;
            }
            Border border = new Border
            {
                Background = Brushes.DarkSlateGray,
                CornerRadius = new CornerRadius(8),
                Padding = new Thickness(15),
                Margin = new Thickness(0, 0, 0, 10)
            };
            TextBlock textBlock = new TextBlock
            {
                Text = task,
                Foreground = Brushes.White,
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                TextWrapping = TextWrapping.Wrap
                
                
            };
            border.Child = textBlock;
            todoContainer.Children.Add(border);
            todoInput.Clear();
            todoInput.Focus();
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(add1.Text);
            int b = Convert.ToInt32(add2.Text);
            calcres.Text = (a + b).ToString();
            return;
        }

        private void subbtn_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(sub1.Text);
            int b = Convert.ToInt32(sub2.Text);
            calcres.Text = (a - b).ToString();
            return;
        }

        private void mulbtn_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(mul1.Text);
            int b = Convert.ToInt32(mul2.Text);
            calcres.Text = (a * b).ToString();
            return;
        }

        private void divbtn_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(div1.Text);
            int b = Convert.ToInt32(div2.Text);
            calcres.Text = (a / b).ToString();
            return;
        }

        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            calculater.Visibility = Visibility.Visible;
            todo.Visibility = Visibility.Collapsed;
            currencyConverter.Visibility = Visibility.Collapsed;
        }

        private void currency_Click(object sender, RoutedEventArgs e)
        {
            currencyConverter.Visibility = Visibility.Visible;
            todo.Visibility = Visibility.Collapsed;
            calculater.Visibility = Visibility.Collapsed;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            // Get amount entered by the user
            double amount = Convert.ToDouble(AmountInput.Text);

            // Get selected currency codes (first 3 letters: INR, USD, EUR, etc.)
            string fromCurrency =
                ((ComboBoxItem)FromCurrencyBox.SelectedItem).Content.ToString().Substring(0, 3);

            string toCurrency =
                ((ComboBoxItem)ToCurrencyBox.SelectedItem).Content.ToString().Substring(0, 3);

            // Store conversion rates (relative to USD)
            Dictionary<string, double> rates = new Dictionary<string, double>()
    {
        { "USD", 1.0 },
        { "INR", 83.50 },
        { "EUR", 0.92 },
        { "GBP", 0.80 },
        { "JPY", 155.0 }
    };

            // Convert:
            // Step 1: Convert source currency to USD
            double usdAmount = amount / rates[fromCurrency];

            // Step 2: Convert USD to target currency
            double result = usdAmount * rates[toCurrency];

            // Show result
            ResultText.Text = "Result: " + result.ToString("F2");
        }
    }
}
