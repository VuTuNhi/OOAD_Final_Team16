using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOADteam16CK.Models
{
    public class MonAnViewModel
    {
        
        public int MaMA { get; set; }
        public string TenMA { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public double GiamGia { get; set; }
     
        public double GiaBan => DonGia * (1 - GiamGia);
    }
    public class KhachHangDatMonViewModel
    {
        public List<MonAnViewModel> Monans { get; set; }
        public List<ChiTietHd> chiTietHds { get; set; }
    }
}
