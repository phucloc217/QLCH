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
using DTO;
using BUS;
using DevExpress.XtraEditors;
using System.Collections;

namespace QLCH
{
    public partial class QLCanHo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private CanHo_BUS chb = new CanHo_BUS();
        private int trangthai = 0;
        public QLCanHo()
        {
            InitializeComponent();
        }

        private void QLCanHo_Load(object sender, EventArgs e)
        {
            Lau_BUS lb = new Lau_BUS();
            lk_tang.Properties.DataSource = lb.LoadLau();
            lk_tang.ItemIndex = 0;
            XoaTextBox();
            LoadTable();
        }
        private void LoadTable()
        {
            gridControl1.DataSource = chb.LoadCanHo();
        }
        private void XoaTextBox()
        {
            btn_sua.Enabled = true;
            btn_them.Enabled = true;
            btn_xoa.Enabled = true;
            lk_tang.ItemIndex = 0;
            
            txt_dientich.Text = "";
            txt_gia.Text = "";
            rd_mota.Text = "";
            txt_ma.Text = "";
        }
        private void txt_gia_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txt_dientich_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btn_them_ItemClick(object sender, ItemClickEventArgs e)
        {
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            groupBox1.Enabled = true;
            XoaTextBox();
            txt_ma.Text = chb.TaoMaCH(int.Parse(lk_tang.EditValue.ToString()));
            this.trangthai = 1;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            XoaTextBox();
        }

        private void lk_tang_EditValueChanged(object sender, EventArgs e)
        {
            txt_ma.Text = chb.TaoMaCH(int.Parse(lk_tang.EditValue.ToString()));
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            CanHo ch = new CanHo();
            ch.Ma = txt_ma.Text;
            ch.Dientich = float.Parse(txt_dientich.Text);
            ch.Gia = int.Parse(txt_gia.Text);
            ch.Tang = int.Parse(lk_tang.EditValue.ToString());
            ch.Mota = rd_mota.Text;
            if (trangthai==1)
            {
                if (chb.ThemCH(ch))
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
            } if(trangthai ==2 )
            {
                if (chb.CapNhatCH(ch))
                {
                    XtraMessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox1.Enabled = false;
                    XoaTextBox();
                    LoadTable();
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DialogResult dl = XtraMessageBox.Show("Bạn có chắc muốn xóa căn hộ " + txt_ma.Text.Trim() + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    if (chb.XoaCH(txt_ma.Text.Trim()))
                    {
                        XtraMessageBox.Show("Xóa căn hộ " + txt_ma.Text.Trim() + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txt_dientich.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["dientich"]).ToString();
            txt_gia.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["gia"]).ToString();          
            int i = 0;
            DataTable dt = lk_tang.Properties.DataSource as DataTable;
            for (i = 0; i < dt.Rows.Count; i++) 
            {
               
                if (dt.Rows[i]["id"].ToString() == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["tang"]).ToString())
                    break;
            }
            lk_tang.ItemIndex = i;
            rd_mota.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["mota"]).ToString();
            txt_ma.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["mach"]).ToString();
        }
    }
}