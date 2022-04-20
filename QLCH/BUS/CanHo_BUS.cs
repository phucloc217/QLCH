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
    public class CanHo_BUS
    {
        public DataTable LoadCanHo()
        {
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select * from canho order by mach asc");
            return dt;
        }

        public DataTable LoadLKCanHo()
        {
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select mach, gia from canho order by mach asc");
            return dt;
        }

        public string TaoMaCH(int lau)
        {
            string ma = "";
            int so = 1;
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select mach from canho where tang = "+lau+" order by mach desc");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                ma = row["mach"].ToString();
            }
            if (!string.IsNullOrEmpty(ma))
                so = int.Parse(ma.Substring(3, ma.Length - 3)) + 1;
            ma = "CH" +lau+ so.ToString("00");
            return ma.Trim();
        }

        public bool ThemCH(CanHo ch)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "insert into canho(mach, dientich, tang, gia,mota) values (@0, @1, @2,@3,@4)";
            string[] para =
            {
               ch.Ma.ToString(),
               ch.Dientich.ToString(),
               ch.Tang.ToString(),
               ch.Gia.ToString(),
               ch.Mota.ToString()
            };
            return kn.Execute(sql, para);
        }
        public bool CapNhatCH(CanHo ch)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "update canho set dientich=@0, tang = @1, gia = @2, mota = @3 where mach = @4";
            string[] para =
            {
               ch.Dientich.ToString(),
               ch.Tang.ToString(),
               ch.Gia.ToString(),
               ch.Mota.ToString(),
               ch.Ma.ToString()
            };
            return kn.Execute(sql, para);
        }
        public bool XoaCH(string mach)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "DELETE FROM canho WHERE mach=@0;";
            string[] para =
            {
               mach
            };
            return kn.Execute(sql, para);
        }
    }
}
