using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiHoaDon_BUS
    {
        public DataTable LoadLoaiHD()
        {
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select * from loaihoadon order by maloai asc");
            return dt;
        }
        public string TaoMaLoai()
        {
            int so = 1;
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select maloai from loaihoadon order by maloai desc");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                so = int.Parse(row["maloai"].ToString());
            }
            so++;
            return so.ToString().Trim();
        }

        public bool ThemLoai(LoaiHoaDon lhd)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "insert into loaihoadon( tenloai, dongia) values (@0, @1)";
            string[] para =
            {
             lhd.Tenloai,
             lhd.Dongia.ToString()
            };
            return kn.Execute(sql, para);
        }
        public bool CapNhatLHD(LoaiHoaDon lhd)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "update loaihoadon set tenloai=@0, dongia = @1 where maloai = @2";
            string[] para =
            {
              lhd.Tenloai,
              lhd.Dongia.ToString(),
              lhd.Ma.ToString()
            };
            return kn.Execute(sql, para);
        }
        public bool XoaLHD(string maloai)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "DELETE FROM loaihoadon WHERE maloai=@0;";
            string[] para =
            {
               maloai
            };
            return kn.Execute(sql, para);
        }

        public LoaiHoaDon TimLoaiHD(string ma)
        {
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select top 1 * from loaihoadon where maloai = "+ma);
            LoaiHoaDon lhd = new LoaiHoaDon();
            lhd.Ma = (int)dt.Rows[0]["maloai"];
            lhd.Tenloai = (string)dt.Rows[0]["tenloai"];
            lhd.Dongia = (int)dt.Rows[0]["dongia"];
            return lhd;
        }

    }
}
