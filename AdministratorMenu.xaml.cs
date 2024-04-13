using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Xml.Linq;
using kursach_diplom_desctop.Models;
using static System.Net.Mime.MediaTypeNames;
using LicenseContext = OfficeOpenXml.LicenseContext;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using ScottPlot;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Runtime.Remoting.Lifetime;
using DocumentFormat.OpenXml.AdditionalCharacteristics;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Data;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Vml.Office;

namespace kursach_diplom_desctop
{
	/// <summary>
	/// Логика взаимодействия для AdministratorMenu.xaml
	/// </summary>
	public partial class AdministratorMenu : Window
	{
		public AdministratorMenu(string Token)
		{
			InitializeComponent();
			Tokin = Token;
			com.Items.Add("Город");
			com.Items.Add("Страна");
			com.Items.Add("Питание");
			com.Items.Add("Отель");
			com.Items.Add("Оплата");
			com.Items.Add("Фото");
			com.Items.Add("Маршрут посещений");
			com.Items.Add("Отзывы");
			com.Items.Add("Роль");
			com.Items.Add("Номер");
			com.Items.Add("Тип номера");
			com.Items.Add("Услуги");
			com.Items.Add("Токен");
			com.Items.Add("Тур");
			com.Items.Add("Маршрут туриста");
			com.Items.Add("Пользователи");
			com.SelectedIndex = 1;
		}

		public string Tokin = "";
		public int count = 2;

		public string ConvertIntArrayToString(int[] array)
		{
			string result = "[";

			for (int i = 0; i < array.Length; i++)
			{
				result += array[i].ToString();

				if (i < array.Length - 1)
				{
					result += ",";
				}
			}

			result += "]";

			return result;
		}

		public async Task DateTable_Loaded(int currentTable)
		{
			HttpClient client = new HttpClient();
			switch (currentTable)
			{
				case 1:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response1 = await client.GetAsync($"https://localhost:7041/api/Cities");
					string json1 = await response1.Content.ReadAsStringAsync();
					List<City> data1 = JsonConvert.DeserializeObject<List<City>>(json1);
					DateTable.ItemsSource = data1;

					break;
				case 2:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response2 = await client.GetAsync($"https://localhost:7041/api/Countries");
					string json2 = await response2.Content.ReadAsStringAsync();
					List<Country> data2 = JsonConvert.DeserializeObject<List<Country>>(json2);
					DateTable.ItemsSource = data2;

					break;
				case 3:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response3 = await client.GetAsync($"https://localhost:7041/api/Foods");
					string json3 = await response3.Content.ReadAsStringAsync();
					List<Food> data3 = JsonConvert.DeserializeObject<List<Food>>(json3);
					DateTable.ItemsSource = data3;

					break;
				case 4:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response4 = await client.GetAsync($"https://localhost:7041/api/Hotels");
					string json4 = await response4.Content.ReadAsStringAsync();
					List<Hotel> data4 = JsonConvert.DeserializeObject<List<Hotel>>(json4);
					DateTable.ItemsSource = data4;

					break;
				case 5:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response5 = await client.GetAsync($"https://localhost:7041/api/Payments");
					string json5 = await response5.Content.ReadAsStringAsync();
					List<Payment> data5 = JsonConvert.DeserializeObject<List<Payment>>(json5);
					DateTable.ItemsSource = data5;
\
					break;
				case 6:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response6 = await client.GetAsync($"https://localhost:7041/api/Photos");
					string json6 = await response6.Content.ReadAsStringAsync();
					List<Photo> data6 = JsonConvert.DeserializeObject<List<Photo>>(json6);
					DateTable.ItemsSource = data6;

					break;
				case 7:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response7 = await client.GetAsync($"https://localhost:7041/api/PlacesVisiteds");
					string json7 = await response7.Content.ReadAsStringAsync();
					List<PlacesVisited> data7 = JsonConvert.DeserializeObject<List<PlacesVisited>>(json7);
					DateTable.ItemsSource = data7;

					break;
				case 8:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response8 = await client.GetAsync($"https://localhost:7041/api/Reviews");
					string json8 = await response8.Content.ReadAsStringAsync();
					List<Review> data8 = JsonConvert.DeserializeObject<List<Review>>(json8);
					DateTable.ItemsSource = data8;

					break;
				case 9:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response9 = await client.GetAsync($"https://localhost:7041/api/Roles");
					string json9 = await response9.Content.ReadAsStringAsync();
					List<Role> data9 = JsonConvert.DeserializeObject<List<Role>>(json9);
					DateTable.ItemsSource = data9;

					break;
				case 10:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response10 = await client.GetAsync($"https://localhost:7041/api/Rooms");
					string json10 = await response10.Content.ReadAsStringAsync();
					List<Room> data10 = JsonConvert.DeserializeObject<List<Room>>(json10);
					DateTable.ItemsSource = data10;

					break;
				case 11:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response11 = await client.GetAsync($"https://localhost:7041/api/RoomTypes");
					string json11 = await response11.Content.ReadAsStringAsync();
					List<RoomType> data11 = JsonConvert.DeserializeObject<List<RoomType>>(json11);
					DateTable.ItemsSource = data11;

					break;
				case 12:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response12 = await client.GetAsync($"https://localhost:7041/api/Services");
					string json12 = await response12.Content.ReadAsStringAsync();
					List<Service> data12 = JsonConvert.DeserializeObject<List<Service>>(json12);
					DateTable.ItemsSource = data12;

					break;
				case 13:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response13 = await client.GetAsync($"https://localhost:7041/api/Tokens");
					string json13 = await response13.Content.ReadAsStringAsync();
					List<Token> data13 = JsonConvert.DeserializeObject<List<Token>>(json13);
					DateTable.ItemsSource = data13;

					break;
				case 14:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response14 = await client.GetAsync($"https://localhost:7041/api/Tours");
					string json14 = await response14.Content.ReadAsStringAsync();
					List<Tour> data14 = JsonConvert.DeserializeObject<List<Tour>>(json14);
					DateTable.ItemsSource = data14;

					break;
				case 15:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response15 = await client.GetAsync($"https://localhost:7041/api/TouristRoutes");
					string json15 = await response15.Content.ReadAsStringAsync();
					List<TouristRoute> data15 = JsonConvert.DeserializeObject<List<TouristRoute>>(json15);
					DateTable.ItemsSource = data15;

					break;
				case 16:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response16 = await client.GetAsync($"https://localhost:7041/api/Users");
					string json16 = await response16.Content.ReadAsStringAsync();
					List<User> data16 = JsonConvert.DeserializeObject<List<User>>(json16);
					DateTable.ItemsSource = data16;


					break;
			}
		}


		private async void DateTable_Loaded(object sender, RoutedEventArgs e)
		{
			await DateTable_Loaded(count);
		}
		private async void com_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
		{
		count = com.SelectedIndex + 1;
			await DateTable_Loaded(count);
		}


		public async void CreateTable<T>()
		{
			HttpClient client = new HttpClient();
			var selectedItems = DateTable.SelectedItems.Cast<T>().ToList();
			if (selectedItems.Count == 1)
			{
				var data = selectedItems.FirstOrDefault();
				var properties = typeof(T).GetProperties();
				properties[0].SetValue(data, null);
				string jsonString = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
				string ClassName = typeof(T).Name;
				switch (ClassName)
				{
					case ("City"):
						ClassName = "Cities";
						break;
					case ("Country"):
						ClassName = "Countries";
						break;
					case ("Food"):
						ClassName = "Foods";
						break;
					case ("Hotel"):
						ClassName = "Hotels";
						break;
					case ("Payment"):
						ClassName = "Payments";
						break;
					case ("Photo"):
						ClassName = "Photos";
						break;
					case ("PlacesVisited"):
						ClassName = "PlacesVisiteds";
						break;
					case ("Review"):
						ClassName = "Reviews";
						break;
					case ("Role"):
						ClassName = "Roles";
						break;
					case ("Room"):
						ClassName = "Rooms";
						break;
					case ("RoomType"):
						ClassName = "RoomTypes";
						break;
					case ("Service"):
						ClassName = "Services";
						break;
					case ("Token"):
						ClassName = "Tokens";
						break;
					case ("Tour"):
						ClassName = "Tours";
						break;
					case ("TouristRoute"):
						ClassName = "TouristRoutes";
						break;
					case ("User"):
						ClassName = "Users";
						break;
				}
				HttpResponseMessage response = await client.PostAsync($"https://localhost:7041/api/{ClassName}", content);
			}
			else
			{
				MessageBox.Show("Выберите строку");
			}
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			switch (count)
			{
				case 1:
					CreateTable<City>();
					break;
				case 2:
					CreateTable<Country>();
					break;
				case 3:
					CreateTable<Food>();
					break;
				case 4:
					CreateTable<Hotel>();
					break;
				case 5:
					CreateTable<Payment>();
					break;
				case 6:
					CreateTable<Photo>();
					break;
				case 7:
					CreateTable<PlacesVisited>();
					break;
				case 8:
					CreateTable<Review>();
					break;
				case 9:
					CreateTable<Role>();
					break;
				case 10:
					CreateTable<Room>();
					break;
				case 11:
					CreateTable<RoomType>();
					break;
				case 12:
					CreateTable<Service>();
					break;
				case 13:
					CreateTable<Token>();
					break;
				case 14:
					CreateTable<Tour>();
					break;
				case 15:
					CreateTable<TouristRoute>();
					break;
				case 16:
					CreateTable<User>();
					break;
				default:
					break;
			}
			await DateTable_Loaded(count);
		}

		public async Task DeleteTable<T>()
		{
			HttpClient client = new HttpClient();
			var selectedItems = DateTable.SelectedItems.Cast<T>().ToList();
			if (selectedItems.Count == 1)
			{
				var data = selectedItems.FirstOrDefault();
				var properties = typeof(T).GetProperties();
				int id = (int)properties[0].GetValue(data);
				string ClassName = typeof(T).Name;
				switch (ClassName)
				{
					case ("City"):
						ClassName = "Cities";
						break;
					case ("Country"):
						ClassName = "Countries";
						break;
					case ("Food"):
						ClassName = "Foods";
						break;
					case ("Hotel"):
						ClassName = "Hotels";
						break;
					case ("Payment"):
						ClassName = "Payments";
						break;
					case ("Photo"):
						ClassName = "Photos";
						break;
					case ("PlacesVisited"):
						ClassName = "PlacesVisiteds";
						break;
					case ("Review"):
						ClassName = "Reviews";
						break;
					case ("Role"):
						ClassName = "Roles";
						break;
					case ("Room"):
						ClassName = "Rooms";
						break;
					case ("RoomType"):
						ClassName = "RoomTypes";
						break;
					case ("Service"):
						ClassName = "Services";
						break;
					case ("Token"):
						ClassName = "Tokens";
						break;
					case ("Tour"):
						ClassName = "Tours";
						break;
					case ("TouristRoute"):
						ClassName = "TouristRoutes";
						break;
					case ("User"):
						ClassName = "Users";
						break;
				}

				await DateTable_Loaded(count);
				HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7041/api/{ClassName}/{id}");
			}
			else
			{
				MessageBox.Show("Возможна ошибка а может и нет");
			}
		}

		private async void Button_Click_1(object sender, RoutedEventArgs e)
		{
			DeleteTable<City>();
			switch (count)
			{
				case 1:
					DeleteTable<City>();
					break;
				case 2:
					DeleteTable<Country>();
					break;
				case 3:
					DeleteTable<Food>();
					break;
				case 4:
					DeleteTable<Hotel>();
					break;
				case 5:
					DeleteTable<Payment>();
					break;
				case 6:
					DeleteTable<Photo>();
					break;
				case 7:
					DeleteTable<PlacesVisited>();
					break;
				case 8:
					DeleteTable<Review>();
					break;
				case 9:
					DeleteTable<Role>();
					break;
				case 10:
					DeleteTable<Room>();
					break;
				case 11:
					DeleteTable<RoomType>();
					break;
				case 12:
					DeleteTable<Service>();
					break;
				case 13:
					DeleteTable<Token>();
					break;
				case 14:
					DeleteTable<Tour>();
					break;
				case 15:
					DeleteTable<TouristRoute>();
					break;
				case 16:
					DeleteTable<User>();
					break;
				default:
					break;
			}
			await DateTable_Loaded(count);
		}

		public async void izmTable<T>()
		{
			HttpClient client = new HttpClient();
			var selectedItems = DateTable.SelectedItems.Cast<T>().ToList();
			if (selectedItems.Count == 1)
			{

				var data = selectedItems.FirstOrDefault();
				var properties = typeof(T).GetProperties();
				int ID = (int)properties[0].GetValue(data);
				string jsonString = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
				string ClassName = typeof(T).Name;
				switch (ClassName)
				{
					case ("City"):
						ClassName = "Cities";
						break;
					case ("Country"):
						ClassName = "Countries";
						break;
					case ("Food"):
						ClassName = "Foods";
						break;
					case ("Hotel"):
						ClassName = "Hotels";
						break;
					case ("Payment"):
						ClassName = "Payments";
						break;
					case ("Photo"):
						ClassName = "Photos";
						break;
					case ("PlacesVisited"):
						ClassName = "PlacesVisiteds";
						break;
					case ("Review"):
						ClassName = "Reviews";
						break;
					case ("Role"):
						ClassName = "Roles";
						break;
					case ("Room"):
						ClassName = "Rooms";
						break;
					case ("RoomType"):
						ClassName = "RoomTypes";
						break;
					case ("Service"):
						ClassName = "Services";
						break;
					case ("Token"):
						ClassName = "Tokens";
						break;
					case ("Tour"):
						ClassName = "Tours";
						break;
					case ("TouristRoute"):
						ClassName = "TouristRoutes";
						break;
					case ("User"):
						ClassName = "Users";	
						break;
				}
				HttpResponseMessage response = await client.PutAsync($"https://localhost:7041/api/{ClassName}/{ID}", content);
			}
			else
			{
				MessageBox.Show("Выберите строку");
			}
		}

		private async void Button_Click_2(object sender, RoutedEventArgs e)
		{
			switch (count)
			{
				case 1:
					izmTable<City>();
					break;
				case 2:
					izmTable<Country>();
					break;
				case 3:
					izmTable<Food>();
					break;
				case 4:
					izmTable<Hotel>();
					break;
				case 5:
					izmTable<Payment>();
					break;
				case 6:
					izmTable<Photo>();
					break;
				case 7:
					izmTable<PlacesVisited>();
					break;
				case 8:
					izmTable<Review>();
					break;
				case 9:
					izmTable<Role>();
					break;
				case 10:
					izmTable<Room>();
					break;
				case 11:
					izmTable<RoomType>();
					break;
				case 12:
					izmTable<Service>();
					break;
				case 13:
					izmTable<Token>();
					break;
				case 14:
					izmTable<Tour>();
					break;
				case 15:
					izmTable<TouristRoute>();
					break;
				case 16:
					izmTable<User>();
					break;
				default:
					break;
			}
			await DateTable_Loaded(count);
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			// строка подключения к локальной базе данных
			string connectionString = @"Data Source=LAPTOP-MPQU2K2E\\BD;Initial Catalog=Hotels;Integrated Security=True;TrustServerCertificate=True";

			// создание объекта подключения
			SqlConnection connection = new SqlConnection(connectionString);

			// Создание диалога для выбора пути сохранения резервной копии
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "backup (*.bak)|*.bak";
			saveFileDialog.FileName = "Backup_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".bak";
			if (saveFileDialog.ShowDialog() == true)
			{
				// Обновление backupCommandText с учетом выбранного пути сохранения
				string backupCommandText = $"BACKUP DATABASE [Praktdesct] TO DISK='{saveFileDialog.FileName}'";
				SqlCommand backupCommand = new SqlCommand(backupCommandText, connection);

				try
				{
					// открытие соединения
					connection.Open();

					// выполнение команды резервного копирования
					backupCommand.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"An error occurred: {ex.Message}");
				}
				finally
				{
					// закрытие соединения
					connection.Close();
				}
			}
		}

		public void ExportToExcel<T>(List<T> data)
		{
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

			using (var package = new ExcelPackage())
			{
				var typeName = typeof(T).Name;

				var worksheet = package.Workbook.Worksheets.Add(typeName);

				var properties = typeof(T).GetProperties();
                for (int j = 0; j < properties.Length; j++)
				{
					worksheet.Cells[1, j + 1].Value = properties[j].Name;
				}

				for (int i = 0; i < data.Count; i++)
				{
					for (int j = 0; j < properties.Length; j++)
					{
						var value = properties[j].GetValue(data[i], null);
						worksheet.Cells[i + 2, j + 1].Value = value;
					}
				}

				// Получение пути и имени файла для сохранения
				var saveFileDialog = new SaveFileDialog
				{
					Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
					FileName = $"{typeName} {DateTime.Now:yyyyMMddHHmmss}" // Использование имени класса и времени сохранения в качестве базового имени файла
				};

				if (saveFileDialog.ShowDialog() == true && !string.IsNullOrEmpty(saveFileDialog.FileName))
				{
					var filePath = saveFileDialog.FileName;

					// Сохранение файла
					package.SaveAs(new FileInfo(filePath));
				}
			}
		}

		public List<T> GetDataFromGrid<T>()
		{
			List<T> itemsSourceList = new List<T>();

			if (DateTable.ItemsSource is IEnumerable<T> itemsSource)
			{
				itemsSourceList = itemsSource.ToList();
			}
			else if (DateTable.ItemsSource is IEnumerable itemsSourceNonGeneric)
			{
				foreach (var item in itemsSourceNonGeneric)
				{
					if (item is T tItem)
					{
						itemsSourceList.Add(tItem);
					}
				}
			}
			return itemsSourceList;
		}

		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			switch (count)
			{
				case 1:
					List<City> list1 = GetDataFromGrid<City>();
					ExportToExcel<City>(list1);
					break;
				case 2:
					List<Country> list2 = GetDataFromGrid<Country>();
					ExportToExcel<Country>(list2);
					break;
				case 3:
					List<Food> list3 = GetDataFromGrid<Food>();
					ExportToExcel<Food>(list3);
					break;
				case 4:
					List<Hotel> list4 = GetDataFromGrid<Hotel>();
					ExportToExcel<Hotel>(list4);
					break;
				case 5:
					List<Payment> list5 = GetDataFromGrid<Payment>();
					ExportToExcel<Payment>(list5);
					break;
				case 6:
					List<Photo> list6 = GetDataFromGrid<Photo>();
					ExportToExcel<Photo>(list6);
					break;
				case 7:
					List<PlacesVisited> list7 = GetDataFromGrid<PlacesVisited>();
					ExportToExcel<PlacesVisited>(list7);
					break;
				case 8:
					List<Review> list8 = GetDataFromGrid<Review>();
					ExportToExcel<Review>(list8);
					break;
				case 9:
					List<Role> list9 = GetDataFromGrid<Role>();
					ExportToExcel<Role>(list9);
					break;
				case 10:
					List<Room> list10 = GetDataFromGrid<Room>();
					ExportToExcel<Room>(list10);
					break;
				case 11:
					List<RoomType> list11 = GetDataFromGrid<RoomType>();
					ExportToExcel<RoomType>(list11);
					break;
				case 12:
					List<Service> list12 = GetDataFromGrid<Service>();
					ExportToExcel<Service>(list12);
					break;
				case 13:
					List<Token> list13 = GetDataFromGrid<Token>();
					ExportToExcel<Token>(list13);
					break;
				case 14:
					List<Tour> list14 = GetDataFromGrid<Tour>();
					ExportToExcel<Tour>(list14);
					break;
				case 15:
					List<TouristRoute> list15 = GetDataFromGrid<TouristRoute>();
					ExportToExcel<TouristRoute>(list15);
					break;
				case 16:
					List<User> list16 = GetDataFromGrid<User>();
					ExportToExcel<User>(list16);
					break;
				default:
					break;
			}
		}

		private void Button_Click_5(object sender, RoutedEventArgs e)
		{
			ClearPlot(PlotGraph);
			List<Food> data = GetDataFromGrid<Food>(DateTable);
			PlotData<Food>(data, PlotGraph);
		}

		public void PlotData<T>(List<T> data, ScottPlot.WpfPlot plotControl)
		{
			double[] xValues;
			double[] yValues;


			xValues = data.Select(item => Convert.ToDouble(item.GetType().GetProperty("IdFood").GetValue(item))).ToArray();
			yValues = data.Select(item => Convert.ToDouble(item.GetType().GetProperty("PriceFood").GetValue(item))).ToArray();
			plotControl.Plot.XLabel("Колличество");
			plotControl.Plot.YLabel("Цена");
			plotControl.Plot.Title("График данных");

			plotControl.Plot.AddScatter(xValues, yValues);
			plotControl.Render();
		}

		public List<T> GetDataFromGrid<T>(DataGrid name)
		{
			List<T> itemsSourceList = new List<T>();

			if (name.ItemsSource is IEnumerable<T> itemsSource)
			{
				itemsSourceList = itemsSource.ToList();
			}
			else if (name.ItemsSource is IEnumerable itemsSourceNonGeneric)
			{
				foreach (var item in itemsSourceNonGeneric)
				{
					if (item is T tItem)
					{
						itemsSourceList.Add(tItem);
					}
				}
			}
			return itemsSourceList;
		}

		public void ClearPlot(ScottPlot.WpfPlot plotControl)
		{
			plotControl.Reset();
		}

		private void Button_Click_6(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			Close();
		}

		private void Button_Click_7(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}