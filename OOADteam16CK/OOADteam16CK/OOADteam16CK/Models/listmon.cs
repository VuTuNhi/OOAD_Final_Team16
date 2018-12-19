using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOADteam16CK.Models
{
    public class mon
    {

        public int BanID { get; set; }
        public string KhachHangID { get; set; }
        public string MonAnId { get; set; }
        public int soluong { get; set; }
    }
    public class bans
    {

        public List<mon> listmons { get; set; }
        public int MaHD { get; set; }
    }
}
