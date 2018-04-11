using ClassLibr;
using ClassLibr.Service;
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

namespace Cloud9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User user;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void logInButtonClick(object sender, RoutedEventArgs e)
        {
            UserService us = new UserService();
            List<User> users = us.SelectAll();

            bool isCorrectLogin = false;
            bool isCorrectPassword = false;
            User tempUser = new User();
            foreach (User i in users)
            {
                if (i.Login == loginBox.Text)
                {
                    isCorrectLogin = true;
                }
                if (i.Password == passwordBox.Password && isCorrectLogin == true)
                {
                    isCorrectPassword = true;
                    tempUser = i;
                    break;
                }
                else
                {
                    isCorrectLogin = false;
                    isCorrectPassword = false;
                }
            }
            if (isCorrectPassword == false)
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
            else
            {
                user = tempUser;
            }
        }

        private void RegistrationButtonClick(object sender, RoutedEventArgs e)
        {
            RegistrationWindow newW = new RegistrationWindow(this);
            newW.Show();
            this.Close();
        }
    }
}
