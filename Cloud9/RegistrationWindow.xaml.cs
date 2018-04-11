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
using System.Windows.Shapes;

namespace Cloud9
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        Window window;
        public RegistrationWindow(MainWindow window)
        {
            this.window = window;
            InitializeComponent();
        }

        private void RegistrationButtonClick(object sender, RoutedEventArgs e)
        {
            UserService us = new UserService();
            User user = new User();
            if (loginBox.Text != null)
            {
                List<User> users = us.SelectAll();
                bool isCorrect = true;
                foreach (User i in users)
                {
                    if (i.Login == loginBox.Text)
                    {
                        isCorrect = false;
                    }
                }
                if (isCorrect == true)
                {
                    user.Login = loginBox.Text;
                }
                else
                {
                    MessageBox.Show("Такой логин уже существует");
                }
            }
            if (passwordBox.Password != null && secondPasswordBox.Password == passwordBox.Password)
            {
                user.Password = passwordBox.Password;
            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
            }
            if (nickNameBox.Text != null)
            {
                user.NickName = patronymicBox.Text;
            }
            else
            {
                MessageBox.Show("Введите никнейм");
            }
            user.Name = nameBox.Text;
            user.Surname = surnameBox.Text;
            user.Patronymic = patronymicBox.Text;
            us.Create(user);
            Closed();
        }

        new private void Closed()
        {
            window.Show();
        }
    }
}
