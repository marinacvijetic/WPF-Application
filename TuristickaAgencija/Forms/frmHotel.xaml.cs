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
    /// Interaction logic for frmHotel.xaml
    /// </summary>
    public partial class frmHotel : Window
    {
        Connection kon = new Connection();
        SqlConnection konekcija = new SqlConnection();

        bool update;
        DataRowView auxiliaryRow;

        public frmHotel(bool update, DataRowView auxiliaryRow)
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            txtName.Focus();
            this.update = update;
            this.auxiliaryRow = auxiliaryRow;
            try
            {
                string returnDestination = @"select DestinationID, City as Destination from tblDestination;";
                DataTable dtDestination = new DataTable();
                dtDestination.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daDestination = new SqlDataAdapter(returnDestination, konekcija);
                daDestination.Fill(dtDestination);
                cbxDestination.ItemsSource = dtDestination.DefaultView;
                dtDestination.Dispose();
                daDestination.Dispose();
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
        public frmHotel()
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            txtName.Focus();

            try
            {
                string returnDestination = @"select DestinationID, City as Destination from tblDestination;";
                DataTable dtDestination = new DataTable();
                dtDestination.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daDestination = new SqlDataAdapter(returnDestination, konekcija);
                daDestination.Fill(dtDestination);
                cbxDestination.ItemsSource = dtDestination.DefaultView;
                dtDestination.Dispose();
                daDestination.Dispose();
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

                cmd.Parameters.Add(@"Name", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add(@"Adress", SqlDbType.NVarChar).Value = txtAdress.Text;
                cmd.Parameters.Add(@"RoomNumber", SqlDbType.NVarChar).Value = txtRoomNumber.Text;
                cmd.Parameters.Add(@"Contact", SqlDbType.NVarChar).Value = txtContact.Text;
                cmd.Parameters.Add(@"PricePerNight", SqlDbType.Money).Value = txtPrice.Text;
                cmd.Parameters.Add(@"DestinationID", SqlDbType.Int).Value = cbxDestination.SelectedValue;

                if(this.update)
                {
                    DataRowView row = this.auxiliaryRow;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"Update tblHotel 
                                       set Name=@Name, Adress=@Adress, RoomNumber=@RoomNumber, Contact=@Contact, PricePerNight=@PricePerNight, DestinationID=@DestinationID
                                        where HotelID=@id";
                    this.auxiliaryRow = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblHotel(Name, Adress, RoomNumber, Contact, PricePerNight, DestinationID)
                                    values(@Name, @Adress, @RoomNumber, @Contact, @PricePerNight, @DestinationID);";
                }
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch(SqlException)
            {
                MessageBox.Show("Entered value is not valid.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
