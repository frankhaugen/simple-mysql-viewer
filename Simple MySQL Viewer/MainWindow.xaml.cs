using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows;

namespace Simple_MySQL_Viewer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private string SettingsFile = Directory.GetCurrentDirectory() + "\\login.secret";

		public MainWindow()
		{
			InitializeComponent();

			// Check if file with settings exist and fill in MySQL information before running
			// Line ending separated in this sequence: Server, Database, Username, Password
			if (File.Exists(SettingsFile))
			{
				try
				{
					string[] setting = File.ReadAllLines(SettingsFile);

					ServerField.Text = setting[0];
					DatabaseField.Text = setting[1];
					TableField.Text = setting[2];
					UsernameField.Text = setting[3];
					PasswordField.Text = setting[4];
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message);
				}
			}
		}

		private void SubmitButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder()
				{
					Server = ServerField.Text,
					Database = DatabaseField.Text,
					UserID = UsernameField.Text,
					Password = PasswordField.Text,
				};

				MySqlConnection connection = new MySqlConnection(connectionStringBuilder.ToString());

				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();

				string sql = "SELECT * FROM " + TableField.Text;

				mySqlDataAdapter.SelectCommand = new MySqlCommand(sql, connection);

				DataTable dataTable = new DataTable();

				mySqlDataAdapter.Fill(dataTable);

				OutputGrid.DataContext = dataTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
	}
}
