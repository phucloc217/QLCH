using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DevExpress.XtraEditors;
using DTO;

namespace BUS
{
    public class HoaDon_BUS
    {
        public DataTable LoadHoaDon()
        {
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select mahd, mach, loaihd, tenloai, thang, soluong, hoadon.dongia from hoadon join loaihoadon on hoadon.loaihd = loaihoadon.maloai order by mahd asc");
            return dt;
        }
        public string TaoMaHD()
        {
            string ma = "";
            int so = 1;
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select mahd from hoadon order by mahd desc");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                ma = row["mahd"].ToString();
            }
            so = int.Parse(ma.Substring(2, ma.Length - 2)) + 1;
            ma = "HD" + so.ToString("0000");
            return ma.Trim();
        }

        public bool ThemHD(HoaDon hd)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            
            string sql = "select * from HoaDon where mach='"+ hd.Mach.ToString().Trim()+"'and loaihd = "+hd.Loaihd+ "and MONTH(thang) ="+hd.Thang.Month;
            DataTable dt = kn.LoadData(sql);
            if (dt.Rows.Count > 0)
            {
                return false;
            }


            sql = "insert into hoadon(mahd, mach, loaihd, thang, soluong, dongia) values (@0, @1, @2,@3,@4,@5)";
            string[] para =
            {
              hd.Mahd,
              hd.Mach,
              hd.Loaihd.ToString(),
              hd.Thang.ToString(),
              hd.Soluong.ToString(),
              hd.Dongia.ToString()
            };
            return kn.Execute(sql, para);
        }
       
        public bool XoaHD(string mahd)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "DELETE FROM hoadon WHERE mahd=@0;";
            string[] para =
            {
               mahd
            };
            return kn.Execute(sql, para);
        }
    }
}
