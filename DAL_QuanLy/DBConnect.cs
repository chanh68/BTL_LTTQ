using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DBConnect
    {
        //protected SqlConnection _conn = new SqlConnection("Data Source=Chanh\\SQLEXPRESS;Initial Catalog=DB_LTTQ;Integrated Security=True");
        protected SqlConnection _conn = new SqlConnection("Data Source=DESKTOP-S8N7JNH\\SQLEXPRESS;Initial Catalog=DB_LTTQ;Integrated Security=True;TrustServerCertificate=True");

    }
}
