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
    public partial class QLLau : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private Lau_BUS lb = new BUS.Lau_BUS();
        private int trangthai = 0;
        public QLLau()
        {
            InitializeComponent();
        }
        
        private void QLLau_Load(object sender, EventArgs e)
        {
            LoadTable();
        }
        private void LoadTable()
        {
            gridControl1.DataSource = lb.LoadLau();
        }

        private void XoaTextBox()
        {
            txt_ma.Text = "";
            txt_ten.Text = "";
            rd_mota.Text = "";
        }

        private void btn_them_ItemClick(object sender, ItemClickEventArgs e)
        {
            btn_sua.Enabled = false;
            groupBox1.Enabled = true;
            txt_ten.Text = "";
            txt_ma.Text = lb.TaoID();
            rd_mota.Text = "";
            trangthai = 1;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            Lau lau = new Lau
            {
                Ma = int.Parse(txt_ma.Text),
                Ten = txt_ten.Text,
                Mota = rd_mota.Text
            };
            if (trangthai == 1)
            {
                if (lb.ThemLau(lau))
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
            else if (trangthai == 2)
            {
                if (lb.CapNhatLau(lau))
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
            else
            {

            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            btn_sua.Enabled = true;
            groupBox1.Enabled = false;
            txt_ma.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["id"]).ToString();
            txt_ten.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["tenlau"]).ToString();
            rd_mota.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["mota"]).ToString();
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            btn_them.Enabled = true;
            btn_sua.Enabled = true;
            groupBox1.Enabled = false;
            XoaTextBox();
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
                DialogResult dl = XtraMessageBox.Show("Bạn có chắc muốn xóa " + txt_ten.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    if (lb.XoaLau(txt_ma.Text.Trim()))
                    {
                        XtraMessageBox.Show("Xóa " + txt_ten.Text + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}