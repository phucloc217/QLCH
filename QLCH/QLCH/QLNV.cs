using DevExpress.XtraBars;
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
using DTO;
using System.Security.Cryptography;

namespace QLCH
{
    public partial class QLNV : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private NhanVien_BUS nvb = new NhanVien_BUS();
        private int trangthai = 0;
        public QLNV()
        {
            InitializeComponent();
        }

        private void QLNV_Load(object sender, EventArgs e)
        {
             LoadTable();
        }

        private void LoadTable()
        {
            gridControl1.DataSource = nvb.LoadNhanVien();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            barButtonItem2.Enabled = false;
            groupBox1.Enabled = true;
            txt_MatKhau.Visible = true;
            lb_MatKhau.Visible = true;
            txt_HoTen.Text = "";
            txt_MaNV.Text = nvb.TaoMaNV();
            txt_MatKhau.Text = "";
            trangthai = 1;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            barButtonItem1.Enabled = true;
            barButtonItem2.Enabled = true;
            groupBox1.Enabled = false;
            XoaTextBox();
        }

        private void XoaTextBox()
        {
            txt_MatKhau.Visible = false;
            lb_MatKhau.Visible = false;
            txt_HoTen.Text = "";
            txt_MaNV.Text = "";
            txt_MatKhau.Text = "";
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            barButtonItem2.Enabled = true;
            btn_xoa.Enabled = true;
            groupBox1.Enabled = false;
            txt_HoTen.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["hoten"]).ToString(); 
            txt_MaNV.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["manv"]).ToString();
            if (bool.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["loainv"]).ToString()))
                cb_loaiNV.SelectedIndex =1;
            else
                cb_loaiNV.SelectedIndex = 0;
            txt_MatKhau.Text = "";
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_MaNV.Text))
            {
                groupBox1.Enabled = true;
                trangthai = 2;
            }
        }
        private string MaHoa(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.Manv = txt_MaNV.Text.Trim();
            nv.Hoten = txt_HoTen.Text;
            nv.Loainv =  Convert.ToBoolean(cb_loaiNV.SelectedIndex);
            nv.Matkhau = MaHoa(txt_MatKhau.Text);
            if (trangthai == 1) 
            {
               if( nvb.ThemNV(nv))
                {
                    XtraMessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox1.Enabled = false;
                    XoaTextBox();
                    LoadTable();
                }    
               else
                {
                    XtraMessageBox.Show("Thêm không thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }    
            }   
            else if(trangthai==2)
            {
                if(nvb.CapNhatNV(nv))
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

        private void btn_xoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_MaNV.Text))
            {
             DialogResult dl =  XtraMessageBox.Show("Bạn có chắc muốn xóa nhân viên " + txt_MaNV.Text.Trim() + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dl == DialogResult.Yes)
                {
                    if (nvb.XoaNV(txt_MaNV.Text.Trim()))
                    {
                        XtraMessageBox.Show("Xóa nhân viên "+ txt_MaNV.Text.Trim()+" thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_resetPass_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_MaNV.Text))
            {
                DialogResult dl = XtraMessageBox.Show("Bạn có chắc muốn đặt lại mật khẩu của nhân viên "+ txt_MaNV.Text.Trim()+" không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    if (nvb.CapNhatMK(txt_MaNV.Text.Trim(),MaHoa(txt_MaNV.Text.Trim())))
                    {
                        XtraMessageBox.Show("Đặt lại mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        groupBox1.Enabled = false;
                        XoaTextBox();
                        LoadTable();
                    }
                    else
                    {
                        XtraMessageBox.Show("Đặt lại mật khẩu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void QLNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}