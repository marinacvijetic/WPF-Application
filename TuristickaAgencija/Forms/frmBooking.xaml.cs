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
    /// Interaction logic for frmBooking.xaml
    /// </summary>
    public partial class frmBooking : Window
    {
        Connection kon = new Connection();
        SqlConnection konekcija = new SqlConnection();
        bool update;
        DataRowView auxiliaryRow;
        public frmBooking(bool update, DataRowView auxiliaryRow)
        {
            InitializeComponent();
            cbxEmployee.Focus();
            this.update = update;
            this.auxiliaryRow = auxiliaryRow;
            konekcija = kon.CreatingConnection();

            try
            {
                konekcija.Open();
                //Employee
                string returnEmployee = @"select EmployeeID, NameE + ' ' + SurnameE as Employee from tblEmployee;";
                DataTable dtEmployee = new DataTable();
                dtEmployee.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daEmployee = new SqlDataAdapter(returnEmployee, konekcija);
                daEmployee.Fill(dtEmployee);
                cbxEmployee.ItemsSource = dtEmployee.DefaultView;
                dtEmployee.Dispose();
                daEmployee.Dispose();
                //Customer
                string returnCustomer = @"select CustomerID, NameC + ' ' + SurnameC as Customer from tblCustomer;";
                DataTable dtCustomer = new DataTable();
                dtCustomer.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daCustomer = new SqlDataAdapter(returnCustomer, konekcija);
                daCustomer.Fill(dtCustomer);
                cbxCustomer.ItemsSource = dtCustomer.DefaultView;
                dtCustomer.Dispose();
                daCustomer.Dispose();
                //Hotel
                string returnHotel = @"select HotelID, Name as Hotel from tblHotel;";
                DataTable dtHotel = new DataTable();
                dtHotel.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daHotel = new SqlDataAdapter(returnHotel, konekcija);
                daHotel.Fill(dtHotel);
                cbxHotel.ItemsSource = dtHotel.DefaultView;
                dtHotel.Dispose();
                daHotel.Dispose();
                //Transport 
                string returnTransport = @"select TransportID, Destination + ' - ' + TypeName as 'Type of transport' from tblTransport 
                                           join tblTicket on tblTransport.TicketID=tblTicket.TicketID
                                           join tblType on tblTicket.TypeID=tblType.TypeID;";
                SqlDataAdapter daTransport = new SqlDataAdapter(returnTransport, konekcija);
                DataTable dtTransport = new DataTable();
                cbxTransport.ItemsSource = dtTransport.DefaultView;
                daTransport.Fill(dtTransport);


                dtTransport.Dispose();
                daTransport.Dispose();
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
        public frmBooking()
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            cbxEmployee.Focus();

            try
            {
                konekcija.Open();
                //Employee
                string returnEmployee = @"select EmployeeID, NameE + ' ' + SurnameE as Employee from tblEmployee;";
                DataTable dtEmployee = new DataTable();
                dtEmployee.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daEmployee = new SqlDataAdapter(returnEmployee, konekcija);
                daEmployee.Fill(dtEmployee);
                cbxEmployee.ItemsSource = dtEmployee.DefaultView;
                dtEmployee.Dispose();
                daEmployee.Dispose();
                //Customer
                string returnCustomer = @"select CustomerID, NameC + ' ' + SurnameC as Customer from tblCustomer;";
                DataTable dtCustomer = new DataTable();
                dtCustomer.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daCustomer = new SqlDataAdapter(returnCustomer, konekcija);
                daCustomer.Fill(dtCustomer);
                cbxCustomer.ItemsSource = dtCustomer.DefaultView;
                dtCustomer.Dispose();
                daCustomer.Dispose();
                //Hotel
                string returnHotel = @"select HotelID, Name as Hotel from tblHotel;";
                DataTable dtHotel = new DataTable();
                dtHotel.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daHotel = new SqlDataAdapter(returnHotel, konekcija);
                daHotel.Fill(dtHotel);
                cbxHotel.ItemsSource = dtHotel.DefaultView;
                dtHotel.Dispose();
                daHotel.Dispose();
                //Transport 
                string returnTransport = @"select TransportID, Destination + ' - ' + TypeName as 'Type of transport' from tblTransport join tblTicket on tblTransport.TicketID=tblTicket.TicketID
                                           join tblType on tblTicket.TypeID=tblType.TypeID;";
                SqlDataAdapter daTransport = new SqlDataAdapter(returnTransport, konekcija);
                DataTable dtTransport= new DataTable();
                cbxTransport.ItemsSource = dtTransport.DefaultView;
                daTransport.Fill(dtTransport);
                

                dtTransport.Dispose();
                daTransport.Dispose();
            }
            catch(SqlException)
            {
                MessageBox.Show("Drop-down lists are not filled.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if(konekcija != null)
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
                DateTime date = (DateTime)dpDatumRez.SelectedDate;
                string datumRez = date.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture);
                cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = cbxEmployee.SelectedValue;
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = cbxCustomer.SelectedValue;
                cmd.Parameters.Add(@"NumberOfPassengers", SqlDbType.Int).Value = txtNumberOfPassengers.Text;
                cmd.Parameters.Add(@"HotelID", SqlDbType.Int).Value = cbxHotel.SelectedValue;
                cmd.Parameters.Add(@"ReservationDate", SqlDbType.DateTime).Value = datumRez;
                cmd.Parameters.Add(@"TransportID", SqlDbType.Int).Value = cbxTransport.SelectedValue;
                cmd.Parameters.Add(@"TotalPrice", SqlDbType.Money).Value = txtTotalPrice.Text;

                if(this.update)
                {
                    DataRowView row = this.auxiliaryRow;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update tblBooking set EmployeeID=@EmployeeID, CustomerID=@CustomerID, NumberOfPassengers=@NumberOfPassengers,
                                      HotelID=@HotelID, ReservationDate=@ReservationDate, TransportID=@TransportID, TotalPrice=@TotalPrice where ReservationID=@id";
                    this.auxiliaryRow = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblBooking (EmployeeID, CustomerID, NumberOfPassengers, HotelID, ReservationDate, TransportID, TotalPrice)
                                    values(@EmployeeID, @CustomerID, @NumberOfPassengers, @HotelID, @ReservationDate, @TransportID, @TotalPrice);";
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
                if (konekcija != null)
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
