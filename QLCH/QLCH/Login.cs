using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;


namespace QLCH
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        NhanVien_BUS nvb = new NhanVien_BUS();
        public Login()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataTable dt = nvb.DangNhap(txt_ten.Text, txt_mk.Text);
            if (dt.Rows.Count>0)
            {
                Program.nv.Manv = txt_ten.Text;
                Program.nv.Loainv = bool.Parse( dt.Rows[0]["loainv"].ToString());
                QLCH ql = new QLCH();
                ql.ShowDialog();
                this.Hide();
            }   
        }
    }
}