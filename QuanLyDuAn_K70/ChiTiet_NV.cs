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
    public partial class ChiTiet_NV : Form
    {
        NhanVienBLL bllNV;
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        int IsThemSua = 0;
        DM_NhanVien Nv = new DM_NhanVien();
        public ChiTiet_NV(int isThemSua, DM_NhanVien nv)
        {
            InitializeComponent();
            bllNV = new NhanVienBLL();
            IsThemSua = isThemSua;
            Nv = nv;
            if (IsThemSua == 2)
            {
                tbMaNV.Text = Nv.MaNV;
                tbTenNV.Text = Nv.TenNV;
            }
            else if (IsThemSua == 3)
            {
                tbMaNV.Text = Nv.MaNV;
                tbTenNV.Text = Nv.TenNV;
                tbMaNV.Enabled = false;
                tbTenNV.Enabled = false;
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

            if (string.IsNullOrEmpty(tbMaNV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaNV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbTenNV.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTenNV.Focus();
                return false;
            }
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(tbMaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không được nhập ký tự đặc biệt", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaNV.Focus();
                return false;
            }
            return true;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            if (IsThemSua == 1)
            {

                if (bllNV.CheckNhanVien(tbMaNV.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbMaNV.Focus();
                    tbMaNV.SelectAll();
                }

                if (checkdata())
                {
                    DM_NhanVien nv = new DM_NhanVien();
                    nv.MaNV = tbMaNV.Text;
                    nv.TenNV = tbTenNV.Text;
                    if (bllNV.InsertNhanVien(nv))
                    {

                        Close();
                        raiseUpdate();
                    }
                }
            }
            else if (IsThemSua == 2)
            {
                string ma_nv_cu = "";
                // Check dữ liệu không cho trùng
                if (Nv.MaNV != tbMaNV.Text.Trim())
                {
                    if (bllNV.CheckNhanVien(tbMaNV.Text.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Đã có nhân viên này rồi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbMaNV.Focus();
                        tbMaNV.SelectAll();
                    }
                }
                ma_nv_cu = Nv.MaNV;
                DM_NhanVien nv = new DM_NhanVien();
                nv.MaNV = tbMaNV.Text;
                nv.TenNV = tbTenNV.Text;
                if (bllNV.UpdateNhanVien(nv, ma_nv_cu))
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

        private void tbMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbTenNV.Focus();
            }
        }


    }
}
