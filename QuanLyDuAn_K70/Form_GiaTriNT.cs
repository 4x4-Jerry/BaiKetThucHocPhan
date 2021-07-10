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

    public partial class Form_GiaTriNT : Form
    {
        bool check = true;
        GiaTriNTBLL bllGTNT;
        DM_GiaTriNT gt = new DM_GiaTriNT();
        public Form_GiaTriNT()
        {
            InitializeComponent();
            bllGTNT = new GiaTriNTBLL();
            ShowALLGiaTriNT();
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
        public void ShowALLGiaTriNT()
        {
            DataTable dt = bllGTNT.getALLGiaTriNT();
            dataGridView_GiaTriNT.DataSource = dt;
        }

        private void QLGTNT_Load(object sender, EventArgs e)
        {
            ShowALLGiaTriNT();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            ChiTiet_GiaTriNT f = new ChiTiet_GiaTriNT(1,gt);
            f.UpdateEventHandler += F3_UpdateEventHandler1;
            f.Text = "Thêm mới";
            f.Show();
        }
        private void F3_UpdateEventHandler1(object sender, ChiTiet_GiaTriNT.UpdateEventArgs args)
        {
            dataGridView_GiaTriNT.DataSource = bllGTNT.getALLGiaTriNT();
        }

        private void dataGridView_GiaTriNT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                gt.MaDA = dataGridView_GiaTriNT.Rows[index].Cells["MaDa"].Value.ToString().Trim();
                gt.MaGD = dataGridView_GiaTriNT.Rows[index].Cells["MaGD"].Value.ToString().Trim();
                gt.StartDayGD = dataGridView_GiaTriNT.Rows[index].Cells["StartDayGD"].Value.ToString().Trim();
                gt.FinalDayGD = dataGridView_GiaTriNT.Rows[index].Cells["FinalDayGD"].Value.ToString().Trim();
                gt.GiaTriNT = dataGridView_GiaTriNT.Rows[index].Cells["GiaTriNT"].Value.ToString().Trim();
                gt.TenGD = dataGridView_GiaTriNT.Rows[index].Cells["TenGD"].Value.ToString().Trim();
                gt.TenDA = dataGridView_GiaTriNT.Rows[index].Cells["TenDA"].Value.ToString().Trim();
            }
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            ChiTiet_GiaTriNT f3 = new ChiTiet_GiaTriNT(3, gt);
            f3.UpdateEventHandler += F3_UpdateEventHandler1;
            f3.Text = "Xem chi tiết";
            f3.Show();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            ChiTiet_GiaTriNT f2 = new ChiTiet_GiaTriNT(2, gt);
            f2.UpdateEventHandler += F3_UpdateEventHandler1;
            f2.Text = "Sửa";
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllGTNT.FindGiaTriNT(value);
                dataGridView_GiaTriNT.DataSource = dt;
            }
            else
          if (tbTimKiem.Text == null || tbTimKiem.Text == "")
                ShowALLGiaTriNT();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllGTNT.FindGiaTriNT(value);
                dataGridView_GiaTriNT.DataSource = dt;
            }
        }

        string Ma;

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bllGTNT.CheckDuAnPhatSinh(gt.MaDA.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Dự án đã phát sinh chi phí, không thể sửa ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                check = false;
            }
            if (check == true)
            {
                if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Ma = gt.MaGD;
                    if (bllGTNT.DeleteGiaTriNT(gt))
                        ShowALLGiaTriNT();
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
