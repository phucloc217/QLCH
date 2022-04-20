using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiHoaDon
    {
        private int ma;
        private string tenloai;
        private int dongia;

        public LoaiHoaDon()
        {
            this.ma = 0;
            this.tenloai = "";
            this.dongia = 0;
        }

        public LoaiHoaDon(int ma, string tenloai, int dongia)
        {
            this.ma = ma;
            this.tenloai = tenloai;
            this.dongia = dongia;
        }

        public int Ma { get => ma; set => ma = value; }
        public string Tenloai { get => tenloai; set => tenloai = value; }
        public int Dongia { get => dongia; set => dongia = value; }
    }
}
