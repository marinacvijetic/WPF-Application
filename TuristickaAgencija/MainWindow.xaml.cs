using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using TuristickaAgencija.Forms;

namespace TuristickaAgencija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Connection kon = new Connection(); //klasa kojoj sam prosledila atribute pristupa mojoj bazi podataka
        SqlConnection konekcija = new SqlConnection(); //ugradjena klasa, kreira instancu konekcije u aplikaciji po osnovu prosledjenih atributa
        string loadedTable;
        bool update;
        DataRowView auxiliaryRow;

        #region Select naredbe
        //static - jer ne mora da ima objekat da bi se instancirala
        static string bookingSelect = @"select ReservationID as ID, NameE + ' ' + SurnameE as 'Employee', NameC + ' ' + SurnameC as 'Customer', NumberOfPassengers as 'Number of passengers',
                                        Name as 'Hotel name', ReservationDate as 'Reservation date', TypeName as 'Transport type', TotalPrice as 'Total price' from tblBooking join
                                        tblEmployee on tblBooking.EmployeeID=tblEmployee.EmployeeID
                                        join tblCustomer on tblBooking.CustomerID=tblCustomer.CustomerID
                                        join tblHotel on tblBooking.HotelID=tblHotel.HotelID
                                        join tblTransport on tblBooking.TransportID=tblTransport.TransportID
                                        join tblTicket on tblTransport.TicketID=tblTicket.TicketID
                                        join tblType on tblTicket.TypeID=tblType.TypeID;";

        static string hotelsSelect = @"select HotelID as ID, Name, Adress, RoomNumber as 'Room Number', Contact, PricePerNight as 'Price Per Night', State + ',' + City as Destination
                                     from tblHotel join tblDestination on tblHotel.DestinationID=tblDestination.DestinationID;";
        static string customersSelect = @"select CustomerID as ID, NameC as 'Name', SurnameC as 'Surname', JMBG as 'Identification number', City, Adress, Contact,
                                        CardNumber as 'Card number' from tblCustomer;";
        static string ticketsSelect = @"select TicketID as ID, TypeName as 'Type of transport', Destination, SeatNumber as 'Seat Number',
                                        Departure, Arrival, TicketPrice as 'Ticket price' from tblTicket 
                                         join tblType on tblTicket.TypeID=tblType.TypeID;";
        static string employeesSelect = @"select EmployeeID as ID, NameOfUnit as 'Organisation unit', NameE as 'Name', SurnameE as 'Surname',
                                            IdentificationNumber as 'Identification number', 
                                         City, Adress, PhoneNumber as 'Phone number', Email as 'E-mail' from tblEmployee 
                                            join tblOrganisationUnit on tblEmployee.OUID=tblOrganisationUnit.OUID;";
        static string transportSelect = @"select TransportID as ID, Destination, Departure, Arrival, TypeName as 'Type name' from tblTransport 
                                                join tblTicket on tblTransport.TicketID=tblTicket.TicketID
                                                   join tblType on tblTicket.TypeID=tblType.TypeID;";
        static string organisationUnitsSelect = @"select OUID as ID, NameOfUnit as 'Name of unit' from tblOrganisationUnit;";
        static string destinationsSelect = @"select DestinationID as ID, State, City from tblDestination;";
        static string typesOfTransportSelecet = @"select TypeID as ID, TypeName as 'Type of transport' from tblType;";

        #endregion
        #region Select uslovi 
        string selectUslovBooking = @"select *  from tblBooking where ReservationID=";
        string selectUslovHotel = @"select * from tblHotel where HotelID=";
        string selectUslovCustomer = @"select * from tblCustomer where CustomerID=";
        string selectUslovTicket = @"select * from tblTicket where TicketID=";
        string selectUslovEmployee = @"select * from tblEmployee where EmployeeID=";
        string selectUslovTransport = @"select * from tblTransport where TransportID=";
        string selectUslovOrganisationUnit = @"select * from tblOrganisationUnit where OUID=";
        string selectUslovDestination = @"select * from tblDestination where DestinationID=";
        string selectUslovType = @"select * from tblType where TypeID=";
        #endregion

        #region Delete upit
        string bookingDelete = @"delete from tblBooking where ReservationID=";
        string hotelDelete = @"delete from tblHotel where HotelId=";
        string customerDelete = @"delete from tblCustomer where CustomerID=";
        string ticketDelete = @"delete from tblTicket where TicketID=";
        string employeeDelete = @"delete from tblEmployee where EmployeeID=";
        string transportDelete = @"delete from tblTransport where TransportID=";
        string organisationUnitDelete = @"delete from tblOrganisationUnit where OUID=";
        string destinationDelete = @"delete from tblDestination where DestinationID=";
        string typeDelete = @"delete from tblType where TypeID=";
        #endregion


        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            LoadData(dataGridCentral, bookingSelect);
        }

        public void LoadData(DataGrid grid, string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dt = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(dt);
                if (grid != null)
                {
                    grid.ItemsSource = dt.DefaultView;
                }

                loadedTable = selectUpit;
                dt.Dispose();
                dataAdapter.Dispose();

            }
            catch (SqlException)
            {
                MessageBox.Show("Error loading data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            LoadData(dataGridCentral, bookingSelect);
        }

        private void btnHotels_Click(object sender, RoutedEventArgs e)
        {
            LoadData(dataGridCentral, hotelsSelect);

        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            LoadData(dataGridCentral, customersSelect);
        }

        private void btnTickets_Click(object sender, RoutedEventArgs e)
        {
            LoadData(dataGridCentral, ticketsSelect);
        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            LoadData(dataGridCentral, employeesSelect);
        }
        private void btnTransport_Click(object sender, RoutedEventArgs e)
        {
            LoadData(dataGridCentral, transportSelect);
        }

        private void btnTypes_Click(object sender, RoutedEventArgs e)
        {
            LoadData(dataGridCentral, typesOfTransportSelecet);
        }

        private void btnOU_Click(object sender, RoutedEventArgs e)
        {
            LoadData(dataGridCentral, organisationUnitsSelect);
        }

        private void btnDestinations_Click(object sender, RoutedEventArgs e)
        {
            LoadData(dataGridCentral, destinationsSelect);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Window window;
            if (loadedTable.Equals(bookingSelect, StringComparison.Ordinal))
            {
                window = new frmBooking();
                window.ShowDialog();
                LoadData(dataGridCentral, bookingSelect);
            }
            else if (loadedTable.Equals(hotelsSelect, StringComparison.Ordinal))
            {
                window = new frmHotel();
                window.ShowDialog();
                LoadData(dataGridCentral, hotelsSelect);
            }
            else if (loadedTable.Equals(customersSelect, StringComparison.Ordinal))
            {
                window = new frmCustomer();
                window.ShowDialog();
                LoadData(dataGridCentral, customersSelect);
            }
            else if (loadedTable.Equals(ticketsSelect, StringComparison.Ordinal))
            {
                window = new frmTicket();
                window.ShowDialog();
                LoadData(dataGridCentral, ticketsSelect);
            }
            else if (loadedTable.Equals(employeesSelect, StringComparison.Ordinal))
            {
                window = new frmEmployee();
                window.ShowDialog();
                LoadData(dataGridCentral, employeesSelect);
            }
            else if (loadedTable.Equals(transportSelect, StringComparison.Ordinal))
            {
                window = new frmTransport();
                window.ShowDialog();
                LoadData(dataGridCentral, transportSelect);
            }
            else if (loadedTable.Equals(organisationUnitsSelect, StringComparison.Ordinal))
            {
                window = new frmOrganisationUnit();
                window.ShowDialog();
                LoadData(dataGridCentral, organisationUnitsSelect);
            }
            else if (loadedTable.Equals(destinationsSelect, StringComparison.Ordinal))
            {
                window = new frmDestination();
                window.ShowDialog();
                LoadData(dataGridCentral, destinationsSelect);
            }
            else if (loadedTable.Equals(typesOfTransportSelecet, StringComparison.Ordinal))
            {
                window = new frmType();
                window.ShowDialog();
                LoadData(dataGridCentral, destinationsSelect);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(loadedTable.Equals(bookingSelect, StringComparison.Ordinal))
            {
                Fill_In_The_Forms(dataGridCentral, selectUslovBooking);
                LoadData(dataGridCentral, bookingSelect);
            }
            else if(loadedTable.Equals(hotelsSelect, StringComparison.Ordinal))
            {
                Fill_In_The_Forms(dataGridCentral, selectUslovHotel);
                LoadData(dataGridCentral, hotelsSelect);
            }
            else if(loadedTable.Equals(customersSelect, StringComparison.Ordinal))
            {
                Fill_In_The_Forms(dataGridCentral, selectUslovCustomer);
                LoadData(dataGridCentral, customersSelect);
            }
            else if (loadedTable.Equals(ticketsSelect, StringComparison.Ordinal))
            {
                Fill_In_The_Forms(dataGridCentral, selectUslovTicket);
                LoadData(dataGridCentral, ticketsSelect);
            }
            else if (loadedTable.Equals(employeesSelect, StringComparison.Ordinal))
            {
                Fill_In_The_Forms(dataGridCentral, selectUslovEmployee);
                LoadData(dataGridCentral, employeesSelect);
            }
            else if (loadedTable.Equals(transportSelect, StringComparison.Ordinal))
            {
                Fill_In_The_Forms(dataGridCentral, selectUslovTransport);
                LoadData(dataGridCentral, transportSelect);
            }
            else if (loadedTable.Equals(organisationUnitsSelect, StringComparison.Ordinal))
            {
                Fill_In_The_Forms(dataGridCentral, selectUslovOrganisationUnit);
                LoadData(dataGridCentral, organisationUnitsSelect);
            }
            else if (loadedTable.Equals(destinationsSelect, StringComparison.Ordinal))
            {
                Fill_In_The_Forms(dataGridCentral, selectUslovDestination);
                LoadData(dataGridCentral, destinationsSelect);
            }
            else if (loadedTable.Equals(typesOfTransportSelecet, StringComparison.Ordinal))
            {
                Fill_In_The_Forms(dataGridCentral, selectUslovType);
                LoadData(dataGridCentral, typesOfTransportSelecet);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (loadedTable.Equals(bookingSelect, StringComparison.Ordinal))
            {
                Delete(dataGridCentral, bookingDelete);
                LoadData(dataGridCentral, bookingSelect);
            }
            else if (loadedTable.Equals(hotelsSelect, StringComparison.Ordinal))
            {
                Delete(dataGridCentral, hotelDelete);
                LoadData(dataGridCentral, hotelsSelect);
            }
            else if (loadedTable.Equals(customersSelect, StringComparison.Ordinal))
            {
                Delete(dataGridCentral, customerDelete);
                LoadData(dataGridCentral, customersSelect);
            }
            else if (loadedTable.Equals(ticketsSelect, StringComparison.Ordinal))
            {
                Delete(dataGridCentral, ticketDelete);
                LoadData(dataGridCentral, ticketsSelect);
            }
            else if (loadedTable.Equals(employeesSelect, StringComparison.Ordinal))
            {
                Delete(dataGridCentral, employeeDelete);
                LoadData(dataGridCentral, employeesSelect);
            }
            else if (loadedTable.Equals(transportSelect, StringComparison.Ordinal))
            {
                Delete(dataGridCentral, transportDelete);
                LoadData(dataGridCentral, transportSelect);
            }
            else if (loadedTable.Equals(organisationUnitsSelect, StringComparison.Ordinal))
            {
                Delete(dataGridCentral, organisationUnitDelete);
                LoadData(dataGridCentral, organisationUnitsSelect);
            }
            else if (loadedTable.Equals(destinationsSelect, StringComparison.Ordinal))
            {
                Delete(dataGridCentral, destinationDelete);
                LoadData(dataGridCentral, destinationsSelect);
            }
            else if (loadedTable.Equals(typesOfTransportSelecet, StringComparison.Ordinal))
            {
                Delete(dataGridCentral, typeDelete);
                LoadData(dataGridCentral, typesOfTransportSelecet);
            }
        }

        void Fill_In_The_Forms(DataGrid grid, string selectUslov)
        {
            try
            {
                konekcija.Open();
                update = true;
                DataRowView row = (DataRowView)grid.SelectedItems[0];
                auxiliaryRow = row;
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = row["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    if (loadedTable.Equals(bookingSelect, StringComparison.Ordinal))
                    {
                        frmBooking windowBooking = new frmBooking(update, auxiliaryRow);
                        windowBooking.cbxEmployee.SelectedValue = reader["EmployeeID"].ToString();
                        windowBooking.cbxCustomer.SelectedValue = reader["CustomerID"].ToString();
                        windowBooking.txtNumberOfPassengers.Text = reader["NumberOfPassengers"].ToString();
                        windowBooking.cbxHotel.SelectedValue = reader["HotelID"].ToString();
                        windowBooking.dpDatumRez.SelectedDate = (DateTime)reader["ReservationDate"];
                        windowBooking.cbxTransport.SelectedValue = reader["TransportID"].ToString();
                        windowBooking.txtTotalPrice.Text = reader["TotalPrice"].ToString();
                        windowBooking.ShowDialog();
                    }
                    else if (loadedTable.Equals(hotelsSelect, StringComparison.Ordinal))
                    {
                        frmHotel windowHotel = new frmHotel(update, auxiliaryRow);
                        windowHotel.txtName.Text = reader["Name"].ToString();
                        windowHotel.txtAdress.Text = reader["Adress"].ToString();
                        windowHotel.txtRoomNumber.Text = reader["RoomNumber"].ToString();
                        windowHotel.txtContact.Text = reader["Contact"].ToString();
                        windowHotel.txtPrice.Text = reader["PricePerNight"].ToString();
                        windowHotel.cbxDestination.SelectedValue = reader["DestinationID"].ToString();
                        windowHotel.ShowDialog();
                    }
                    else if (loadedTable.Equals(customersSelect, StringComparison.Ordinal))
                    {
                        frmCustomer windowCustomer = new frmCustomer(update, auxiliaryRow);
                        windowCustomer.txtName.Text = reader["NameC"].ToString();
                        windowCustomer.txtSurname.Text = reader["SurnameC"].ToString();
                        windowCustomer.txtJMBG.Text = reader["JMBG"].ToString();
                        windowCustomer.txtCity.Text = reader["City"].ToString();
                        windowCustomer.txtAdress.Text = reader["Adress"].ToString();
                        windowCustomer.txtContact.Text = reader["Contact"].ToString();
                        windowCustomer.txtCardNumber.Text = reader["CardNumber"].ToString();
                        windowCustomer.ShowDialog();
                    }
                    else if (loadedTable.Equals(ticketsSelect, StringComparison.Ordinal))
                    {
                        frmTicket windowTicket = new frmTicket(update, auxiliaryRow);
                        windowTicket.cbxType.SelectedValue = reader["TypeID"].ToString();
                        windowTicket.txtDestination.Text = reader["Destination"].ToString();
                        windowTicket.txtSeatNumber.Text = reader["SeatNumber"].ToString();
                        windowTicket.dpDeparture.SelectedDate = (DateTime)reader["Departure"];
                        windowTicket.dpArrival.SelectedDate = (DateTime)reader["Arrival"];
                        windowTicket.txtTicketPrice.Text = reader["TicketPrice"].ToString();
                        windowTicket.ShowDialog();
                    }
                    else if (loadedTable.Equals(employeesSelect, StringComparison.Ordinal))
                    {
                        frmEmployee windowEmployee = new frmEmployee(update, auxiliaryRow);
                        windowEmployee.cbxOrgUnit.SelectedValue = reader["OUID"].ToString();
                        windowEmployee.txtName.Text = reader["NameE"].ToString();
                        windowEmployee.txtSurname.Text = reader["SurnameE"].ToString();
                        windowEmployee.txtJMBG.Text = reader["IdentificationNumber"].ToString();
                        windowEmployee.txtCity.Text = reader["City"].ToString();
                        windowEmployee.txtAdress.Text = reader["Adress"].ToString();
                        windowEmployee.txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                        windowEmployee.txtemail.Text = reader["Email"].ToString();
                        windowEmployee.ShowDialog();
                    }
                    else if (loadedTable.Equals(transportSelect, StringComparison.Ordinal))
                    {
                        frmTransport windowTransport = new frmTransport(update, auxiliaryRow);
                        windowTransport.cbxTicket.SelectedValue = reader["TicketID"].ToString();
                        windowTransport.ShowDialog();
                    }
                    else if (loadedTable.Equals(organisationUnitsSelect, StringComparison.Ordinal))
                    {
                        frmOrganisationUnit windowOrganisationUnit = new frmOrganisationUnit(update, auxiliaryRow);
                        windowOrganisationUnit.txtUnitName.Text = reader["NameOfUnit"].ToString();
                        windowOrganisationUnit.ShowDialog();
                    }
                    else if (loadedTable.Equals(destinationsSelect, StringComparison.Ordinal))
                    {
                        frmDestination windowDestination = new frmDestination(update, auxiliaryRow);
                        windowDestination.txtState.Text = reader["State"].ToString();
                        windowDestination.txtCity.Text = reader["City"].ToString();
                        windowDestination.ShowDialog();
                    }
                    else if (loadedTable.Equals(typesOfTransportSelecet, StringComparison.Ordinal))
                    {
                        frmType windowType = new frmType(update, auxiliaryRow);
                        windowType.txtTransportType.Text = reader["TypeName"].ToString();
                        windowType.ShowDialog();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No row is selected. Make sure that you have selected a row.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                update = false;
            }
        }

        void Delete(DataGrid grid, string deleteUpit)
        {
            try
            {
                konekcija.Open();
                DataRowView row = (DataRowView)grid.SelectedItems[0];
                MessageBoxResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(result==MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("No row is selected.Make sure that you have selected a row.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(SqlException)
            {
                MessageBox.Show("There are related data in other tables!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if(konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
