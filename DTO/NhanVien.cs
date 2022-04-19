using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class NhanVien
    {
        private string manv;
        private string hoten;
        private bool loainv;
        private string matkhau;

        public NhanVien()
        {
        }

        public NhanVien(string manv, string hoten, bool loainv, string matkhau)
        {
            this.manv = manv;
            this.hoten = hoten;
            this.loainv = loainv;
            this.matkhau = matkhau;
        }

        public string Manv { get => manv; set => manv = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public bool Loainv { get => loainv; set => loainv = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
    }
}
