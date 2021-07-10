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

    public partial class Form_NP : Form
    {
        bool check = true;
        NhapPhiBLL bllNP;
        DM_NhapPhi np = new DM_NhapPhi();
        public Form_NP()
        {
            InitializeComponent();
            bllNP = new NhapPhiBLL();
            ShowALLNhapPhi();
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
        public void ShowALLNhapPhi()
        {
            DataTable dt = bllNP.getALLNhapPhi();
            dataGridView_NhapPhi.DataSource = dt;
        }

        private void QLNP_Load(object sender, EventArgs e)
        {
            ShowALLNhapPhi();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            ChiTiet_NP f = new ChiTiet_NP(1,np);
            f.UpdateEventHandler += F3_UpdateEventHandler1;
            f.Text = "Thêm mới";
            f.Show();
        }
        private void F3_UpdateEventHandler1(object sender, ChiTiet_NP.UpdateEventArgs args)
        {
            dataGridView_NhapPhi.DataSource = bllNP.getALLNhapPhi();
        }

        private void dataGridView_NhapPhi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                np.MaDA = dataGridView_NhapPhi.Rows[index].Cells["MaDA"].Value.ToString().Trim();
                np.MaPhi = dataGridView_NhapPhi.Rows[index].Cells["MaPhi"].Value.ToString().Trim();
                np.ChiPhi = dataGridView_NhapPhi.Rows[index].Cells["ChiPhi"].Value.ToString().Trim();
                np.TenPhi = dataGridView_NhapPhi.Rows[index].Cells["TenPhi"].Value.ToString().Trim();
                np.TenDA = dataGridView_NhapPhi.Rows[index].Cells["TenDA"].Value.ToString().Trim();
            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            ChiTiet_NP f3 = new ChiTiet_NP(3, np);
            f3.UpdateEventHandler += F3_UpdateEventHandler1;
            f3.Text = "Xem chi tiết";
            f3.Show();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            ChiTiet_NP f2 = new ChiTiet_NP(2, np);
            f2.UpdateEventHandler += F3_UpdateEventHandler1;
            f2.Text = "Sửa";
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllNP.FindNhapPhi(value);
                dataGridView_NhapPhi.DataSource = dt;
            }
            else
          if (tbTimKiem.Text == null || tbTimKiem.Text == "")
                ShowALLNhapPhi();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllNP.FindNhapPhi(value);
                dataGridView_NhapPhi.DataSource = dt;
            }
        }

        string Ma;

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bllNP.CheckDuAnPhatSinh(np.MaDA.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Dự án đã được cập nhật chi phí rồi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                check = false;
            }
            if (check == true)
            {
                if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Ma = np.MaDA;
                    if (bllNP.DeleteNhapPhi(np))
                        ShowALLNhapPhi();
                    else
                        MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
            }
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
