using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OOADteam16CK.Models
{
    public class MonAn
    {
        public int MonAnID { get; set; }
        public int LoaiID { get; set; }
        [ForeignKey("LoaiID")]
        public Loai Loai { get; set; }
        public string TenMon { get; set; }
        public double DonGia { get; set; }
        public string Hinh { get; set; }
        public string MoTa { get; set; }
        public double GiamGia { get; set; }
        public int TrangThaiID { get; set; }
        [ForeignKey("TrangThaiID")]
        public TrangThai TrangThai { get; set; }

    }
}
