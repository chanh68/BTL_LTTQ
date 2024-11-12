using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_HangHoa
    {
        DAL_HangHoa dalHH = new DAL_HangHoa();

        public DTO_HangHoa LayThongTinHangHoa (string maHang)
        {
            return dalHH.LayThongTinHangHoa(maHang);
        }

        public List<DTO_HangHoa> LayDanhSachHangHoa()
        {
            return dalHH.LayDanhSachHangHoa();
        }

    }
}
