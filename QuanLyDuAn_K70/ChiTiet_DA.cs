using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace QuanLyDuAn_K70
{
    public partial class ChiTiet_DA : Form
    {
        bool check = true;
        DuAnBLL bllDA;
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        int IsThemSua = 0;
        DM_DuAn Da = new DM_DuAn();
        public ChiTiet_DA(int isThemSua, DM_DuAn da)
        {
            InitializeComponent();
            bllDA = new DuAnBLL();
            IsThemSua = isThemSua;
            Da = da;
            if (IsThemSua == 1)
            {
                tbTenKH.Enabled = false;
                tbTenNV.Enabled = false;
                tbTenBP.Enabled = false;
                tbTenCN.Enabled = false;
                tbTenNDA.Enabled = false;
            }
            else if (IsThemSua == 2)
            {
                tbMaDA.Text = Da.MaDA;
                tbTenDA.Text = Da.TenDA;
                cbMaKH.Text = Da.MaKH;
                tbTenKH.Text = Da.TenKH;
                cbMaNV.Text = Da.MaNV;
                tbTenNV.Text = Da.TenNV;
                tbTenBP.Text = Da.TenBP;
                tbTenCN.Text = Da.TenCN;
                tbTenNDA.Text = Da.TenNDA;
                cbMaBP.Text = Da.MaBP;
                cbMaCN.Text = Da.MaCN;
                tbGiaTriDA.Text = Da.GiaTriDA;
                cbMaNDA.Text = Da.MaNDA;
                dtStartDay.Text = String.Format("{0:yyyyMMdd}", Da.StartDay);
                dtFinalDay.Text = String.Format("{0:yyyyMMdd}", Da.FinalDay);
                tbGhiChu.Text = Da.GhiChu;
                tbTenKH.Enabled = false;
                tbTenNV.Enabled = false;
                tbTenBP.Enabled = false;
                tbTenCN.Enabled = false;
                tbTenNDA.Enabled = false;
            }
            else if (IsThemSua == 3)
            {
                tbMaDA.Text = Da.MaDA;
                tbTenDA.Text = Da.TenDA;
                cbMaKH.Text = Da.MaKH;
                tbTenKH.Text = Da.TenKH;
                cbMaNV.Text = Da.MaNV;
                tbTenNV.Text = Da.TenNV;
                tbTenBP.Text = Da.TenBP;
                tbTenCN.Text = Da.TenCN;
                tbTenNDA.Text = Da.TenNDA;
                cbMaBP.Text = Da.MaBP;
                cbMaCN.Text = Da.MaCN;
                tbGiaTriDA.Text = Da.GiaTriDA;
                cbMaNDA.Text = Da.MaNDA;
                dtStartDay.Text = String.Format("{0:yyyyMMdd}", Da.StartDay);
                dtStartDay.Text = String.Format("{0:yyyyMMdd}", Da.FinalDay);
                tbGhiChu.Text = Da.GhiChu;
                tbMaDA.Enabled = false;
                tbTenDA.Enabled = false;
                cbMaKH.Enabled = false;
                tbTenKH.Enabled = false;
                cbMaNV.Enabled = false;
                tbTenNV.Enabled = false;
                tbTenNDA.Enabled = false;
                tbTenCN.Enabled = false;
                tbTenBP.Enabled = false;
                cbMaBP.Enabled = false;
                cbMaCN.Enabled = false;
                tbGiaTriDA.Enabled = false;
                cbMaNDA.Enabled = false;
                dtStartDay.Enabled = false;
                dtFinalDay.Enabled = false;
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

            if (string.IsNullOrEmpty(tbMaDA.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã dự án", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaDA.Focus();
                return false;
            }
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(tbMaDA.Text))
            {
                MessageBox.Show("Mã dự án không được nhập ký tự đặc biệt", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaDA.Focus();
                return false;
            }
            return true;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            string ma_da_cu = "";

            ma_da_cu = Da.MaDA;
            if (IsThemSua == 1 || IsThemSua == 2)
            {
                if (dtFinalDay.Value.Date < dtStartDay.Value.Date)
                {
                    MessageBox.Show("Thời gian kết thúc không được nhỏ hơn thời gian bắt đầu");
                    dtStartDay.Focus();
                    check = false;
                }
            }
            if (IsThemSua == 1)
            {

                if (bllDA.CheckDuAn(tbMaDA.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("Mã dự án đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbMaDA.Focus();
                    tbMaDA.SelectAll();
                }
                if (checkdata())
                {
                    DM_DuAn da = new DM_DuAn();
                    da.MaDA = tbMaDA.Text;
                    da.TenDA = tbTenDA.Text;
                    da.MaKH = cbMaKH.Text;
                    da.MaNV = cbMaNV.Text;
                    da.MaBP = cbMaBP.Text;
                    da.MaCN = cbMaCN.Text;
                    da.GiaTriDA = tbGiaTriDA.Text;
                    da.MaNDA = cbMaNDA.Text;
                    da.StartDay = String.Format("{0:yyyyMMdd}", dtStartDay.Value);
                    da.FinalDay = String.Format("{0:yyyyMMdd}", dtFinalDay.Value);
                    da.GhiChu = tbGhiChu.Text;

                    if (bllDA.InsertDuAn(da))
                    {

                        Close();
                        raiseUpdate();
                    }
                }
            }
            else if (IsThemSua == 2)
            {

                // Check dữ liệu không cho trùng

                if (Da.MaDA != tbMaDA.Text.Trim())
                {


                    if (bllDA.CheckDuAn(tbMaDA.Text.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Mã dự án đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbMaDA.Focus();
                        tbMaDA.SelectAll();
                        check = false;
                    }
                    else if (bllDA.CheckDuAnPhatSinh(ma_da_cu.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Mã dự án đã phát sinh, không thể thay đổi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbMaDA.Text = ma_da_cu;
                        check = false;
                    }

                }

                if (check == true)
                {

                    DM_DuAn da = new DM_DuAn();
                    da.MaDA = tbMaDA.Text;
                    da.TenDA = tbTenDA.Text;
                    da.MaKH = cbMaKH.Text;
                    da.MaNV = cbMaNV.Text;
                    da.TenNV = tbTenNV.Text;
                    da.TenCN = tbTenCN.Text;
                    da.TenBP = tbTenBP.Text;
                    da.MaBP = cbMaBP.Text;
                    da.MaCN = cbMaCN.Text;
                    da.TenKH = tbTenKH.Text;
                    da.TenNDA = tbTenNDA.Text;
                    da.GiaTriDA = tbGiaTriDA.Text;
                    da.MaNDA = cbMaNDA.Text;
                    da.StartDay = String.Format("{0:yyyyMMdd}", dtStartDay.Value);
                    da.FinalDay = String.Format("{0:yyyyMMdd}", dtFinalDay.Value);
                    da.GhiChu = tbGhiChu.Text;
                    if (bllDA.UpdateDuAn(da, ma_da_cu))
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
        private void cbMaKH_Click(object sender, EventArgs e)
        {
            KhachHangBLL khachhang = new KhachHangBLL();
            cbMaKH.DataSource = khachhang.getALLKhachHang();
            cbMaKH.DisplayMember = "MaKH";
            cbMaKH.ValueMember = "MaKH";
            tbTenKH.DataBindings.Clear();
            tbTenKH.DataBindings.Add("Text", cbMaKH.DataSource, "TenKH");

        }

        private void cbMaNV_Click(object sender, EventArgs e)
        {
            NhanVienBLL nhanvien = new NhanVienBLL();
            cbMaNV.DataSource = nhanvien.getALLNhanVien();
            cbMaNV.DisplayMember = "MaNV";
            cbMaNV.ValueMember = "MaNV";
            tbTenNV.DataBindings.Clear();
            tbTenNV.DataBindings.Add("Text", cbMaNV.DataSource, "TenNV");
        }

        private void cbMaBP_Click(object sender, EventArgs e)
        {
            BoPhanBLL bophan = new BoPhanBLL();
            cbMaBP.DataSource = bophan.getALLBoPhan();
            cbMaBP.DisplayMember = "MaBP";
            cbMaBP.ValueMember = "MaBP";
            tbTenBP.DataBindings.Clear();
            tbTenBP.DataBindings.Add("Text", cbMaBP.DataSource, "TenBP");
        }

        private void cbMaCN_Click(object sender, EventArgs e)
        {
            ChiNhanhBLL chinhanh = new ChiNhanhBLL();
            cbMaCN.DataSource = chinhanh.getALLChiNhanh();
            cbMaCN.DisplayMember = "MaCN";
            cbMaCN.ValueMember = "MaCN";
            tbTenCN.DataBindings.Clear();
            tbTenCN.DataBindings.Add("Text", cbMaCN.DataSource, "TenCN");
        }

        private void cbMaNDA_Click(object sender, EventArgs e)
        {
            NhomDuAnBLL nhomduan = new NhomDuAnBLL();
            cbMaNDA.DataSource = nhomduan.getALLNhomDuAn();
            cbMaNDA.DisplayMember = "MaNDA";
            cbMaNDA.ValueMember = "MaNDA";
            tbTenNDA.DataBindings.Clear();
            tbTenNDA.DataBindings.Add("Text", cbMaNDA.DataSource, "TenNDA");
        }

        private void tbGiaTriDA_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbGiaTriDA.Text.Equals("0"))
                    return;
                double temp = Convert.ToDouble(tbGiaTriDA.Text);
                tbGiaTriDA.Text = temp.ToString("#,###");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex);
            }
        }

        private void tbGiaTriDA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
