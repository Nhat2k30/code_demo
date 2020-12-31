using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Tuan12_HTTT_09DHTH6_SM11_BTVN
{
    class Connect
    {
        public SqlConnection conSQL;
        public Connect()
        {
            string s = "Data Source = LAPTOP-8HT21AIE\\SQLEXPRESS; Initial Catalog = QLSinhVien; User ID = sa; Password=sa2012";
            conSQL = new SqlConnection(s);
        }
    }
}
