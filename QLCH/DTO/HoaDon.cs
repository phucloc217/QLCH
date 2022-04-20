using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        private string mahd;
        private string macd;
        private int loaihd;
        private DateTime thang;
        private int soluong;
        private int dongia;

        public HoaDon()
        {
            this.mahd = "";
            this.macd = "";
            this.loaihd = 0;
            this.thang = new DateTime();
            this.soluong = 0;
            this.dongia = 0;
        }

        public HoaDon(string mahd, string macd, int loaihd, DateTime thang, int soluong, int dongia)
        {
            this.mahd = mahd;
            this.macd = macd;
            this.loaihd = loaihd;
            this.thang = thang;
            this.soluong = soluong;
            this.dongia = dongia;
        }

        public string Mahd { get => mahd; set => mahd = value; }
        public string Macd { get => macd; set => macd = value; }
        public int Loaihd { get => loaihd; set => loaihd = value; }
        public DateTime Thang { get => thang; set => thang = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public int Dongia { get => dongia; set => dongia = value; }
    }
}
