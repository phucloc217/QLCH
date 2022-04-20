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
using DevExpress.XtraEditors;

namespace QLCH
{
    public partial class QLNguoiThue : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private KhachThue_BUS ktb = new KhachThue_BUS();
        private int trangthai = 0;
        public QLNguoiThue()
        {
            InitializeComponent();
        }

        private void QLNguoiThue_Load(object sender, EventArgs e)
        {
            CanHo_BUS chb = new CanHo_BUS();
            lk_canho.Properties.DataSource = chb.LoadLKCanHo();
            lk_canho.ItemIndex = 0;
            LoadTable();
        }

        private void LoadTable()
        {
            gridControl1.DataSource = ktb.LoadKhachThue();
        }

        private void XoaTextBox()
        {
            btn_sua.Enabled = true;
            btn_them.Enabled = true;
            btn_xoa.Enabled = true;
            lk_canho.ItemIndex = 0;
            txt_hoten.Text = "";
            txt_sdt.Text = "";
            txt_cccd.Text = "";
            txt_ma.Text = "";
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            XoaTextBox();
            trangthai = 0;
        }

        private void btn_them_ItemClick(object sender, ItemClickEventArgs e)
        {
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            groupBox1.Enabled = true;
            XoaTextBox();
            txt_ma.Text = ktb.TaoMaKH();
            this.trangthai = 1;
        }

        private void btn_sua_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_ma.Text))
            {
                groupBox1.Enabled = true;
                trangthai = 2;
            }
        }

        private void btn_xoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_ma.Text))
            {
                DialogResult dl = XtraMessageBox.Show("Bạn có chắc muốn xóa người thuê " + txt_ma.Text.Trim() + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    if (ktb.XoaKH(txt_ma.Text.Trim()))
                    {
                        XtraMessageBox.Show("Xóa người thuê " + txt_ma.Text.Trim() + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_dongy_Click(object sender, EventArgs e)
        {
            bool flag = true;
            NguoiThue nt = new NguoiThue();
            nt.Ma = txt_ma.Text;
            nt.Hoten = txt_hoten.Text;
            nt.Cccd = txt_cccd.Text;
            nt.Sdt = txt_sdt.Text;
            nt.Mach = lk_canho.EditValue.ToString();
            if(string.IsNullOrEmpty(nt.Hoten))
            {
                XtraMessageBox.Show("Bạn phải nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = false;
            }
            if (trangthai == 1 && flag == true) 
            {
                if (ktb.ThemKH(nt))
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
            else if (trangthai == 2 && flag == true)
            {
                if (ktb.CapNhatKH(nt))
                {
                    XtraMessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            btn_sua.Enabled = true;
            groupBox1.Enabled = false;
            txt_hoten.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["hoten"]).ToString();
            txt_cccd.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["cccd"]).ToString();
            txt_sdt.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["sodt"]).ToString();
            int i = 0;
            DataTable dt = lk_canho.Properties.DataSource as DataTable;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["mach"].ToString() == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["mach"]).ToString())
                   break;
            }
            lk_canho.ItemIndex = i;
            txt_ma.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["mant"]).ToString();
        }
    }
}