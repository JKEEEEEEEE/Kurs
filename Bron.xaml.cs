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
using System.Security.Policy;
using System.Windows.Media.Imaging;

namespace kursach_diplom_desctop
{
	/// <summary>
	/// Логика взаимодействия для Bron.xaml
	/// </summary>
	public partial class Bron : Window
	{
		private int Id;
		private decimal prize;
		

		public Bron(int Id, decimal prize)
		{
			this.Id = Id;
			this.prize = prize;
			InitializeComponent();
			decimal itog = prize;
			itogoviy(itog);
			vyv();
		}
		private void vyv()
		{
			IEnumerable<Hotel> hotels = ExecuteSql("SELECT [Id_Hotel], [Name_Hotel], [Category_Hotel], [Link_Photo], [Name_Services], [Price_Services], [Price_Food], [Dish_Food], [Description_Food], [Name_Room_Type], [Price_Room_Type] FROM [dbo].[Hotel] inner JOIN [dbo].[Photo] ON [Photo_Id] = [Id_Photo] inner JOIN [dbo].[Services] ON [Services_Id] = [Id_Services] inner JOIN [dbo].[Food] ON [Food_Id] = [Id_Food] inner JOIN [dbo].[Room] ON [Room_Id] = [Id_Room] inner JOIN [dbo].[Room_Type] ON [Room_Type_Id] = [Id_Room_Type];");

			foreach (Hotel hotel in hotels)
			{
				itogwe(hotel.Link_Photo);
			}
		}
		static IEnumerable<Hotel> ExecuteSql(string sql)
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


						Hotel technics = new Hotel()
						{
							Link_Photo = Path.Combine(dir + (string)read["Link_Photo"] + ".jpg"),
							
						};
						yield return technics;
					}
				}
			}
			
		}
		private void itogoviy(decimal itog)
		{
			
			itogc.Text = itog.ToString();
		}
		public class Hotel
		{
			public string Link_Photo { get; set; }
		}
		public void itogwe(string linkPhoto)
		{
			
			string put;

			// Если linkPhoto уже содержит полный путь, используем его
			if (Path.IsPathRooted(linkPhoto))
			{
				put = linkPhoto;
			}
			else
			{
				// Иначе формируем полный путь на основе текущего рабочего каталога и имени файла
				put = Path.Combine("C:\\Image\\" + linkPhoto + ".jpg");
			}

			Imag.Source = new BitmapImage(new Uri(put));
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Sotrudnik sotrudnik = new Sotrudnik();
			sotrudnik.Show();
			Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Otzv otzv = new Otzv();
			otzv.Show();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			decimal qwe = Convert.ToDecimal(itogc.Text);
			Eda eda = new Eda(qwe);
			eda.Show();
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			decimal qwe = Convert.ToDecimal(itogc.Text);
			nomer nomer = new nomer(qwe);
			nomer.Show();
		}

		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			decimal qwe = Convert.ToDecimal(itogc.Text);
			Yslyga Yslyga = new Yslyga(qwe);
			Yslyga.Show();
		}

		private void Button_Click_5(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Данный тур забронирован, к оплате: " + itogc.Text + "");
		}
	}
}
