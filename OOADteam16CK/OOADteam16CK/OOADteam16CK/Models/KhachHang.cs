using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOADteam16CK.Models
{
    public class KhachHang
    {
        public int KhachHangID { get; set; }
        public string TenKh { get; set; }
        public string MatKhau { get; set; }
        public double Diem { get; set; }
        public double GiamGia => (double)(Diem / 1000);
    }
}
