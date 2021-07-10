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
    public partial class ChiTiet_BP : Form
    {
        BoPhanBLL bllBP;
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        int IsThemSua = 0;
        DM_BoPhan Bp = new DM_BoPhan();
        public ChiTiet_BP(int isThemSua, DM_BoPhan bp)
        {
            InitializeComponent();
            bllBP = new BoPhanBLL();
            IsThemSua = isThemSua;
            Bp = bp;
            if (IsThemSua == 2)
            {
                tbMaBP.Text = Bp.MaBP;
                tbTenBP.Text = Bp.TenBP;
            }
            else if (IsThemSua == 3)
            {
                tbMaBP.Text = Bp.MaBP;
                tbTenBP.Text = Bp.TenBP;
                tbMaBP.Enabled = false;
                tbTenBP.Enabled = false;
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

            if (string.IsNullOrEmpty(tbMaBP.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã bộ phận", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaBP.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbTenBP.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên bộ phận", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTenBP.Focus();
                return false;
            }
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(tbMaBP.Text))
            {
                MessageBox.Show("Mã bộ phận không được nhập ký tự đặc biệt", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaBP.Focus();
                return false;
            }
            
            return true;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            if (IsThemSua == 1)
            {

                if (bllBP.CheckBoPhan(tbMaBP.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("Mã bộ phận đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbMaBP.Focus();
                    tbMaBP.SelectAll();
                }

                if (checkdata())
                {
                    DM_BoPhan bp = new DM_BoPhan();
                    bp.MaBP = tbMaBP.Text;
                    bp.TenBP = tbTenBP.Text;
                    if (bllBP.InsertBoPhan(bp))
                    {

                        Close();
                        raiseUpdate();
                    }
                }
            }
            else if (IsThemSua == 2)
            {
                string ma_bp_cu = "";
                // Check dữ liệu không cho trùng
                if (Bp.MaBP != tbMaBP.Text.Trim())
                {
                    if (bllBP.CheckBoPhan(tbMaBP.Text.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Mã bộ phận đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbMaBP.Focus();
                        tbMaBP.SelectAll();
                    }
                }
                ma_bp_cu = Bp.MaBP;
                DM_BoPhan bp = new DM_BoPhan();
                bp.MaBP = tbMaBP.Text;
                bp.TenBP = tbTenBP.Text;
                if (bllBP.UpdateBoPhan(bp, ma_bp_cu))
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

        private void tbMaBP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbTenBP.Focus();
            }
        }
    }
}
