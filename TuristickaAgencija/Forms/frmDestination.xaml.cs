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

namespace TuristickaAgencija.Forms
{
    /// <summary>
    /// Interaction logic for frmDestination.xaml
    /// </summary>
    public partial class frmDestination : Window //klasa destinacija
    {
        Connection kon = new Connection();
        SqlConnection konekcija = new SqlConnection();

        bool update;
        DataRowView auxiliaryRow;

        public frmDestination(bool update, DataRowView auxiliaryRow)
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            txtState.Focus();
            this.update = update;
            this.auxiliaryRow = auxiliaryRow;

        }
        public frmDestination() //metoda bez parametara KONSTRUKTOR - pravi instancu klase destinacija
        {
            //Kada zelim da se nesto desava pri otvaranju prozora, to se definise u ovoj metodi konstruktora
            InitializeComponent(); // svaki put kada se pozove metoda frmdestination, ova naredba generise prozor destinacije
            konekcija = kon.CreatingConnection(); //eksplicitno otvaram i zatvaram konekciju
            txtState.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try //pokusaj konekcije na bazu i izvrsavanje naredbe insert
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = txtState.Text;
                cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = txtCity.Text;

                if(this.update)
                {
                    DataRowView row = this.auxiliaryRow;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update tblDestination
                                        set State=@State, City=@City where DestinationID=@id";
                    this.auxiliaryRow = null;
                }
                else
                {
                    cmd.CommandText = @"Insert into tblDestination(State, City)
                                     values(@State, @City);";
                }
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException) //ukoliko se desio izuzetak, hvatamo ga
            {
                MessageBox.Show("Entered value is not valid.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally //desava se no matter what, zatvaranje konekcije
            {
                if(konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //this - selektuje instancu u kojoj se trenutno nalazimo
        }
    }
}
