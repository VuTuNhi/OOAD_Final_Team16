using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOADteam16CK.Models
{
    public class thanhtoanViewModel
    {
        public int BanID { get; set; }
        public string KhachHangID { get; set; }
        public string MonAnId { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double GiamGia { get; set; }
        public double ThanhTien => SoLuong * (DonGia * (1 - GiamGia));
        
    }
    public class thanhtoanview
    {
        public int MaHD { get; set; }
        public List<thanhtoanViewModel> ttviewmodel { get; set; }
    }
}
