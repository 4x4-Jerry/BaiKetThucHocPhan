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

    public partial class Form_SDDK : Form
    {
        bool check = true;
        SoDuDauKyBLL bllSDDK;
        DM_SoDuDauKy sd = new DM_SoDuDauKy();
        public Form_SDDK()
        {
            InitializeComponent();
            bllSDDK = new SoDuDauKyBLL();
            ShowALLSoDuDauKy();
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
        public void ShowALLSoDuDauKy()
        {
            DataTable dt = bllSDDK.getALLSoDuDauKy();
            dataGridView_SoDuDauKy.DataSource = dt;
        }

        private void QLSDDK_Load(object sender, EventArgs e)
        {
            ShowALLSoDuDauKy();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            ChiTiet_SDDK f = new ChiTiet_SDDK(1,sd);
            f.UpdateEventHandler += F3_UpdateEventHandler1;
            f.Text = "Thêm mới";
            f.Show();
        }
        private void F3_UpdateEventHandler1(object sender, ChiTiet_SDDK.UpdateEventArgs args)
        {
            dataGridView_SoDuDauKy.DataSource = bllSDDK.getALLSoDuDauKy();
        }

        private void dataGridView_SoDuDauKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                sd.MaDA = dataGridView_SoDuDauKy.Rows[index].Cells["MaDA"].Value.ToString().Trim();
                sd.MaKH = dataGridView_SoDuDauKy.Rows[index].Cells["MaKH"].Value.ToString().Trim();
                sd.TenKH = dataGridView_SoDuDauKy.Rows[index].Cells["TenKH"].Value.ToString().Trim();
                sd.TenDA = dataGridView_SoDuDauKy.Rows[index].Cells["TenDA"].Value.ToString().Trim();
                sd.GiaTriBD = dataGridView_SoDuDauKy.Rows[index].Cells["GiaTriBD"].Value.ToString().Trim();
            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            ChiTiet_SDDK f3 = new ChiTiet_SDDK(3, sd);
            f3.UpdateEventHandler += F3_UpdateEventHandler1;
            f3.Text = "Xem chi tiết";
            f3.Show();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            ChiTiet_SDDK f2 = new ChiTiet_SDDK(2, sd);
            f2.UpdateEventHandler += F3_UpdateEventHandler1;
            f2.Text = "Sửa";
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllSDDK.FindSoDuDauKy(value);
                dataGridView_SoDuDauKy.DataSource = dt;
            }
            else
          if (tbTimKiem.Text == null || tbTimKiem.Text == "")
                ShowALLSoDuDauKy();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllSDDK.FindSoDuDauKy(value);
                dataGridView_SoDuDauKy.DataSource = dt;
            }
        }

        string Ma;

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bllSDDK.CheckDuAnPhatSinh(sd.MaDA.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Dự án đã phát sinh chi phí, không thể sửa", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                check = false;
            }
            if (check == true)
            {
                if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Ma = sd.MaDA;
                    if (bllSDDK.DeleteSoDuDauKy(sd))
                        ShowALLSoDuDauKy();
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
