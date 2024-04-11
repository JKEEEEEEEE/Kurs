using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Media;
using System.Windows.Input;
using System.Xml.XPath;
using System.Net;

namespace kursach_diplom_desctop
{
    /// <summary>
    /// Логика взаимодействия для Sotrudnik.xaml
    /// </summary>
    public partial class Sotrudnik : Window
    {
        public Sotrudnik()
        {
            InitializeComponent();
            vyv();
			FillComboBoxtype();
		}
		private void FillComboBoxtype()
		{
			string connectionString = "Data Source=SHADOURAZE\\SQLEXPRESS;Initial Catalog=kurcach_diplom;Integrated Security=True;";
			// Добавляем элементы в комбобокс
			type.Items.Add("Выкл");
			type.Items.Add("Город");
			type.Items.Add("Горы");
			type.Items.Add("Море");
			country.Items.Add("Выкл");
			city.Items.Add("Выкл");
			try
			{
				string query = "SELECT Name_Country FROM Country";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								country.Items.Add(reader["Name_Country"].ToString());
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при заполнении ComboBox: " + ex.Message);
			}
			try
			{
				string query = "SELECT Name_City FROM City";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								city.Items.Add(reader["Name_City"].ToString());
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при заполнении ComboBox: " + ex.Message);
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
		private void vyv()
		{
			Tour[] tour = ExecuteSql("SELECT [Id_Tours], [Description_Tours], [Type_Tours], [Price_Tours], [Start_Date_Tours], [End_Date_Tours], [Reservation_Number_Tours], [Booking_Date_Tours], [Booking_Status_Tours], [Link_Photo], [Name_Country], [Name_City],[Id_Hotel] FROM [dbo].[Tours] inner JOIN [dbo].[Reviews] ON [Reviews_Id] = [Id_Reviews] inner JOIN [dbo].[Payments] ON [Payments_Id] = [Id_Payments] inner JOIN [dbo].[Photo] ON [Photo_Id] = [Id_Photo] inner JOIN [dbo].[Country] ON [Country_Id] = [Id_Country] inner JOIN [dbo].[City] ON [City_Id] = [Id_City] inner JOIN [dbo].[Hotel] ON [Hotel_Id] = [Id_Hotel];").ToArray();
			listviewTour.ItemsSource = tour;
		}
		public class Tour
		{
			
			public int Id_Tours { get; set; }
			public int Id_Hotel { get; set; }
			public string Description_Tours { get; set; }
			public string Type_Tours { get; set; }
			public decimal Price_Tours { get; set; }
			public string Start_Date_Tours { get; set; }
			public string End_Date_Tours { get; set; }
			public string Reservation_Number_Tours { get; set; }
			public string Booking_Date_Tours { get; set; }
			public string Booking_Status_Tours { get; set; }
			public string Link_Photo { get; set; }
			public string Name_Country { get; set; }
			public string Name_City { get; set; }
		}

		static IEnumerable<Tour> ExecuteSql(string sql)
		{
			const string dir = "C:\\Image\\";
			SqlConnection conn = new SqlConnection("Data Source=SHADOURAZE\\SQLEXPRESS;Initial Catalog=kurcach_diplom;Integrated Security=True;");
			using (conn)
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand(sql, conn);
				SqlDataReader read = cmd.ExecuteReader();

				using (read)
				{
					int i = 0;
					while (true)
					{
						if (read.Read() == false) break;
						i++;
						var stringDate = read["Start_Date_Tours"].ToString();
						var stringDatee = read["End_Date_Tours"].ToString();

						Tour technics = new Tour()
						{
							Id_Tours = (int)read["Id_Tours"],
							Description_Tours = (string)read["Description_Tours"],
							Type_Tours = (string)read["Type_Tours"],
							Price_Tours = (decimal)read["Price_Tours"],
							Start_Date_Tours = stringDate,
							End_Date_Tours = stringDatee,
							Reservation_Number_Tours = (string)read["Reservation_Number_Tours"],
							Booking_Date_Tours = (string)read["Booking_Date_Tours"],
							Booking_Status_Tours = (string)read["Booking_Status_Tours"],
							Link_Photo = Path.Combine(dir + (string)read["Link_Photo"] + ".jpg"),
							Name_Country = (string)read["Name_Country"],
							Name_City = (string)read["Name_City"]
						};
						yield return technics;
					}
				}
			}
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			if (type.SelectedIndex == 0)
			{
				Tour[] tour = ExecuteSql("SELECT [Id_Tours], [Description_Tours], [Type_Tours], [Price_Tours], [Start_Date_Tours], [End_Date_Tours], [Reservation_Number_Tours], [Booking_Date_Tours], [Booking_Status_Tours], [Link_Photo], [Name_Country], [Name_City],[Id_Hotel] FROM [dbo].[Tours] inner JOIN [dbo].[Reviews] ON [Reviews_Id] = [Id_Reviews] inner JOIN [dbo].[Payments] ON [Payments_Id] = [Id_Payments] inner JOIN [dbo].[Photo] ON [Photo_Id] = [Id_Photo] inner JOIN [dbo].[Country] ON [Country_Id] = [Id_Country] inner JOIN [dbo].[City] ON [City_Id] = [Id_City] inner JOIN [dbo].[Hotel] ON [Hotel_Id] = [Id_Hotel];").ToArray();
				listviewTour.ItemsSource = tour;
			}
			else
			{
				Tour[] tour = ExecuteSql("SELECT [Id_Tours], [Description_Tours], [Type_Tours], [Price_Tours], [Start_Date_Tours], [End_Date_Tours], [Reservation_Number_Tours], [Booking_Date_Tours], [Booking_Status_Tours], [Link_Photo], [Name_Country], [Name_City],[Id_Hotel] FROM [dbo].[Tours] inner JOIN [dbo].[Reviews] ON [Reviews_Id] = [Id_Reviews] inner JOIN [dbo].[Payments] ON [Payments_Id] = [Id_Payments] inner JOIN [dbo].[Photo] ON [Photo_Id] = [Id_Photo] inner JOIN [dbo].[Country] ON [Country_Id] = [Id_Country] inner JOIN [dbo].[City] ON [City_Id] = [Id_City] inner JOIN [dbo].[Hotel] ON [Hotel_Id] = [Id_Hotel] WHERE [Type_Tours] LIKE " + "'" + type.SelectedValue + "%'").ToArray();
				listviewTour.ItemsSource = tour;
			}
		}

        private void country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			if (country.SelectedIndex == 0)
			{
				Tour[] tour = ExecuteSql("SELECT [Id_Tours], [Description_Tours], [Type_Tours], [Price_Tours], [Start_Date_Tours], [End_Date_Tours], [Reservation_Number_Tours], [Booking_Date_Tours], [Booking_Status_Tours], [Link_Photo], [Name_Country], [Name_City],[Id_Hotel] FROM [dbo].[Tours] inner JOIN [dbo].[Reviews] ON [Reviews_Id] = [Id_Reviews] inner JOIN [dbo].[Payments] ON [Payments_Id] = [Id_Payments] inner JOIN [dbo].[Photo] ON [Photo_Id] = [Id_Photo] inner JOIN [dbo].[Country] ON [Country_Id] = [Id_Country] inner JOIN [dbo].[City] ON [City_Id] = [Id_City] inner JOIN [dbo].[Hotel] ON [Hotel_Id] = [Id_Hotel] WHERE [Type_Tours] LIKE " + "'" + type.SelectedValue + "%'").ToArray();
				listviewTour.ItemsSource = tour;
			}
			else
			{
				Tour[] tour = ExecuteSql("SELECT [Id_Tours], [Description_Tours], [Type_Tours], [Price_Tours], [Start_Date_Tours], [End_Date_Tours], [Reservation_Number_Tours], [Booking_Date_Tours], [Booking_Status_Tours], [Link_Photo], [Name_Country], [Name_City],[Id_Hotel] FROM [dbo].[Tours] inner JOIN [dbo].[Reviews] ON [Reviews_Id] = [Id_Reviews] inner JOIN [dbo].[Payments] ON [Payments_Id] = [Id_Payments] inner JOIN [dbo].[Photo] ON [Photo_Id] = [Id_Photo] inner JOIN [dbo].[Country] ON [Country_Id] = [Id_Country] inner JOIN [dbo].[City] ON [City_Id] = [Id_City] inner JOIN [dbo].[Hotel] ON [Hotel_Id] = [Id_Hotel] WHERE [Type_Tours] LIKE " + "'" + type.SelectedValue + "%' and Name_Country LIKE " + "'" + country.SelectedValue + "%'").ToArray();
				listviewTour.ItemsSource = tour;
			}
		}

		private void city_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			if (country.SelectedIndex == 0)
			{
				Tour[] tour = ExecuteSql("SELECT [Id_Tours], [Description_Tours], [Type_Tours], [Price_Tours], [Start_Date_Tours], [End_Date_Tours], [Reservation_Number_Tours], [Booking_Date_Tours], [Booking_Status_Tours], [Link_Photo], [Name_Country], [Name_City],[Id_Hotel] FROM [dbo].[Tours] inner JOIN [dbo].[Reviews] ON [Reviews_Id] = [Id_Reviews] inner JOIN [dbo].[Payments] ON [Payments_Id] = [Id_Payments] inner JOIN [dbo].[Photo] ON [Photo_Id] = [Id_Photo] inner JOIN [dbo].[Country] ON [Country_Id] = [Id_Country] inner JOIN [dbo].[City] ON [City_Id] = [Id_City] inner JOIN [dbo].[Hotel] ON [Hotel_Id] = [Id_Hotel] WHERE [Type_Tours] LIKE " + "'" + type.SelectedValue + "%' and Name_Country LIKE " + "'" + country.SelectedValue + "%'").ToArray();
				listviewTour.ItemsSource = tour;
			}
			else
			{
				Tour[] tour = ExecuteSql("SELECT [Id_Tours], [Description_Tours], [Type_Tours], [Price_Tours], [Start_Date_Tours], [End_Date_Tours], [Reservation_Number_Tours], [Booking_Date_Tours], [Booking_Status_Tours], [Link_Photo], [Name_Country], [Name_City],[Id_Hotel] FROM [dbo].[Tours] inner JOIN [dbo].[Reviews] ON [Reviews_Id] = [Id_Reviews] inner JOIN [dbo].[Payments] ON [Payments_Id] = [Id_Payments] inner JOIN [dbo].[Photo] ON [Photo_Id] = [Id_Photo] inner JOIN [dbo].[Country] ON [Country_Id] = [Id_Country] inner JOIN [dbo].[City] ON [City_Id] = [Id_City] inner JOIN [dbo].[Hotel] ON [Hotel_Id] = [Id_Hotel] WHERE [Type_Tours] LIKE " + "'" + type.SelectedValue + "%' and Name_Country LIKE " + "'" + country.SelectedValue + "%' and Name_City LIKE " + "'" + city.SelectedValue + "%'").ToArray();
				listviewTour.ItemsSource = tour;
			}
		}

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
			var selectedItem = (Tour)listviewTour.SelectedItem;

			if (selectedItem != null)
			{
				int Id = (selectedItem.Id_Hotel);
				decimal prize = (selectedItem.Price_Tours);

				Bron bron = new Bron(Id, prize);
				bron.Show();
			}
		}
    }
}
