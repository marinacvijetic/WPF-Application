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
    /// Interaction logic for frmTransport.xaml
    /// </summary>
    public partial class frmTransport : Window
    {
        Connection kon = new Connection();
        SqlConnection konekcija = new SqlConnection();
        bool update;
        DataRowView auxiliaryRow;

        public frmTransport(bool update, DataRowView auxiliaryRow)
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            cbxTicket.Focus();
            this.update = update;
            this.auxiliaryRow = auxiliaryRow;
            try
            {
                
                konekcija.Open();

                var returnTicket = @"select TicketID, Destination + ' - ' + SeatNumber as 'Ticket - Seat number'  from tblTicket;";
                DataTable dtTicket = new DataTable();
                dtTicket.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daTicket = new SqlDataAdapter(returnTicket, konekcija);
                daTicket.Fill(dtTicket);
                cbxTicket.ItemsSource = dtTicket.DefaultView;
                dtTicket.Dispose();
                daTicket.Dispose();
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

        public frmTransport()
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            cbxTicket.Focus();
            

            try
            {
                
                konekcija.Open();

                var returnTicket = @"select TicketID, Destination + ' - ' + SeatNumber as 'Ticket - Seat number'  from tblTicket;";
                DataTable dtTicket = new DataTable();
                dtTicket.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daTicket = new SqlDataAdapter(returnTicket, konekcija);
                daTicket.Fill(dtTicket);
                cbxTicket.ItemsSource = dtTicket.DefaultView;
                dtTicket.Dispose();
                daTicket.Dispose();
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
                /*cmd.Parameters.Add(@"TypeID", SqlDbType.Int).Value = cbxType.SelectedValue;*/
                cmd.Parameters.Add("@TicketID", SqlDbType.Int).Value = cbxTicket.SelectedValue;
                if(this.update)
                {
                    DataRowView row = this.auxiliaryRow;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"Update tblTransport
                                        set TicketID=@TicketID where TransportID=@id";
                } 
                else
                {
                    cmd.CommandText = @"insert into tblTransport(TicketID) 
                                     values(@TicketID);";
                }
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch(SqlException)
            {
                MessageBox.Show("Entered value is not valid. Make sure you check all the boxes.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

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
