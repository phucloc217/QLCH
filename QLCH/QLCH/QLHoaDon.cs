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
using BUS;
using DTO;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraEditors;

namespace QLCH
{
    public partial class QLHoaDon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private HoaDon_BUS hdb = new HoaDon_BUS();
        public QLHoaDon()
        {
            InitializeComponent();
        }

        private void QLHoaDon_Load(object sender, EventArgs e)
        {
            d_ngaylap.Properties.MaxValue = DateTime.Today;
            XoaTextBox();
            CanHo_BUS chb = new CanHo_BUS();
            lk_canho.Properties.DataSource = chb.LoadLKCanHo();
            lk_canho.ItemIndex = 0;

            LoaiHoaDon_BUS lhdb = new LoaiHoaDon_BUS();
            lk_loai.Properties.DataSource = lhdb.LoadLoaiHD();
            lk_loai.ItemIndex = 0;
            LoadTable();
        }
        private void LoadTable()
        {
            gridControl1.DataSource = hdb.LoadHoaDon();
        }
        private void XoaTextBox()
        {
            btn_them.Enabled = true;
            btn_xoa.Enabled = true;
            lk_canho.ItemIndex = 0;
            lk_loai.ItemIndex = 0;
            txt_ma.Text = "";
            txt_soluong.Text = 1.ToString();
            txt_dongia.Text = "";
            d_ngaylap.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        }
        private void btn_huy_Click(object sender, EventArgs e)
        {
            XoaTextBox();
            groupBox1.Enabled = false;
        }

        private void btn_them_ItemClick(object sender, ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            XoaTextBox();
            txt_ma.Text = hdb.TaoMaHD();
            lk_loai.ItemIndex = 1;
            lk_loai.ItemIndex = 0;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            groupBox1.Enabled = false;
            txt_ma.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["mahd"]).ToString();
            txt_soluong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["soluong"]).ToString();
            txt_dongia.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["dongia"]).ToString();
            int i = 0;
            DataTable dt = lk_canho.Properties.DataSource as DataTable;
            for (i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["mach"].ToString() == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["mach"]).ToString())
                    break;
            }
            lk_canho.ItemIndex = i;
            dt = lk_loai.Properties.DataSource as DataTable;
            for (i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["maloai"].ToString() == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["loaihd"]).ToString())
                    break;
            }
            lk_canho.ItemIndex = i;
        }

        private void lk_loai_EditValueChanged(object sender, EventArgs e)
        {
            LoaiHoaDon_BUS lhdb = new LoaiHoaDon_BUS();
            txt_dongia.Text = lhdb.TimLoaiHD(lk_loai.EditValue.ToString()).Dongia.ToString();
        }

        private void btn_xoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_ma.Text))
            {
                DialogResult dl = XtraMessageBox.Show("Bạn có chắc muốn xóa hóa đơn " + txt_ma.Text.Trim() + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    if (hdb.XoaHD(txt_ma.Text.Trim()))
                    {
                        XtraMessageBox.Show("Xóa hóa đơn " + txt_ma.Text.Trim() + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        groupBox1.Enabled = false;
                        XoaTextBox();
                        LoadTable();
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.Mahd = txt_ma.Text;
            hd.Mach = lk_canho.EditValue.ToString();
            hd.Loaihd = int.Parse(lk_loai.EditValue.ToString());
            hd.Thang = DateTime.Parse(d_ngaylap.EditValue.ToString());
            hd.Soluong = int.Parse(txt_soluong.Text);
            hd.Dongia = int.Parse(txt_dongia.Text);
            if (hdb.ThemHD(hd))
            {
                XtraMessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox1.Enabled = false;
                XoaTextBox();
                LoadTable();
            }
            else
            {
                XtraMessageBox.Show("Thêm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}