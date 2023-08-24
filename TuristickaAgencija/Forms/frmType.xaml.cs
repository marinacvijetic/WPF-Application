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
    /// Interaction logic for frmType.xaml
    /// </summary>
    public partial class frmType : Window
    {
        Connection kon = new Connection();
        SqlConnection konekcija = new SqlConnection();
        bool update;
        DataRowView auxiliaryRow;

        

        public frmType()
        {
            InitializeComponent();
            konekcija = kon.CreatingConnection();
            txtTransportType.Focus();
        }
        public frmType(bool update, DataRowView auxiliaryRow)
        {
            InitializeComponent();
            txtTransportType.Focus();
            this.update = update;
            this.auxiliaryRow = auxiliaryRow;
            konekcija = kon.CreatingConnection();
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
                cmd.Parameters.Add(@"TypeName", SqlDbType.NVarChar).Value = txtTransportType.Text;
                if(this.update)
                {
                    DataRowView row = this.auxiliaryRow;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update tblType
                                    set TypeName=@TypeName where TypeID=@id";
                    this.auxiliaryRow = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblType(TypeName)
                                    values(@TypeName);";
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
