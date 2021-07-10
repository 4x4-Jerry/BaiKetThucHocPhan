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

    public partial class Form_KH : Form
    {
        KhachHangBLL bllKH;
        DM_KhachHang kh = new DM_KhachHang();
        public Form_KH()
        {
            InitializeComponent();
            bllKH = new KhachHangBLL();
            ShowALLKhachHang();
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
        public void ShowALLKhachHang()
        {
            DataTable dt = bllKH.getALLKhachHang();
            dataGridView_KhachHang.DataSource = dt;
        }

        private void QLKH_Load(object sender, EventArgs e)
        {
            ShowALLKhachHang();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            ChiTiet_KH f = new ChiTiet_KH(1,kh);
            f.UpdateEventHandler += F3_UpdateEventHandler1;
            f.Text = "Thêm mới";
            f.Show();
        }
        private void F3_UpdateEventHandler1(object sender, ChiTiet_KH.UpdateEventArgs args)
        {
            dataGridView_KhachHang.DataSource = bllKH.getALLKhachHang();
        }

        private void dataGridView_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                kh.MaKH = dataGridView_KhachHang.Rows[index].Cells["MaKH"].Value.ToString().Trim();
                kh.TenKH = dataGridView_KhachHang.Rows[index].Cells["TenKH"].Value.ToString().Trim();
                kh.DiaChi = dataGridView_KhachHang.Rows[index].Cells["DiaChi"].Value.ToString().Trim();
                kh.DoiTac = dataGridView_KhachHang.Rows[index].Cells["DoiTac"].Value.ToString().Trim();
                kh.DienThoai = dataGridView_KhachHang.Rows[index].Cells["DienThoai"].Value.ToString().Trim();
                kh.Email = dataGridView_KhachHang.Rows[index].Cells["Email"].Value.ToString().Trim();
                kh.Fax = dataGridView_KhachHang.Rows[index].Cells["Fax"].Value.ToString().Trim();
                kh.GhiChu = dataGridView_KhachHang.Rows[index].Cells["GhiChu"].Value.ToString().Trim();
            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            ChiTiet_KH f3 = new ChiTiet_KH(3, kh);
            f3.UpdateEventHandler += F3_UpdateEventHandler1;
            f3.Text = "Xem chi tiết";
            f3.Show();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            ChiTiet_KH f2 = new ChiTiet_KH(2, kh);
            f2.UpdateEventHandler += F3_UpdateEventHandler1;
            f2.Text = "Sửa";
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllKH.FindKhachHang(value);
                dataGridView_KhachHang.DataSource = dt;
            }
            else
          if (tbTimKiem.Text == null || tbTimKiem.Text == "")
                ShowALLKhachHang();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllKH.FindKhachHang(value);
                dataGridView_KhachHang.DataSource = dt;
            }
        }

        string Ma;

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Ma =  kh.MaKH;
                if (bllKH.DeleteKhachHang(kh))
                    ShowALLKhachHang();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
