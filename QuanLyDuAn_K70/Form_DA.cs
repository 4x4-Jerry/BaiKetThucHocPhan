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

    public partial class Form_DA : Form
    {
        bool check = true;
        DuAnBLL bllDA;
        DM_DuAn duan = new DM_DuAn();
        public Form_DA()
        {
            InitializeComponent();
            bllDA = new DuAnBLL();
            ShowALLDuAn();
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
        public void ShowALLDuAn()
        {
            DataTable dt = bllDA.getALLDuAn();
            dataGridView_DuAn.DataSource = dt;
        }

        private void QLDA_Load(object sender, EventArgs e)
        {
            ShowALLDuAn();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            ChiTiet_DA f = new ChiTiet_DA(1, duan);
            f.UpdateEventHandler += F3_UpdateEventHandler1;
            f.Text = "Thêm mới";
            f.Show();
        }
        private void F3_UpdateEventHandler1(object sender, ChiTiet_DA.UpdateEventArgs args)
        {
            dataGridView_DuAn.DataSource = bllDA.getALLDuAn();
        }

        private void dataGridView_DuAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                duan.MaDA = dataGridView_DuAn.Rows[index].Cells["MaDA"].Value.ToString().Trim();
                duan.TenDA = dataGridView_DuAn.Rows[index].Cells["TenDA"].Value.ToString().Trim();
                duan.MaKH = dataGridView_DuAn.Rows[index].Cells["MaKH"].Value.ToString().Trim();
                duan.TenKH = dataGridView_DuAn.Rows[index].Cells["TenKH"].Value.ToString().Trim();
                duan.TenBP = dataGridView_DuAn.Rows[index].Cells["TenBP"].Value.ToString().Trim();
                duan.TenNDA = dataGridView_DuAn.Rows[index].Cells["TenNDA"].Value.ToString().Trim();
                duan.TenCN = dataGridView_DuAn.Rows[index].Cells["TenCN"].Value.ToString().Trim();
                duan.TenNV = dataGridView_DuAn.Rows[index].Cells["TenNV"].Value.ToString().Trim();
                duan.MaNV = dataGridView_DuAn.Rows[index].Cells["MaNV"].Value.ToString().Trim();
                duan.MaBP = dataGridView_DuAn.Rows[index].Cells["MaBP"].Value.ToString().Trim();
                duan.MaCN = dataGridView_DuAn.Rows[index].Cells["MaCN"].Value.ToString().Trim();
                duan.GiaTriDA = dataGridView_DuAn.Rows[index].Cells["GiaTriDA"].Value.ToString().Trim();
                duan.MaNDA = dataGridView_DuAn.Rows[index].Cells["MaNDA"].Value.ToString().Trim();
                duan.StartDay = dataGridView_DuAn.Rows[index].Cells["StartDay"].Value.ToString().Trim();
                duan.FinalDay = dataGridView_DuAn.Rows[index].Cells["FinalDay"].Value.ToString().Trim();
                duan.GhiChu = dataGridView_DuAn.Rows[index].Cells["GhiChu"].Value.ToString().Trim();
            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            ChiTiet_DA f3 = new ChiTiet_DA(3, duan);
            f3.UpdateEventHandler += F3_UpdateEventHandler1;
            f3.Text = "Xem chi tiết";
            f3.Show();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            ChiTiet_DA f2 = new ChiTiet_DA(2, duan);
            f2.UpdateEventHandler += F3_UpdateEventHandler1;
            f2.Text = "Sửa";
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllDA.FindDuAn(value);
                dataGridView_DuAn.DataSource = dt;
            }
            else
          if (tbTimKiem.Text == null || tbTimKiem.Text == "")
                ShowALLDuAn();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllDA.FindDuAn(value);
                dataGridView_DuAn.DataSource = dt;
            }
        }

        string Ma;

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bllDA.CheckDuAnPhatSinh(duan.MaDA.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Mã dự án đã phát sinh, không thể thay đổi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                check = false;
            }
            if(check == true) { 
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Ma = duan.MaKH;
                if (bllDA.DeleteDuAn(duan))
                    ShowALLDuAn();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
