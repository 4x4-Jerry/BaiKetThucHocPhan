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

    public partial class Form_GD : Form
    {
        GiaiDoanBLL bllGD;
        DM_GiaiDoan gd = new DM_GiaiDoan();
        public Form_GD()
        {
            InitializeComponent();
            bllGD = new GiaiDoanBLL();
            ShowALLGiaiDoan();
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
        public void ShowALLGiaiDoan()
        {
            DataTable dt = bllGD.getALLGiaiDoan();
            dataGridView_GiaiDoan.DataSource = dt;
        }

        private void QLGD_Load(object sender, EventArgs e)
        {
            ShowALLGiaiDoan();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            ChiTiet_GD f = new ChiTiet_GD(1,gd);
            f.UpdateEventHandler += F3_UpdateEventHandler1;
            f.Text = "Thêm mới";
            f.Show();
        }
        private void F3_UpdateEventHandler1(object sender, ChiTiet_GD.UpdateEventArgs args)
        {
            dataGridView_GiaiDoan.DataSource = bllGD.getALLGiaiDoan();
        }

        private void dataGridView_GiaiDoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                gd.MaGD = dataGridView_GiaiDoan.Rows[index].Cells["MaGD"].Value.ToString().Trim();
                gd.TenGD = dataGridView_GiaiDoan.Rows[index].Cells["TenGD"].Value.ToString().Trim();
            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            ChiTiet_GD f3 = new ChiTiet_GD(3, gd);
            f3.UpdateEventHandler += F3_UpdateEventHandler1;
            f3.Text = "Xem chi tiết";
            f3.Show();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            ChiTiet_GD f2 = new ChiTiet_GD(2, gd);
            f2.UpdateEventHandler += F3_UpdateEventHandler1;
            f2.Text = "Sửa";
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllGD.FindGiaiDoan(value);
                dataGridView_GiaiDoan.DataSource = dt;
            }
            else
          if (tbTimKiem.Text == null || tbTimKiem.Text == "")
                ShowALLGiaiDoan();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllGD.FindGiaiDoan(value);
                dataGridView_GiaiDoan.DataSource = dt;
            }
        }

        string Ma;

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Ma =  gd.MaGD;
                if (bllGD.DeleteGiaiDoan(gd))
                    ShowALLGiaiDoan();
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
