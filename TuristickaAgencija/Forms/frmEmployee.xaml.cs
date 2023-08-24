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
    /// Interaction logic for frmEmployee.xaml
    /// </summary>

    public partial class frmEmployee : Window
    {
        Connection kon = new Connection();
        SqlConnection konekcija = new SqlConnection();

        bool update;
        DataRowView auxiliaryRow;

        public frmEmployee(bool update, DataRowView auxiliaryRow)
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            cbxOrgUnit.Focus();
            this.update = update;
            this.auxiliaryRow = auxiliaryRow;

            try
            {
                konekcija.Open();
                //OrganisationUnit
                string returnOrgUnit = @"select OUID, NameOfUnit as Unit from tblOrganisationUnit;";
                DataTable dtOrgUnit = new DataTable();
                dtOrgUnit.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daOrgUnit = new SqlDataAdapter(returnOrgUnit, konekcija);
                daOrgUnit.Fill(dtOrgUnit);
                cbxOrgUnit.ItemsSource = dtOrgUnit.DefaultView;
                dtOrgUnit.Dispose();
                daOrgUnit.Dispose();
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
        public frmEmployee()
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            cbxOrgUnit.Focus();

            try
            {
                konekcija.Open();
                //OrganisationUnit
                string returnOrgUnit = @"select OUID, NameOfUnit as Unit from tblOrganisationUnit;";
                DataTable dtOrgUnit = new DataTable();
                dtOrgUnit.Locale = CultureInfo.InvariantCulture;
                SqlDataAdapter daOrgUnit = new SqlDataAdapter(returnOrgUnit, konekcija);
                daOrgUnit.Fill(dtOrgUnit);
                cbxOrgUnit.ItemsSource = dtOrgUnit.DefaultView;
                dtOrgUnit.Dispose();
                daOrgUnit.Dispose();
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

                cmd.Parameters.Add(@"OUID", SqlDbType.Int).Value = cbxOrgUnit.SelectedValue;
                cmd.Parameters.Add(@"NameE", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add(@"SurnameE", SqlDbType.NVarChar).Value = txtSurname.Text;
                cmd.Parameters.Add(@"IdentificationNumber", SqlDbType.NVarChar).Value = txtJMBG.Text;
                cmd.Parameters.Add(@"City", SqlDbType.NVarChar).Value = txtCity.Text;
                cmd.Parameters.Add(@"Adress", SqlDbType.NVarChar).Value = txtAdress.Text;
                cmd.Parameters.Add(@"PhoneNumber", SqlDbType.NVarChar).Value = txtPhoneNumber.Text;
                cmd.Parameters.Add(@"Email", SqlDbType.NVarChar).Value = txtemail.Text;

                if(this.update)
                {
                    DataRowView row = this.auxiliaryRow;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"Update tblEmployee set OUID=@OUID, NameE=@NameE, SurnameE=@SurnameE, IdentificationNumber=@IdentificationNumber, 
                                     City=@City, Adress=@Adress, PhoneNumber=@PhoneNumber, Email=@Email where EmployeeID=@id";
                    this.auxiliaryRow = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblEmployee(OUID, NameE, SurnameE, IdentificationNumber, City, Adress, PhoneNumber, Email)
                                  values(@OUID, @NameE, @SurnameE, @IdentificationNumber, @City, @Adress, @PhoneNumber, @Email);";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();


            }
            catch (SqlException)
            {
                MessageBox.Show("Entered value is not valid.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
