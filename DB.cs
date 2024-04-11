using System;
using System.Data;
using System.Data.SqlClient;

namespace kursach_diplom_desctop
{
	class DB
	{
		private static readonly string connectionString = GetConnectionString();
		private static readonly string appName = "Администратор";

		private static string GetConnectionString()
		{
			return "Data Source=SHADOURAZE\\SQLEXPRESS;Initial Catalog=kurcach_diplom;Integrated Security=True;";
		}

		// Метод выполнения SQL-запросов
		public DataTable ExecuteQuery(string query)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					try
					{
						connection.Open();
						DataTable resultTable = new DataTable();
						resultTable.Load(command.ExecuteReader());
						return resultTable;
					}
					catch (SqlException ex)
					{
						Console.WriteLine($"Ошибка при выполнении SQL-запроса: {ex.Message}");
						return null;
					}
				}
			}
		}

		public void UpdatePassword(string userId, string newPassword)
		{
			string query = "UPDATE Users SET Password = @NewPassword WHERE UserId = @UserId";
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@NewPassword", newPassword);
					command.Parameters.AddWithValue("@UserId", userId);

					try
					{
						connection.Open();
						command.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						Console.WriteLine($"Ошибка при выполнении SQL-запроса: {ex.Message}");
					}
				}
			}
		}
	}
}
