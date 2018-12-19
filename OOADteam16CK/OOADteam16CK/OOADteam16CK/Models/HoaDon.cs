using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OOADteam16CK.Models
{
    public class HoaDon
    {
        public int HoaDonID { get; set; }
        public int KhachHangID { get; set; }
        [ForeignKey("KhachHangID")]
        public KhachHang KhanhHang { get; set; }
        public int BanID { get; set; }
        [ForeignKey("BanID")]
        public Ban Ban { get; set; }
        public string ChuThich { get; set; }
        public int TrangThaiID { get; set; }
        [ForeignKey("TrangThaiID")]
        public TrangThai TrangThai { get; set; }

    }
}
