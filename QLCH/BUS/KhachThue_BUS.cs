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
    public class KhachThue_BUS
    {
        public DataTable LoadKhachThue()
        {
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select * from nguoithue order by mant asc");
            return dt;
        }
        public string TaoMaKH()
        {
            string ma = "";
            int so = 1;
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select mant from nguoithue order by mant desc");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                ma = row["mant"].ToString();
            }
            so = int.Parse(ma.Substring(2, ma.Length - 2)) + 1;
            ma = "KT" + so.ToString("000");
            return ma.Trim();
        }

        public bool ThemKH(NguoiThue nt)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "insert into nguoithue(mant, hoten, cccd, sodt,mach) values (@0, @1, @2,@3,@4)";
            string[] para =
            {
              nt.Ma,
              nt.Hoten,
              nt.Cccd,
              nt.Sdt,
              nt.Mach
            };
            return kn.Execute(sql, para);
        }
        public bool CapNhatKH(NguoiThue nt)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "update nguoithue set hoten=@0, cccd = @1, sodt = @2, mach = @3 where mant = @4";
            string[] para =
            {
              nt.Hoten,
              nt.Cccd,
              nt.Sdt,
              nt.Mach,
              nt.Ma
            };
            return kn.Execute(sql, para);
        }
        public bool XoaKH(string mant)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "DELETE FROM nguoithue WHERE mant=@0;";
            string[] para =
            {
               mant
            };
            return kn.Execute(sql, para);
        }

    }
}
