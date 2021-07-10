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
    public partial class ChiTiet_Phi : Form
    {
        PhiBLL bllPhi;
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        int IsThemSua = 0;
        DM_Phi P = new DM_Phi();
        public ChiTiet_Phi(int isThemSua, DM_Phi phi)
        {
            InitializeComponent();
            bllPhi = new PhiBLL();
            IsThemSua = isThemSua;
            P = phi;
            if (IsThemSua == 2)
            {
                tbMaPhi.Text = P.MaPhi;
                tbTenPhi.Text = P.TenPhi;
            }
            else if (IsThemSua == 3)
            {
                tbMaPhi.Text = P.MaPhi;
                tbTenPhi.Text = P.TenPhi;
                tbMaPhi.Enabled = false;
                tbTenPhi.Enabled = false;
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

            if (string.IsNullOrEmpty(tbMaPhi.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã phí", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaPhi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbTenPhi.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên phí", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTenPhi.Focus();
                return false;
            }
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(tbMaPhi.Text))
            {
                MessageBox.Show("Mã nhân viên không được nhập ký tự đặc biệt", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaPhi.Focus();
                return false;
            }
            return true;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            if (IsThemSua == 1)
            {

                if (bllPhi.CheckPhi(tbMaPhi.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("Đã có mã phí này rồi!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbMaPhi.Focus();
                    tbMaPhi.SelectAll();
                }

                if (checkdata())
                {
                    DM_Phi phi = new DM_Phi();
                    phi.MaPhi = tbMaPhi.Text;
                    phi.TenPhi = tbTenPhi.Text;
                    if (bllPhi.InsertPhi(phi))
                    {

                        Close();
                        raiseUpdate();
                    }
                }
            }
            else if (IsThemSua == 2)
            {
                string ma_phi_cu = "";
                // Check dữ liệu không cho trùng
                if (P.MaPhi != tbMaPhi.Text.Trim())
                {
                    if (bllPhi.CheckPhi(tbMaPhi.Text.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Đã có mã phí này rồi!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbMaPhi.Focus();
                        tbMaPhi.SelectAll();
                    }
                }
                ma_phi_cu = P.MaPhi;
                DM_Phi phi = new DM_Phi();
                phi.MaPhi = tbMaPhi.Text;
                phi.TenPhi = tbTenPhi.Text;
                if (bllPhi.UpdatePhi(phi, ma_phi_cu))
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

        private void tbMaPhi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbTenPhi.Focus();
            }
        }


    }
}
