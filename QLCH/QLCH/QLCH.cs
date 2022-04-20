using DevExpress.XtraBars;
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
    }
}