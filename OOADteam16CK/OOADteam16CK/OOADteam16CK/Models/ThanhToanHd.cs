using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOADteam16CK.Models
{
    public class ThanhToanHd
    {
        public int SOBAN { get; set; }
        public int TENKH { get; set; }
        public int TENMON { get; set; }
        public double DONGIA { get; set; }
        public int SOLUONG { get; set; }
        public double GIAMGIA { get; set; }
        public double THANHTIEN => SOLUONG * (DONGIA * (1 - GIAMGIA));
    }
}
