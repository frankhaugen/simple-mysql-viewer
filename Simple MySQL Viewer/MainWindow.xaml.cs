using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace Simple_MySQL_Viewer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void SubmitButton_Click(object sender, RoutedEventArgs e)
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
	}
}
