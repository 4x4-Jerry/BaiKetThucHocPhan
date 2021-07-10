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

    public partial class Form_NDA : Form
    {
        NhomDuAnBLL bllNDA;
        DM_NhomDuAn nda = new DM_NhomDuAn();
        public Form_NDA()
        {
            InitializeComponent();
            bllNDA = new NhomDuAnBLL();
            ShowALLNhomDuAn();
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
        public void ShowALLNhomDuAn()
        {
            DataTable dt = bllNDA.getALLNhomDuAn();
            dataGridView_NhomDuAn.DataSource = dt;
        }

        private void QLNDA_Load(object sender, EventArgs e)
        {
            ShowALLNhomDuAn();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            ChiTiet_NDA f = new ChiTiet_NDA(1, nda);
            f.UpdateEventHandler += F3_UpdateEventHandler1;
            f.Text = "Thêm mới";
            f.Show();
        }
        private void F3_UpdateEventHandler1(object sender, ChiTiet_NDA.UpdateEventArgs args)
        {
            dataGridView_NhomDuAn.DataSource = bllNDA.getALLNhomDuAn();
        }

        private void dataGridView_NhomDuAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                nda.MaNDA = dataGridView_NhomDuAn.Rows[index].Cells["MaNDA"].Value.ToString().Trim();
                nda.TenNDA = dataGridView_NhomDuAn.Rows[index].Cells["TenNDA"].Value.ToString().Trim();
            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            ChiTiet_NDA f3 = new ChiTiet_NDA(3, nda);
            f3.UpdateEventHandler += F3_UpdateEventHandler1;
            f3.Text = "Xem chi tiết";
            f3.Show();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            ChiTiet_NDA f2 = new ChiTiet_NDA(2, nda);
            f2.UpdateEventHandler += F3_UpdateEventHandler1;
            f2.Text = "Sửa";
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllNDA.FindNhomDuAn(value);
                dataGridView_NhomDuAn.DataSource = dt;
            }
            else
          if (tbTimKiem.Text == null || tbTimKiem.Text == "")
                ShowALLNhomDuAn();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllNDA.FindNhomDuAn(value);
                dataGridView_NhomDuAn.DataSource = dt;
            }
        }

        string Ma;

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Ma = nda.MaNDA;
                if (bllNDA.DeleteNhomDuAn(nda))
                    ShowALLNhomDuAn();
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
