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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace TuristickaAgencija.Forms
{
    /// <summary>
    /// Interaction logic for frmTicket.xaml
    /// </summary>
    public partial class frmTicket : Window
    {
        Connection kon = new Connection();
        SqlConnection konekcija = new SqlConnection();

        bool update;
        DataRowView auxiliaryRow;

        public frmTicket(bool update, DataRowView auxiliaryRow)
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            cbxType.Focus();
            this.update = update;
            this.auxiliaryRow = auxiliaryRow;
            try
            {
                konekcija.Open();
                //Type 
                string returnType = @"select TypeID, TypeName as 'Type of transport' from tblType";
                DataTable dtType = new DataTable();
                dtType.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daType = new SqlDataAdapter(returnType, konekcija);
                daType.Fill(dtType);
                cbxType.ItemsSource = dtType.DefaultView;
                dtType.Dispose();
                daType.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Drop-down lists are not filled.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

        public frmTicket()
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            cbxType.Focus();

            try
            {
                konekcija.Open();
                //Type 
                string returnType = @"select TypeID, TypeName as 'Type of transport' from tblType";
                DataTable dtType = new DataTable();
                dtType.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daType = new SqlDataAdapter(returnType, konekcija);
                daType.Fill(dtType);
                cbxType.ItemsSource = dtType.DefaultView;
                dtType.Dispose();
                daType.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Drop-down lists are not filled.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                DateTime departure = (DateTime)dpDeparture.SelectedDate;
                string polazak = departure.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture); 
                DateTime arrival = (DateTime)dpArrival.SelectedDate;
                string dolazak = arrival.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture);
                cmd.Parameters.Add(@"TypeID", SqlDbType.Int).Value = cbxType.SelectedValue;
                cmd.Parameters.Add(@"Destination", SqlDbType.NVarChar).Value = txtDestination.Text;
                cmd.Parameters.Add(@"SeatNumber", SqlDbType.NVarChar).Value = txtSeatNumber.Text;
                cmd.Parameters.Add(@"Departure", SqlDbType.DateTime).Value = polazak;
                cmd.Parameters.Add(@"Arrival", SqlDbType.DateTime).Value = dolazak;
                cmd.Parameters.Add(@"TicketPrice", SqlDbType.Money).Value = txtTicketPrice.Text;

                if(this.update)
                {
                    DataRowView row = this.auxiliaryRow;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update tblTicket set TypeID=@TypeID, Destination=@Destination, SeatNumber=@SeatNumber, Departure=@Departure, Arrival=@Arrival, TicketPrice=@TicketPrice
                                    where TicketID=@id";
                    this.auxiliaryRow = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblTicket(TypeID, Destination, SeatNumber, Departure, Arrival, TicketPrice)
                                    values(@TypeID, @Destination, @SeatNumber, @Departure, @Arrival, @TicketPrice);";
                }
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
   
            }
            catch(SqlException)
            {
                MessageBox.Show("Entered value is not valid. Ensure that you have selected the required values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
               
            }
            finally
            {
                if(konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
