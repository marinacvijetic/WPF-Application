using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TuristickaAgencija
{
    class Connection
    {
        public SqlConnection CreatingConnection()
        {
            SqlConnectionStringBuilder ConSb = new SqlConnectionStringBuilder
            {
                DataSource = @"HP-PC", //lokalni server racunara
                InitialCatalog = "TuristickaAgencija", //baza na lokalnom serveru
                IntegratedSecurity = true //autentifikacija

            };
            string conn = ConSb.ToString();
            SqlConnection connection = new SqlConnection(conn);
            return connection;
        }

    }
}
