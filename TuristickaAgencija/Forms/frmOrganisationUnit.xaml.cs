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
    /// Interaction logic for frmOrganisationUnit.xaml
    /// </summary>
    public partial class frmOrganisationUnit : Window
    {
        bool update;
        DataRowView auxiliaryRow;
        Connection kon = new Connection();
        SqlConnection konekcija = new SqlConnection();
        

        public frmOrganisationUnit()
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            txtUnitName.Focus();

        }
        public frmOrganisationUnit(bool update, DataRowView auxiliaryRow)
        {
            InitializeComponent();
           
            txtUnitName.Focus();
            this.update = update;
            this.auxiliaryRow = auxiliaryRow;
            konekcija = kon.CreatingConnection();

        }

       


        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add(@"NameOfUnit", SqlDbType.NVarChar).Value = txtUnitName.Text;
                if(this.update)
                {
                    DataRowView row = this.auxiliaryRow;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"Update tblOrganisationUnit 
                                        set NameOfUnit=@NameOfUnit where OUID=@id";
                    this.auxiliaryRow = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblOrganisationUnit(NameOfUnit)
                                    values(@NameOfUnit);";
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
