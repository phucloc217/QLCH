using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Lau
    {
        private int ma;
        private string ten;
        private string mota;

        public Lau()
        {
            this.ma = 0;
            this.ten = "";
            this.mota = "";
        }

        public Lau(int ma, string ten, string mota)
        {
            this.ma = ma;
            this.ten = ten;
            this.mota = mota;
        }

        public int Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Mota { get => mota; set => mota = value; }
    }
}
