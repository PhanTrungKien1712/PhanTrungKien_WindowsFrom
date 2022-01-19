using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQLKS.models
{
    public class ThuePhongKhachHang
    {
        public string MaThue { get; set; }

        public string MaKH { get; set; }

        public string TenKH { get; set; }

        public string MaP { get; set; }

        public string TenP { get; set; }

        public DateTime NgayVao { get; set; }

        public DateTime NgayRa { get; set; }

        public double DatCoc { get; set; }

    }
}
