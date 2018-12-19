using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OOADteam16CK.Models
{
    public class ChiTietHd
    {
        public int ChiTietHdID { get; set; }
        public int HoaDonID { get; set; }
        [ForeignKey("HoaDonID")]
        public HoaDon HoaDon { get; set; }
        public int MonAnID { get; set; }
        [ForeignKey("MonAnID")]
        public MonAn MonAn { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double GiamGia { get; set; }
        public double ThanhTien => SoLuong*(DonGia * (1 - GiamGia));
    }
}
