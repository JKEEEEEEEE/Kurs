using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace kursach_diplom_desctop
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private readonly string _apiUrl = "https://localhost:7041/api";

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Logavtr.Text;
            string password = Passavtr.Password;

            string token = await Authorizatio(login, password);
            if (token != null)
            {
                if (Registr.IsChecked == true)
                {
                    string authKey = await GetAuthKeyAsync(login);
                    if (authKey != null)
                    {
                        try
                        {
                            // сохраняем данные в реестре
                            RegistryKey currentUser = Registry.CurrentUser;
                            RegistryKey subKey = currentUser.CreateSubKey("Practi");
                            subKey.SetValue("Login", login);
                            subKey.SetValue("AuthKey", authKey);
                            subKey.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не удалось сохранить данные в реестре: {ex.Message}", "Ошибка");
                        }
                    }
                }
                if (login == "Qwe")
                {
					AdministratorMenu administratorMenu = new AdministratorMenu(token);
					administratorMenu.Show();
					Close();
				}
                else
                {
					Sotrudnik sotrudnik = new Sotrudnik();
					sotrudnik.Show();
					Close();
				}
            }
        }

        private async Task<string> Authorizatio(string login, string password)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{_apiUrl}/Users/{login}/{password}");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                    return null;
                }
            }
        }

        public void RemoveText(object sender, EventArgs e)
        {
            TextBox instance = (TextBox)sender;
            if (instance.Text == instance.Tag.ToString())
                instance.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            TextBox instance = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(instance.Text))
                instance.Text = instance.Tag.ToString();
        }

        private async Task<string> GetAuthKeyAsync(string login)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{_apiUrl}/Users/auth_key?LoginUser={login}");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    MessageBox.Show("Ошибка получения AuthKey.");
                    return null;
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string login = null;
            string authKey = null;

            RegistryKey currentUser = Registry.CurrentUser;
            RegistryKey subKey = currentUser.OpenSubKey("Practice");
            if (subKey != null)
            {
                login = subKey.GetValue("Login", null) as string;
                authKey = subKey.GetValue("AuthKey", null) as string;
                subKey.Close();
            }
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(authKey))
            {
                return;
            }

            string apiMethod = $"{_apiUrl}/Users/authentication?LoginUser={login}&AuthKey={authKey}";

            string token = await AUTH_key(login, authKey);
            if (!string.IsNullOrEmpty(token))
            {

                MessageBoxResult result = MessageBox.Show("Есть сохранённые данные", "Продолжить?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // пользователь нажал "Да"
                    AdministratorMenu administratorMenu = new AdministratorMenu(token);
                    administratorMenu.Show();
                    Close();
                }
                else
                {
                    
                }
            }
        }

        private async Task<string> AUTH_key(string login, string key)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{_apiUrl}/Users/authentication?LoginUser={login}&AuthKey={key}");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                    return null;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
