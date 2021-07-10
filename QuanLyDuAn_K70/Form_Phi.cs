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

    public partial class Form_Phi : Form
    {
        PhiBLL bllPhi;
        DM_Phi phi = new DM_Phi();
        public Form_Phi()
        {
            InitializeComponent();
            bllPhi = new PhiBLL();
            ShowALLPhi();
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
        public void ShowALLPhi()
        {
            DataTable dt = bllPhi.getALLPhi();
            dataGridView_Phi.DataSource = dt;
        }

        private void QLPhi_Load(object sender, EventArgs e)
        {
            ShowALLPhi();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            ChiTiet_Phi f = new ChiTiet_Phi(1,phi);
            f.UpdateEventHandler += F3_UpdateEventHandler1;
            f.Text = "Thêm mới";
            f.Show();
        }
        private void F3_UpdateEventHandler1(object sender, ChiTiet_Phi.UpdateEventArgs args)
        {
            dataGridView_Phi.DataSource = bllPhi.getALLPhi();
        }

        private void dataGridView_Phi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                phi.MaPhi = dataGridView_Phi.Rows[index].Cells["MaPhi"].Value.ToString().Trim();
                phi.TenPhi = dataGridView_Phi.Rows[index].Cells["TenPhi"].Value.ToString().Trim();
            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            ChiTiet_Phi f3 = new ChiTiet_Phi(3, phi);
            f3.UpdateEventHandler += F3_UpdateEventHandler1;
            f3.Text = "Xem chi tiết";
            f3.Show();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            ChiTiet_Phi f2 = new ChiTiet_Phi(2, phi);
            f2.UpdateEventHandler += F3_UpdateEventHandler1;
            f2.Text = "Sửa";
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllPhi.FindPhi(value);
                dataGridView_Phi.DataSource = dt;
            }
            else
          if (tbTimKiem.Text == null || tbTimKiem.Text == "")
                ShowALLPhi();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllPhi.FindPhi(value);
                dataGridView_Phi.DataSource = dt;
            }
        }

        string Ma;

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Ma =  phi.MaPhi;
                if (bllPhi.DeletePhi(phi))
                    ShowALLPhi();
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
