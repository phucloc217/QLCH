using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CanHo
    {
        private string ma;
        private float dientich;
        private int tang;
        private int gia;
        private string mota;

        public CanHo()
        {
            this.ma = "";
            this.dientich = 0;
            this.tang = 0;
            this.gia = 0;
            this.mota = "";
        }

        public CanHo(string ma, float dientich, int tang, int gia, string mota)
        {
            this.ma = ma;
            this.dientich = dientich;
            this.tang = tang;
            this.gia = gia;
            this.mota = mota;
        }

        public string Ma { get => ma; set => ma = value; }
        public float Dientich { get => dientich; set => dientich = value; }
        public int Tang { get => tang; set => tang = value; }
        public int Gia { get => gia; set => gia = value; }
        public string Mota { get => mota; set => mota = value; }
    }
}
