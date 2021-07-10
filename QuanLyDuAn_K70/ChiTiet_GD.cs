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
    public partial class ChiTiet_GD : Form
    {
        GiaiDoanBLL bllGD;
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        int IsThemSua = 0;
        DM_GiaiDoan Gd = new DM_GiaiDoan();
        public ChiTiet_GD(int isThemSua, DM_GiaiDoan gd)
        {
            InitializeComponent();
            bllGD = new GiaiDoanBLL();
            IsThemSua = isThemSua;
            Gd = gd;
            if (IsThemSua == 2)
            {
                tbMaGD.Text = Gd.MaGD;
                tbTenGD.Text = Gd.TenGD;
            }
            else if (IsThemSua == 3)
            {
                tbMaGD.Text = Gd.MaGD;
                tbTenGD.Text = Gd.TenGD;
                tbMaGD.Enabled = false;
                tbTenGD.Enabled = false;
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

            if (string.IsNullOrEmpty(tbMaGD.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã giai đoạn", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaGD.Focus();
                return false;
            }
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(tbMaGD.Text))
            {
                MessageBox.Show("Mã giai đoạn không được nhập ký tự đặc biệt", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaGD.Focus();
                return false;
            }
            return true;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            if (IsThemSua == 1)
            {

                if (bllGD.CheckGiaiDoan(tbMaGD.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("Mã giai đoạn đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbMaGD.Focus();
                    tbMaGD.SelectAll();
                }

                if (checkdata())
                {
                    DM_GiaiDoan bp = new DM_GiaiDoan();
                    bp.MaGD = tbMaGD.Text;
                    bp.TenGD = tbTenGD.Text;
                    if (bllGD.InsertGiaiDoan(bp))
                    {

                        Close();
                        raiseUpdate();
                    }
                }
            }
            else if (IsThemSua == 2)
            {
                string ma_gd_cu = "";
                // Check dữ liệu không cho trùng
                if (Gd.MaGD != tbMaGD.Text.Trim())
                {
                    if (bllGD.CheckGiaiDoan(tbMaGD.Text.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Mã giai đoạn đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbMaGD.Focus();
                        tbMaGD.SelectAll();
                    }
                }
                ma_gd_cu = Gd.MaGD;
                DM_GiaiDoan bp = new DM_GiaiDoan();
                bp.MaGD = tbMaGD.Text;
                bp.TenGD = tbTenGD.Text;
                if (bllGD.UpdateGiaiDoan(Gd, ma_gd_cu))
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

        private void tbMaGD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbTenGD.Focus();
            }
        }
    }
}
