using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDuAn_K70
{

    public partial class QLBP : Form
    {
        BoPhanBLL bllBP;
        DM_BoPhan bp = new DM_BoPhan();
        public QLBP()
        {
            InitializeComponent();
            bllBP = new BoPhanBLL();
            ShowALLBoPhan();
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
        public void ShowALLBoPhan()
        {
            DataTable dt = bllBP.getALLBoPhan();
            dataGridView_BoPhan.DataSource = dt;
        }

        private void QLBP_Load(object sender, EventArgs e)
        {
            ShowALLBoPhan();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            ChiTiet_BP f = new ChiTiet_BP(1, bp);
            f.UpdateEventHandler += F3_UpdateEventHandler1;
            f.Text = "Thêm mới";
            f.Show();
        }
        private void F3_UpdateEventHandler1(object sender, ChiTiet_BP.UpdateEventArgs args)
        {
            dataGridView_BoPhan.DataSource = bllBP.getALLBoPhan();
        }

        private void dataGridView_BoPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                bp.MaBP = dataGridView_BoPhan.Rows[index].Cells["MaBP"].Value.ToString().Trim();
                bp.TenBP = dataGridView_BoPhan.Rows[index].Cells["TenBP"].Value.ToString().Trim();
            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            ChiTiet_BP f3 = new ChiTiet_BP(3, bp);
            f3.UpdateEventHandler += F3_UpdateEventHandler1;
            f3.Text = "Xem chi tiết";
            f3.Show();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            ChiTiet_BP f2 = new ChiTiet_BP(2, bp);
            f2.UpdateEventHandler += F3_UpdateEventHandler1;
            f2.Text = "Sửa";
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllBP.FindBoPhan(value);
                dataGridView_BoPhan.DataSource = dt;
            }
            else
          if (tbTimKiem.Text == null || tbTimKiem.Text == "")
                ShowALLBoPhan();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllBP.FindBoPhan(value);
                dataGridView_BoPhan.DataSource = dt;
            }
        }

        string Ma;

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Ma = bp.MaBP;
                if (bllBP.DeleteBoPhan(bp))
                    ShowALLBoPhan();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView_BoPhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
