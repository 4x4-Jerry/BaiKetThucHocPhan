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

    public partial class ChiTiet_GiaTriNT : Form
    {
        bool check = true;
        GiaTriNTBLL bllGTNT;
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        int IsThemSua = 0;
        DM_GiaTriNT Gt = new DM_GiaTriNT();
        public ChiTiet_GiaTriNT(int isThemSua, DM_GiaTriNT gt)
        {
            InitializeComponent();
            bllGTNT = new GiaTriNTBLL();
            IsThemSua = isThemSua;
            Gt = gt;
            if (IsThemSua == 1)
            {
                tbTenDA.Enabled = false;
                tbTenGD.Enabled = false;
            }
            else if (IsThemSua == 2)
            {
                tbTenDA.Enabled = false;
                tbTenGD.Enabled = false;
                cbMaDA.Text = Gt.MaDA;
                cbMaGD.Text = Gt.MaGD;
                tbTenGD.Text = Gt.TenGD;
                tbTenDA.Text = Gt.TenDA;
                tbGTNT.Text = Gt.GiaTriNT;
                dtStartDayGD.Text = String.Format("{0:yyyyMMdd}", Gt.StartDayGD);
                dtFinalDayGD.Text = String.Format("{0:yyyyMMdd}", Gt.FinalDayGD);
            }
            else if (IsThemSua == 3)
            {
                tbTenDA.Text = Gt.TenDA;
                tbTenGD.Text = Gt.TenGD;
                tbGTNT.Text = Gt.GiaTriNT;
                tbTenDA.Enabled = false;
                tbTenGD.Enabled = false;
                cbMaDA.Text = Gt.MaDA;
                cbMaGD.Text = Gt.MaGD;
                cbMaDA.Enabled = false;
                cbMaGD.Enabled = false;
                btLuu.Visible = false;
                tbGTNT.Text = Gt.GiaTriNT;
                dtStartDayGD.Text = String.Format("{0:yyyyMMdd}", Gt.StartDayGD);
                dtFinalDayGD.Text = String.Format("{0:yyyyMMdd}", Gt.FinalDayGD);
            }
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
        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        protected void raiseUpdate()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler?.Invoke(this, args);
        }
        public bool checkdata()
        {

            if (string.IsNullOrEmpty(cbMaDA.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã dự án", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaDA.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbMaGD.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã giao dịch", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaGD.Focus();
                return false;
            }
            return true;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            if (IsThemSua == 1 || IsThemSua == 2)
            {
                if (dtFinalDayGD.Value.Date < dtStartDayGD.Value.Date)
                {
                    MessageBox.Show("Thời gian kết thúc không được nhỏ hơn thời gian bắt đầu");
                    dtStartDayGD.Focus();
                    check = false;
                }
            }
            if (IsThemSua == 1)
            {

                if (bllGTNT.Checkthuphi(cbMaGD.Text.Trim(), cbMaDA.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("Phí dự án đã cập nhật", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaDA.Focus();
                    cbMaDA.SelectAll();
                }

                if (checkdata())
                {
                    DM_GiaTriNT gt = new DM_GiaTriNT();
                    gt.MaDA = cbMaDA.Text;
                    gt.MaGD = cbMaGD.Text;
                    gt.GiaTriNT = tbGTNT.Text;
                    gt.StartDayGD = String.Format("{0:yyyyMMdd}", Gt.StartDayGD);
                    gt.FinalDayGD = String.Format("{0:yyyyMMdd}", Gt.FinalDayGD);
                    if (bllGTNT.InsertGiaTriNT(gt))
                    {

                        Close();
                        raiseUpdate();
                    }
                }
            }
            else if (IsThemSua == 2)
            {
                string ma_gd_cu = "";
                string ma_da_cu = "";
                ma_gd_cu = Gt.MaGD;
                ma_da_cu = Gt.MaDA;
                // Check dữ liệu không cho trùng
                if (Gt.MaGD != cbMaGD.Text.Trim() || Gt.MaDA != cbMaDA.Text.Trim())
                {
                    if (bllGTNT.Checkthuphi(cbMaGD.Text.Trim(), cbMaDA.Text.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Phí dự án đã cập nhật", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbMaDA.Focus();
                        cbMaDA.SelectAll();
                        check = false;
                    }
                    if (bllGTNT.CheckDuAnPhatSinh(ma_da_cu.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Dự án đã phát sinh chi phí, không thể sửa ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        check = false;
                    }
                }
                if (check == true)
                {
                    DM_GiaTriNT gt = new DM_GiaTriNT();
                    gt.MaDA = cbMaDA.Text;
                    gt.MaGD = cbMaGD.Text;
                    gt.TenDA = tbTenDA.Text;
                    gt.TenGD = tbTenGD.Text;
                    gt.GiaTriNT = tbGTNT.Text;
                    gt.StartDayGD = String.Format("{0:yyyyMMdd}", Gt.StartDayGD);
                    gt.FinalDayGD = String.Format("{0:yyyyMMdd}", Gt.FinalDayGD);
                    if (bllGTNT.UpdateGiaTriNT(gt, ma_gd_cu, ma_da_cu))
                    {
                        Close();
                        raiseUpdate();
                    }
                }

            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbMaDA_Click(object sender, EventArgs e)
        {
            DuAnBLL duan = new DuAnBLL();
            cbMaDA.DataSource = duan.getALLDuAn();
            cbMaDA.DisplayMember = "MaDA";
            cbMaDA.ValueMember = "MaDA";
            tbTenDA.DataBindings.Clear();
            tbTenDA.DataBindings.Add("Text", cbMaDA.DataSource, "TenDA");
        }

        private void cbMaGD_Click(object sender, EventArgs e)
        {
            GiaiDoanBLL giaidoan = new GiaiDoanBLL();
            cbMaGD.DataSource = giaidoan.getALLGiaiDoan();
            cbMaGD.DisplayMember = "MaGD";
            cbMaGD.ValueMember = "MaGD";
            tbTenGD.DataBindings.Clear();
            tbTenGD.DataBindings.Add("Text", cbMaGD.DataSource, "TenGD");
        }

        private void tbGTNT_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbGTNT.Text.Equals("0"))
                    return;
                double temp = Convert.ToDouble(tbGTNT.Text);
                tbGTNT.Text = temp.ToString("#,###");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex);
            }
        }
    }
}
