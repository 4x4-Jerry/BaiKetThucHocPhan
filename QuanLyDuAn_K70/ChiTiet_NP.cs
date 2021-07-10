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
    public partial class ChiTiet_NP : Form
    {
        bool check = true;
        NhapPhiBLL bllNP;
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        int IsThemSua = 0;
        DM_NhapPhi Np = new DM_NhapPhi();
        public ChiTiet_NP(int isThemSua, DM_NhapPhi np)
        {
            InitializeComponent();
            bllNP = new NhapPhiBLL();
            IsThemSua = isThemSua;
            Np = np;
            if(IsThemSua == 1)
            {
                tbTenDA.Enabled = false;
                tbTenPhi.Enabled = false;
            }
            else if (IsThemSua == 2)
            {
                tbTenPhi.Text = Np.TenPhi;
                tbTenDA.Text = Np.TenDA;
                cbMaDA.Text = Np.MaDA;
                cbMaPhi.Text = Np.MaPhi;
                tbChiPhi.Text = Np.ChiPhi;
                tbTenDA.Enabled = false;
                tbTenPhi.Enabled = false;
            }
            else if (IsThemSua == 3)
            {
                tbTenPhi.Text = Np.TenPhi;
                tbTenDA.Text = Np.TenDA;
                cbMaDA.Text = Np.MaDA;
                cbMaPhi.Text = Np.MaPhi;
                tbChiPhi.Text = Np.ChiPhi;
                cbMaDA.Enabled = false;
                cbMaPhi.Enabled = false;
                tbChiPhi.Enabled = false;
                btLuu.Visible = false;
                tbTenDA.Enabled = false;
                tbTenPhi.Enabled = false;
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
            if (string.IsNullOrEmpty(cbMaPhi.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã phí", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaPhi.Focus();
                return false;
            }
            return true;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            if (IsThemSua == 1)
            {

                if (bllNP.CheckMaDA(cbMaDA.Text.Trim(), cbMaPhi.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("Dự án đã được cập nhật chi phí rồi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaDA.Focus();
                    cbMaDA.SelectAll();
                }
                if (checkdata())
                {
                    DM_NhapPhi np = new DM_NhapPhi();
                    np.MaDA = cbMaDA.Text;
                    np.MaPhi = cbMaPhi.Text;
                    np.ChiPhi = tbChiPhi.Text;
                    if (bllNP.InsertNhapPhi(np))
                    {

                        Close();
                        raiseUpdate();
                    }
                }
            }
            else if (IsThemSua == 2)
            {
                string ma_da_cu = "";
                string ma_phi_cu = "";
                ma_da_cu = Np.MaDA;
                // Check dữ liệu không cho trùng
                if (Np.MaDA != cbMaDA.Text.Trim() || Np.MaPhi != cbMaPhi.Text.Trim())
                {
                    if (bllNP.CheckMaDA(cbMaDA.Text.Trim(), cbMaPhi.Text.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Dự án đã được cập nhật chi phí rồi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbMaDA.Focus();
                        cbMaDA.SelectAll();
                        check = false;
                    }
                    if (bllNP.CheckDuAnPhatSinh(ma_da_cu.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Dự án đã phát sinh chi phí, không thể sửa", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbMaDA.Text = ma_da_cu;
                        check = false;
                    }
                    
                }
                if (check == true)
                {
                    ma_phi_cu = Np.MaPhi;
                    DM_NhapPhi np = new DM_NhapPhi();
                    np.MaDA = cbMaDA.Text;
                    np.MaPhi = cbMaPhi.Text;
                    np.ChiPhi = tbChiPhi.Text;
                    np.TenDA = tbTenDA.Text;
                    np.TenPhi = tbTenPhi.Text;
                    if (bllNP.UpdateNhapPhi(np, ma_da_cu, ma_phi_cu))
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

      

        private void cbMaPhi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbChiPhi.Focus();
            }
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

        private void cbMaPhi_Click(object sender, EventArgs e)
        {
            PhiBLL phi = new PhiBLL();
            cbMaPhi.DataSource = phi.getALLPhi();
            cbMaPhi.DisplayMember = "MaPhi";
            cbMaPhi.ValueMember = "MaPhi";
            tbTenPhi.DataBindings.Clear();
            tbTenPhi.DataBindings.Add("Text", cbMaPhi.DataSource, "TenPhi");
        }

        private void tbChiPhi_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbChiPhi.Text.Equals("0"))
                    return;
                double temp = Convert.ToDouble(tbChiPhi.Text);
                tbChiPhi.Text = temp.ToString("#,###");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex);
            }
        }

        private void tbChiPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
