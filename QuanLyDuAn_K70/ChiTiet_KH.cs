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
    public partial class ChiTiet_KH : Form
    {
        KhachHangBLL bllKH;
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        int IsThemSua = 0;
        DM_KhachHang Kh = new DM_KhachHang();
        public ChiTiet_KH(int isThemSua, DM_KhachHang kh)
        {
            InitializeComponent();
            bllKH = new KhachHangBLL();
            IsThemSua = isThemSua;
            Kh = kh;
            if (IsThemSua == 2)
            {
                tbMaKH.Text = Kh.MaKH;
                tbTenKH.Text = Kh.TenKH;
                tbDiaChi.Text = Kh.DiaChi;
                tbDoiTac.Text = Kh.DoiTac;
                tbDienThoai.Text = Kh.DienThoai;
                tbEmail.Text = Kh.Email;
                tbFax.Text = Kh.Fax;
                tbGhiChu.Text = Kh.GhiChu;
            }
            else if (IsThemSua == 3)
            {
                tbMaKH.Text = Kh.MaKH;
                tbTenKH.Text = Kh.TenKH;
                tbDiaChi.Text = Kh.DiaChi;
                tbDoiTac.Text = Kh.DoiTac;
                tbDienThoai.Text = Kh.DienThoai;
                tbEmail.Text = Kh.Email;
                tbFax.Text = Kh.Fax;
                tbGhiChu.Text = Kh.GhiChu;
                tbMaKH.Enabled = false;
                tbTenKH.Enabled = false;
                tbDiaChi.Enabled = false;
                tbDoiTac.Enabled = false;
                tbDienThoai.Enabled = false;
                tbEmail.Enabled = false;
                tbFax.Enabled = false;
                tbGhiChu.Enabled = false;
                btLuu.Visible = false;
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

            if (string.IsNullOrEmpty(tbMaKH.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaKH.Focus();
                return false;
            }
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(tbMaKH.Text))
            {
                MessageBox.Show("Mã khách hàng không được nhập ký tự đặc biệt", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaKH.Focus();
                return false;
            }
            return true;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            if(tbEmail.Text=="Someone@gmail.com")
            {
                tbEmail.Text = " ";
            }    
            if (IsThemSua == 1)
            {

                if (bllKH.CheckKhachHang(tbMaKH.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbMaKH.Focus();
                    tbMaKH.SelectAll();
                }
                else if (bllKH.CheckEmail(tbEmail.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("Email đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbEmail.Focus();
                    tbEmail.SelectAll();
                }
                else if (bllKH.CheckDienThoai(tbMaKH.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbDienThoai.Focus();
                    tbDienThoai.SelectAll();
                }

                if (checkdata())
                {
                    DM_KhachHang kh = new DM_KhachHang();
                    kh.MaKH = tbMaKH.Text;
                    kh.TenKH = tbTenKH.Text;
                    kh.DiaChi = tbDiaChi.Text;
                    kh.DoiTac = tbDoiTac.Text;
                    kh.DienThoai = tbDienThoai.Text;
                    kh.Email = tbEmail.Text;
                    kh.Fax = tbFax.Text;
                    kh.GhiChu = tbGhiChu.Text;
                    if (bllKH.InsertKhachHang(kh))
                    {

                        Close();
                        raiseUpdate();
                    }
                }
            }
            else if (IsThemSua == 2)
            {
                string ma_kh_cu = "";
                // Check dữ liệu không cho trùng
                if (Kh.MaKH != tbMaKH.Text.Trim())
                {
                    if (bllKH.CheckKhachHang(tbMaKH.Text.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbMaKH.Focus();
                        tbMaKH.SelectAll();
                    }
                }
                ma_kh_cu = Kh.MaKH;
                DM_KhachHang kh = new DM_KhachHang();
                kh.MaKH = tbMaKH.Text;
                kh.TenKH = tbTenKH.Text;
                kh.DiaChi = tbDiaChi.Text;
                kh.DoiTac = tbDoiTac.Text;
                kh.DienThoai = tbDienThoai.Text;
                kh.Email = tbEmail.Text;
                kh.Fax = tbFax.Text;
                kh.GhiChu = tbGhiChu.Text;
                if (bllKH.UpdateKhachHang(kh, ma_kh_cu))
                {
                    Close();
                    raiseUpdate();
                }


            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbTenKH.Focus();
            }
        }

        private void tbDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tbTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && (Keys)e.KeyChar != Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void tbEmail_Enter(object sender, EventArgs e)
        {
            if (tbEmail.Text == "Someone@gmail.com")
            {
                tbEmail.Text = "";
                tbEmail.ForeColor = Color.Black;
            }
        }

        private void tbEmail_Leave(object sender, EventArgs e)
        {
            if (tbEmail.Text == "")
            {
                tbEmail.Text = "Someone@gmail.com";
                tbEmail.ForeColor = Color.Silver;
            }
        }
    }
}
