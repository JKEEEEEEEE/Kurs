using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace kursach_diplom_desctop
{
	/// <summary>
	/// Логика взаимодействия для Yslyga.xaml
	/// </summary>
	public partial class Yslyga : Window
	{
		private decimal qwe;
		public Yslyga(decimal qwe)
		{
			this.qwe = qwe;
			InitializeComponent();
			FillComboBox();
		}
		private void FillComboBox()
		{
			string connectionString = "Data Source=SHADOURAZE\\SQLEXPRESS;Initial Catalog=kurcach_diplom;Integrated Security=True;";
			try
			{


				string query = "SELECT Name_Services FROM Services";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								pit.Items.Add(reader["Name_Services"].ToString());
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
				string query = "SELECT Price_Services FROM Services";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								price.Items.Add(reader["Price_Services"].ToString());
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
		private void pit_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			price.SelectedIndex = pit.SelectedIndex;
			decimal cena = Convert.ToDecimal(price.SelectedValue);
			decimal itog = cena + qwe;
			int a = 1;
			Bron bron = new Bron(a, itog);
			bron.Show();
			Close();

		}
	}
}