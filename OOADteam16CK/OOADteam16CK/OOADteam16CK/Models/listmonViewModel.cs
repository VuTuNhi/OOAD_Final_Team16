using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOADteam16CK.Models
{
    public class listmonViewModel
    {
        public string TenMon { get; set; }
        public double DonGia { get; set; }
        public int Soluong { get; set; }
        public double GiamGia { get; set; }
        public double Gia => DonGia * (1 - GiamGia);
    }
}
