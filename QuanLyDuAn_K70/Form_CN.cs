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
    public partial class Form_CN : Form
    {
        ChiNhanhBLL bllCN;
        DM_ChiNhanh cn = new DM_ChiNhanh();
        public Form_CN()
        {

            InitializeComponent();
            bllCN = new ChiNhanhBLL();
            ShowALLChiNhanh();
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
        public void ShowALLChiNhanh()
        {
            DataTable dt = bllCN.getALLChiNhanh();
            dataGridView_ChiNhanh.DataSource = dt;
        }
        private void btThem_CN_Click(object sender, EventArgs e)
        {
            ChiTiet_CN f = new ChiTiet_CN(1, cn);
            f.UpdateEventHandler += F3_UpdateEventHandler1;
            f.Text = "Thêm mới";
            f.Show();
        }
        private void F3_UpdateEventHandler1(object sender, ChiTiet_CN.UpdateEventArgs args)
        {
            dataGridView_ChiNhanh.DataSource = bllCN.getALLChiNhanh();
        }
        string Ma;

        private void btSua_CN_Click_1(object sender, EventArgs e)
        {
            ChiTiet_CN f2 = new ChiTiet_CN(2, cn);
            f2.UpdateEventHandler += F3_UpdateEventHandler1;
            f2.Text = "Sửa";
            f2.Show();
        }

        private void btXem_CN_Click_1(object sender, EventArgs e)
        {
            ChiTiet_CN f3 = new ChiTiet_CN(3, cn);
            f3.UpdateEventHandler += F3_UpdateEventHandler1;
            f3.Text = "Xem chi tiết";
            f3.Show();
        }

        private void btXoa_CN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Ma = cn.MaCN;
                if (bllCN.DeleteChiNhanh(cn))
                    ShowALLChiNhanh();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void btTimKiem_CN_Click(object sender, EventArgs e)
        {
            string value = tbTimKiem_CN.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllCN.FindChiNhanh(value);
                dataGridView_ChiNhanh.DataSource = dt;
            }
        }

        private void tbTimKiem_CN_TextChanged_1(object sender, EventArgs e)
        {
            string value = tbTimKiem_CN.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllCN.FindChiNhanh(value);
                dataGridView_ChiNhanh.DataSource = dt;
            }
            else
          if (tbTimKiem_CN.Text == null || tbTimKiem_CN.Text == "")
                ShowALLChiNhanh();
        }

        private void dataGridView_ChiNhanh_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                cn.MaCN = dataGridView_ChiNhanh.Rows[index].Cells["MaCN"].Value.ToString().Trim();
                cn.TenCN = dataGridView_ChiNhanh.Rows[index].Cells["TenCN"].Value.ToString().Trim();
            }
        }

        private void Form_CN_Load(object sender, EventArgs e)
        {
            ShowALLChiNhanh();
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}

