using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDuAn_K70
{

    public partial class Form_NV : Form
    {
        NhanVienBLL bllNV;
        DM_NhanVien nv = new DM_NhanVien();
        public Form_NV()
        {
            InitializeComponent();
            bllNV = new NhanVienBLL();
            ShowALLNhanVien();
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle rc = ClientRectangle;
            if (rc.IsEmpty)
                return;
            if (rc.Width == 0 || rc.Height == 0)

                return;
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.White, Color.FromArgb(196, 232, 250), 90F))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
        }
        public void ShowALLNhanVien()
        {
            DataTable dt = bllNV.getALLNhanVien();
            dataGridView_NhanVien.DataSource = dt;
        }

        private void QLNV_Load(object sender, EventArgs e)
        {
            ShowALLNhanVien();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            ChiTiet_NV f = new ChiTiet_NV(1,nv);
            f.UpdateEventHandler += F3_UpdateEventHandler1;
            f.Text = "Thêm mới";
            f.Show();
        }
        private void F3_UpdateEventHandler1(object sender, ChiTiet_NV.UpdateEventArgs args)
        {
            dataGridView_NhanVien.DataSource = bllNV.getALLNhanVien();
        }

        private void dataGridView_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                nv.MaNV = dataGridView_NhanVien.Rows[index].Cells["MaNV"].Value.ToString().Trim();
                nv.TenNV = dataGridView_NhanVien.Rows[index].Cells["TenNV"].Value.ToString().Trim();
            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            ChiTiet_NV f3 = new ChiTiet_NV(3, nv);
            f3.UpdateEventHandler += F3_UpdateEventHandler1;
            f3.Text = "Xem chi tiết";
            f3.Show();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            ChiTiet_NV f2 = new ChiTiet_NV(2, nv);
            f2.UpdateEventHandler += F3_UpdateEventHandler1;
            f2.Text = "Sửa";
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllNV.FindNhanVien(value);
                dataGridView_NhanVien.DataSource = dt;
            }
            else
          if (tbTimKiem.Text == null || tbTimKiem.Text == "")
                ShowALLNhanVien();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllNV.FindNhanVien(value);
                dataGridView_NhanVien.DataSource = dt;
            }
        }

        string Ma;

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Ma =  nv.MaNV;
                if (bllNV.DeleteNhanVien(nv))
                    ShowALLNhanVien();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
