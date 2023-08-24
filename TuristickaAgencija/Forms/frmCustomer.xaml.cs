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
    /// Interaction logic for frmCustomer.xaml
    /// </summary>
    public partial class frmCustomer : Window
    {
        Connection kon = new Connection();
        SqlConnection konekcija = new SqlConnection();
        bool update;
        DataRowView auxiliaryRow;

        public frmCustomer()
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            txtName.Focus();

        }
        

        public frmCustomer(bool update, DataRowView auxiliaryRow)
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            txtName.Focus();
            this.update = update;
            this.auxiliaryRow = auxiliaryRow;

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
                cmd.Parameters.Add(@"NameC", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add(@"SurnameC", SqlDbType.NVarChar).Value = txtSurname.Text;
                cmd.Parameters.Add(@"JMBG", SqlDbType.NVarChar).Value = txtJMBG.Text;
                cmd.Parameters.Add(@"City", SqlDbType.NVarChar).Value = txtCity.Text;
                cmd.Parameters.Add(@"Adress", SqlDbType.NVarChar).Value = txtAdress.Text;
                cmd.Parameters.Add(@"Contact", SqlDbType.NVarChar).Value = txtContact.Text;
                cmd.Parameters.Add(@"CardNumber", SqlDbType.NVarChar).Value = txtCardNumber.Text;

                if(this.update)
                {
                    DataRowView row = this.auxiliaryRow;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update tblCustomer set NameC=@NameC, SurnameC=@SurnameC, JMBG=@JMBG, City=@City,
                                       Adress=@Adress, Contact=@Contact, CardNumber=@CardNumber where CustomerID=@id";
                    this.auxiliaryRow = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblCustomer(NameC, SurnameC, JMBG, City, Adress, Contact, CardNumber)
                                    values(@NameC, @SurnameC, @JMBG, @City, @Adress, @Contact, @CardNumber);";
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
