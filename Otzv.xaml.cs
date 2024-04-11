using DocumentFormat.OpenXml.Drawing.Charts;
using kursach_diplom_desctop.Models;
using Newtonsoft.Json;
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
	/// Логика взаимодействия для Otzv.xaml
	/// </summary>
	public partial class Otzv : Window
	{
		public Otzv()
		{
			InitializeComponent();
		}
		public int count = 1;
		public async Task DateTable_Loaded(int currentTable)
		{
			HttpClient client = new HttpClient();
			switch (currentTable)
			{				
				case 1:
					DateTable.ItemsSource = new List<Order>();
					HttpResponseMessage response1 = await client.GetAsync($"https://localhost:7041/api/Reviews");
					string json1 = await response1.Content.ReadAsStringAsync();
					List<Review> data1 = JsonConvert.DeserializeObject<List<Review>>(json1);
					DateTable.ItemsSource = data1;
					break;
			}
		}


		private async void DateTable_Loaded(object sender, RoutedEventArgs e)
		{
			await DateTable_Loaded(count);
		}
	}
}