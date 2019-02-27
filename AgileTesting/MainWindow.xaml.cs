using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            string cmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmdString = "SELECT lName, fName FROM Guests";
                SqlCommand cmd = new SqlCommand(cmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Guest");
                sda.Fill(dt);
                grdCalendar.ItemsSource = dt.DefaultView;
            }
        }

        private void AddNewGuestBtn_Click(object sender, RoutedEventArgs e)
        {
            DataTable guest = new DataTable();

            DataRow newRow = guest.NewRow();

            guest.Rows.Add(newRow);
        }
    }
}
