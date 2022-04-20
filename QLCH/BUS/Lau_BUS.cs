using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class Lau_BUS
    {
        public DataTable LoadLau()
        {
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select * from lau order by id asc");
            return dt;
        }
        public string TaoID()
        {
            int so = 1;
            KetNoiCSDL ketnoicsdl = new KetNoiCSDL();
            DataTable dt = ketnoicsdl.LoadData("select id from lau order by id desc");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                so = int.Parse( row["id"].ToString());
            }
            so++;
            return so.ToString().Trim();
        }
        public bool ThemLau(Lau lau)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "insert into lau( tenlau, mota) values (@0, @1)";
            string[] para =
            {
               lau.Ten,
               lau.Mota
            };
            return kn.Execute(sql, para);
        }
        public bool CapNhatLau(Lau lau)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "update lau set tenlau = @0, mota=@1 where id = @2";
            string[] para =
            {
               lau.Ten,
               lau.Mota,
               lau.Ma.ToString()
            };
            return kn.Execute(sql, para);
        }
        public bool XoaLau(string id)
        {
            KetNoiCSDL kn = new KetNoiCSDL();
            string sql = "DELETE FROM lau WHERE id=@0;";
            string[] para =
            {
               id
            };
            return kn.Execute(sql, para);
        }
    }
}
