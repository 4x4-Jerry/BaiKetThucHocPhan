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
    public partial class ChiTiet_CN : Form
    {
        ChiNhanhBLL bllCN;
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        int IsThemSua = 0;
        DM_ChiNhanh Cn = new DM_ChiNhanh();
        public ChiTiet_CN(int isThemSua, DM_ChiNhanh cn)
        {
            InitializeComponent();
            bllCN = new ChiNhanhBLL();
            IsThemSua = isThemSua;
            Cn = cn;
            if (IsThemSua == 2)
            {
                tbMaCN.Text = Cn.MaCN;
                tbTenCN.Text = Cn.TenCN;
            }
            else if (IsThemSua == 3)
            {
                tbMaCN.Text = Cn.MaCN;
                tbTenCN.Text = Cn.TenCN;
                tbMaCN.Enabled = false;
                tbTenCN.Enabled = false;
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
            
        }
        protected void raiseUpdate()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler?.Invoke(this, args);
        }
        public bool checkdata()
        {

            if (string.IsNullOrEmpty(tbMaCN.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã chi nhánh", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaCN.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbTenCN.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã chi nhánh", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTenCN.Focus();
                return false;
            }
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(tbMaCN.Text))
            {
                MessageBox.Show("Mã chi nhánh không được nhập ký tự đặc biệt", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaCN.Focus();
                return false;
            }
            return true;
        }

        private void btLuu_Click_1(object sender, EventArgs e)
        {
            if (IsThemSua == 1)
            {

                if (bllCN.CheckChiNhanh(tbMaCN.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("Mã chi nhánh đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbMaCN.Focus();
                    tbMaCN.SelectAll();
                }

                if (checkdata())
                {
                    DM_ChiNhanh cn = new DM_ChiNhanh();
                    cn.MaCN = tbMaCN.Text;
                    cn.TenCN = tbTenCN.Text;
                    if (bllCN.InsertChiNhanh(cn))
                    {

                        Close();
                        raiseUpdate();
                    }

                    //else
                    //    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
            }
            else if (IsThemSua == 2)
            {
                string ma_cn_cu = "";
                // Check dữ liệu không cho trùng
                if (Cn.MaCN != tbMaCN.Text.Trim())
                {
                    if (bllCN.CheckChiNhanh(tbMaCN.Text.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Mã chi nhánh đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbMaCN.Focus();
                        tbMaCN.SelectAll();
                    }
                }
                ma_cn_cu = Cn.MaCN;
                DM_ChiNhanh cn = new DM_ChiNhanh();
                cn.MaCN = tbMaCN.Text;
                cn.TenCN = tbTenCN.Text;
                if (bllCN.UpdateChiNhanh(cn, ma_cn_cu))
                {
                    Close();
                    raiseUpdate();
                }
               
            }
        }
    

    private void btDong_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void tbMaCN_KeyDown_1(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            tbTenCN.Focus();
        }
    }
}
}

