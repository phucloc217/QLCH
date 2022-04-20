using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class NhanVien_BUS
    {
        public DataTable LoadNhanVien()
        {
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select manv, hoten, loainv from nhanvien order by manv asc");
            return dt;
        }

        public string TaoMaNV()
        {
            string ma = "";
            int so=1;
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select manv from nhanvien order by manv desc");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                ma = row["manv"].ToString();
            }
            so = int.Parse( ma.Substring(2, ma.Length - 2))+1;
            ma = "NV" + so.ToString("000");
            return ma.Trim();
        }

        public bool ThemNV(NhanVien nv)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "insert into nhanvien(manv, hoten, loainv, matkhau) values (@0, @1, @2,@3)";
            string[] para =
            {
               nv.Manv,
               nv.Hoten,
               nv.Loainv.ToString(),
               nv.Matkhau
            };
            if (kn.Execute(sql, para))
                return true;
            else
                return false;
        }
        public bool CapNhatNV(NhanVien nv)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "update nhanvien set hoten = @0, loainv=@1 where manv = @2";
            string[] para =
            {
               nv.Hoten,
               nv.Loainv.ToString(),
               nv.Manv
            };
            if (kn.Execute(sql, para))
                return true;
            else
                return false;
        }
        public bool XoaNV(string manv)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "DELETE FROM nhanvien WHERE manv=@0;";
            string[] para =
            {
               manv
            };
            if (kn.Execute(sql, para))
                return true;
            else
                return false;
        }
        public bool CapNhatMK(string manv, string matKhau)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "update nhanvien set matkhau = @0 where manv = @1";
            string[] para =
            {
              matKhau,
              manv
            };
            if (kn.Execute(sql, para))
                return true;
            else
                return false;
        }
    }


}
