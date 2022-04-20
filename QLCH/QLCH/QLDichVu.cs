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
using BUS;
using DevExpress.XtraEditors;

namespace QLCH
{
    public partial class QLDichVu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private LoaiHoaDon_BUS lhdb = new LoaiHoaDon_BUS();
        private int trangthai = 0;
        public QLDichVu()
        {
            InitializeComponent();
        }
        private void QLDichVu_Load(object sender, EventArgs e)
        {

            LoadTable();
        }
        private void LoadTable()
        {
            gridControl1.DataSource = lhdb.LoaiLoaiHD();
        }
        private void XoaTextBox()
        {
            btn_sua.Enabled = true;
            btn_them.Enabled = true;
            btn_xoa.Enabled = true;
            txt_ma.Text = "";
            txt_ten.Text = "";
            txt_dongia.Text = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            XoaTextBox();
            trangthai = 0;
        }

        private void btn_them_ItemClick(object sender, ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            btn_xoa.Enabled = false;
            XoaTextBox();
            txt_ma.Text = lhdb.TaoMaLoai();
            trangthai = 1;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (string.IsNullOrEmpty(txt_ten.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập tên dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = false;
                return;
            }
            if (string.IsNullOrEmpty(txt_dongia.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = false;
                return;
            }
          
            LoaiHoaDon lhd = new LoaiHoaDon();
            lhd.Ma = int.Parse(txt_ma.Text) ;
            lhd.Tenloai = txt_ten.Text;
            lhd.Dongia = int.Parse(txt_dongia.Text);
            
            if (trangthai == 1 && flag == true)
            {
                if (lhdb.ThemLoai(lhd))
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
                if (lhdb.CapNhatLHD(lhd))
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
                DialogResult dl = XtraMessageBox.Show("Bạn có chắc muốn loại hóa đơn " + txt_ma.Text.Trim() + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    if (lhdb.XoaLHD(txt_ma.Text.Trim()))
                    {
                        XtraMessageBox.Show("Xóa loại hóa đơn " + txt_ma.Text.Trim() + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            btn_sua.Enabled = true;
            groupBox1.Enabled = false;
            txt_ma.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["maloai"]).ToString();
            txt_ten.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["tenloai"]).ToString();
            txt_dongia.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["dongia"]).ToString();
        }

    }
}