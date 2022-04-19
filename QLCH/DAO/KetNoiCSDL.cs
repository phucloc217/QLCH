using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
  public  class KetNoiCSDL
    {
        public static string strcn = @"Data Source=(local);Initial Catalog=QLCH;Integrated Security=True";
        public static SqlConnection sqlcnn = new SqlConnection(strcn);
        public void moketnoi()
        {
            sqlcnn.Open();

        }
        public void dongketnoi()
        {
            sqlcnn.Close();
        }
        public bool Execute(string sql, string[] para = null)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(sql, sqlcnn);
                cmd.CommandType = CommandType.Text;
                if (para != null)
                {
                    for(int i = 0; i<para.Length;i++)
                        cmd.Parameters.AddWithValue("@" + i, para[i]);
                }
                sqlcnn.Open();
                cmd.ExecuteNonQuery();
                sqlcnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return false;
            }
        }
        public DataTable LoadData(string sql,string[] para = null)
        {
            try
            {
                string SqlSelectQuery = sql;
                SqlCommand cmd = new SqlCommand(SqlSelectQuery, sqlcnn);
                cmd.CommandType = CommandType.Text;
                if (para != null)
                {
                    foreach (string a in para)
                        cmd.Parameters.AddWithValue("@"+a, a);
                }
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlcnn);  
                sqlcnn.Open();
                da.Fill(dt);
                sqlcnn.Close();
                return dt;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                return null;
            }

        }
    }
}
