using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace WpfApp4
{

    public partial class MainWindow : Window
    {
        string connectionString = @"Data Source = DESKTOP-RJDUG5M; Initial Catalog = adonetdb; Trusted_Connection=True";

        string sql = "SELECT * FROM Users";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Visible;
            but2_Copy1.Visibility = Visibility.Visible;
            text1.Visibility = Visibility.Visible;
            text2.Visibility = Visibility.Visible;
            text3.Visibility = Visibility.Visible;
        }

        private void but3_Click(object sender, RoutedEventArgs e)
        {
            but1.Visibility = Visibility.Visible;
            but2.Visibility = Visibility.Visible;
            but3.Visibility = Visibility.Hidden;
            but2_Copy1.Visibility = Visibility.Hidden;
            text1.Visibility = Visibility.Hidden;
            text2.Visibility = Visibility.Hidden;
            text3.Visibility = Visibility.Hidden;
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            but1.Visibility = Visibility.Hidden;
            but2.Visibility = Visibility.Hidden;
            but3.Visibility = Visibility.Visible;
            but2_Copy1.Visibility = Visibility.Visible;
            text1.Visibility = Visibility.Visible;
            text2.Visibility = Visibility.Visible;
            text3.Visibility = Visibility.Visible;
            

            
        }

        private void text1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            text1.Text = string.Empty;
        }


        private void text3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            text3.Text = string.Empty;
        }

        private void text2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            text2.Text = string.Empty;
        }

        private async void but2_Copy1_Click(object sender, RoutedEventArgs e)
        {
            int n;
            string str;
            string edit;
            n=Convert.ToInt32(text1.Text);
            str = Convert.ToString(text2.Text);
            edit = Convert.ToString(text3.Text);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();

                adapter.Fill(ds);


                DataTable dt = ds.Tables[0];

                DataRow dr = dt.NewRow();
                DataRow dr2 = dt.NewRow();
                dt.Rows[n][str] = edit;
                adapter.Update(ds);
                adapter.Fill(ds);
            }
        }
        private async void but4_Click(object sender, RoutedEventArgs e)
        {
            int n;
            string str;
            string edit;
            n = Convert.ToInt32(text1.Text);
            str = Convert.ToString(text2.Text);
            edit = Convert.ToString(text3.Text);
            string sqlExpression = $"UPDATE Users SET {str} = {edit}, WHERE id = {n}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
