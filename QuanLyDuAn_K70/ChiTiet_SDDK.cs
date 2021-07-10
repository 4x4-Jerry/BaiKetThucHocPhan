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
    public partial class ChiTiet_SDDK : Form
    {
        bool check = true;
        SoDuDauKyBLL bllSDDK;
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        int IsThemSua = 0;
        DM_SoDuDauKy Sd = new DM_SoDuDauKy();
        public ChiTiet_SDDK(int isThemSua, DM_SoDuDauKy sd)
        {
            InitializeComponent();
            bllSDDK = new SoDuDauKyBLL();
            IsThemSua = isThemSua;
            Sd = sd;
            if (IsThemSua == 1)
            {
                tbTenDA.Enabled = false;
                tbTenKH.Enabled = false;
            }
            else if (IsThemSua == 2)
            {
                tbTenDA.Enabled = false;
                tbTenKH.Enabled = false;
                tbTenKH.Text = Sd.TenKH;
                tbTenDA.Text = Sd.TenDA;
                cbMaDA.Text = Sd.MaDA;
                cbMaKH.Text = Sd.MaKH;
                tbGiaTriBD.Text = Sd.GiaTriBD;
            }
            else if (IsThemSua == 3)
            {
                tbTenKH.Text = Sd.TenKH;
                tbTenDA.Text = Sd.TenDA;
                cbMaDA.Text = Sd.MaDA;
                cbMaKH.Text = Sd.MaKH;
                tbGiaTriBD.Text = Sd.GiaTriBD;
                cbMaDA.Enabled = false;
                cbMaKH.Enabled = false;
                tbGiaTriBD.Enabled = false;
                btLuu.Visible = false;
                tbTenDA.Enabled = false;
                tbTenKH.Enabled = false;
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
            if (string.IsNullOrEmpty(cbMaKH.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaKH.Focus();
                return false;
            }
           
            return true;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            if (IsThemSua == 1)
            {

                if (bllSDDK.CheckMaDA(cbMaDA.Text.Trim(), cbMaKH.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("Dự án đã cập nhật số dư", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaDA.Focus();
                    cbMaDA.SelectAll();
                }
                if (checkdata())
                {
                    DM_SoDuDauKy sd = new DM_SoDuDauKy();
                    sd.MaDA = cbMaDA.Text;
                    sd.MaKH = cbMaKH.Text;
                    sd.GiaTriBD = tbGiaTriBD.Text;
                    if (bllSDDK.InsertSoDuDauKy(sd))
                    {

                        Close();
                        raiseUpdate();
                    }
                }
            }
            else if (IsThemSua == 2)
            {
                string ma_da_cu = "";
                string ma_kh_cu = "";
                ma_da_cu = Sd.MaDA;
                ma_kh_cu = Sd.MaKH;
                // Check dữ liệu không cho trùng
                if (Sd.MaDA != cbMaDA.Text.Trim() || Sd.MaKH != cbMaKH.Text.Trim())
                {
                    if (bllSDDK.CheckMaDA(cbMaDA.Text.Trim(), cbMaKH.Text.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Dự án đã cập nhật số dư", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbMaDA.Focus();
                        cbMaDA.SelectAll();
                        check = false;
                    }
                    if (bllSDDK.CheckDuAnPhatSinh(ma_da_cu.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Dự án đã phát sinh chi phí, không thể sửa", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        check = false;
                    }
                }
                if (check == true)
                {
                    
                    DM_SoDuDauKy sd = new DM_SoDuDauKy();
                    Sd.MaDA = cbMaDA.Text;
                    Sd.MaKH = cbMaKH.Text;
                    Sd.GiaTriBD = tbGiaTriBD.Text;
                    Sd.TenKH = tbTenKH.Text;
                    Sd.TenDA = tbTenDA.Text;
                    if (bllSDDK.UpdateSoDuDauKy(Sd, ma_da_cu, ma_kh_cu))
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
            DuAnBLL phi = new DuAnBLL();
            cbMaDA.DataSource = phi.getALLDuAn();
            cbMaDA.DisplayMember = "MaDA";
            cbMaDA.ValueMember = "MaDA";
            tbTenDA.DataBindings.Clear();
            tbTenDA.DataBindings.Add("Text", cbMaDA.DataSource, "TenDA");
        }

        private void cbMaKH_Click(object sender, EventArgs e)
        {
            KhachHangBLL phi = new KhachHangBLL();
            cbMaKH.DataSource = phi.getALLKhachHang();
            cbMaKH.DisplayMember = "MaKH";
            cbMaKH.ValueMember = "MaKH";
            tbTenKH.DataBindings.Clear();
            tbTenKH.DataBindings.Add("Text", cbMaKH.DataSource, "TenKH");
        }

        private void tbGiaTriBD_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbGiaTriBD.Text.Equals("0"))
                    return;
                double temp = Convert.ToDouble(tbGiaTriBD.Text);
                tbGiaTriBD.Text = temp.ToString("#,###");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex);
            }
        }

        private void tbGiaTriBD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
