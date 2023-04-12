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
using ООО_Ткани.Models;
using ООО_Ткани.Windows;

namespace ООО_Ткани
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        db_demoexalov5Context DbContext;
        int _ErrorCount = 0;

        /// <summary>
        /// Конструктор MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DbContext = new db_demoexalov5Context();
        }

        /// <summary>
        /// Функция вызываемая, при нажатии кнопки
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Обработчик события</param>
        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LoginTextBox.Text) 
                && !string.IsNullOrWhiteSpace(PasswordPasswordBox.Password))
            {
                User user = DbContext.User.Where(u => u.UserLogin == LoginTextBox.Text
                && u.UserPassword == PasswordPasswordBox.Password).FirstOrDefault();

                if (user != null)
                {
                    MessageBox.Show($"Вы авторизовались, как {user.UserRoleNavigation.RoleName}" +
                        $" {user.UserName} {user.UserSurname} {user.UserPatronymic}", "Информация",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    ProductListWindow productListWindow = new ProductListWindow(user);
                    productListWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин/пароль", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    _ErrorCount++;

                    if (_ErrorCount >= 2)
                    {
                        Thread.Sleep(10000);

                        MessageBox.Show("Слишком много неудачных попыток входа система заблокирована на 10 секунд",
                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поля", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Функция вызываемая, при нажатии кнопки
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Обработчик события</param>
        private void AuthorizationAsGuestButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы авторизовались, как гость", "Информация",
                MessageBoxButton.OK, MessageBoxImage.Information);

            ProductListWindow productListWindow = new ProductListWindow(null);
            productListWindow.Show();
            Close();
        }
    }
}
