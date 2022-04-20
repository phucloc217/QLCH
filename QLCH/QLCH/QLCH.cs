using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCH
{
    public partial class QLCH : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public QLCH()
        {
            InitializeComponent();
        }

        private void QLCH_Load(object sender, EventArgs e)
        {
            if (Program.nv.Loainv==false)
            {
                ribbonPageGroup1.Visible = false;
                ribbonPageGroup2.Visible = false;
                ribbonPageGroup5.Visible = false;
            }    
        }
        public Boolean KiemTraTonTai(string Frmname)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name.Equals(Frmname))
                    return true;
            }
            return false;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            QLNV frm = new QLNV();
            if (KiemTraTonTai("QLNV") == true)
                frm.Activate();
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void btn_DSLau_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = new QLLau();
            if (KiemTraTonTai("QLLau") == true)
                frm.Activate();
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void btn_QLKhach_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = new QLNguoiThue();
            if (KiemTraTonTai("QLNguoiThue") == true)
                frm.Activate();
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = new QLCanHo();
            if (KiemTraTonTai("QLCanHo") == true)
                frm.Activate();
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = new QLDichVu();
            if (KiemTraTonTai("QLDichVu") == true)
                frm.Activate();
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = new QLHoaDon();
            if (KiemTraTonTai("QLHoaDon") == true)
                frm.Activate();
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = new XtraForm1();
            if (KiemTraTonTai("XtraForm1") == true)
                frm.Activate();
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }


        internal class XtraReport1
        {
        }

        private void QLCH_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}