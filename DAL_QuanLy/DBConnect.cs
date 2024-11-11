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
        //protected SqlConnection _conn = new SqlConnection("Data Source=LAPTOP-L4E28I51\\SQLEXPRESS;Initial Catalog=BTL_TQ;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        //protected SqlConnection _conn = new SqlConnection("Data Source=DESKTOP-R4RPQKD;Initial Catalog=BTL_6;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
    }
}
