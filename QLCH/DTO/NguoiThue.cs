using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiThue
    {
        private string ma;
        private string hoten;
        private string cccd;
        private string sdt;
        private string mach;

        public NguoiThue()
        {
            this.ma = "";
            this.hoten = "";
            this.cccd = "";
            this.sdt = "";
            this.mach = "";
        }

        public NguoiThue(string ma, string hoten, string cccd, string sdt, string mach)
        {
            this.ma = ma;
            this.hoten = hoten;
            this.cccd = cccd;
            this.sdt = sdt;
            this.mach = mach;
        }

        public string Ma { get => ma; set => ma = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Cccd { get => cccd; set => cccd = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Mach { get => mach; set => mach = value; }
    }
}
