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
    public partial class ChiTiet_NDA : Form
    {
        NhomDuAnBLL bllNDA;
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        int IsThemSua = 0;
        DM_NhomDuAn Nda = new DM_NhomDuAn();
        public ChiTiet_NDA(int isThemSua, DM_NhomDuAn nda)
        {
            InitializeComponent();
            bllNDA = new NhomDuAnBLL();
            IsThemSua = isThemSua;
            Nda = nda;
            if (IsThemSua == 2)
            {
                tbMaNDA.Text = Nda.MaNDA;
                tbTenNDA.Text = Nda.TenNDA;
            }
            else if (IsThemSua == 3)
            {
                tbMaNDA.Text = Nda.MaNDA;
                tbTenNDA.Text = Nda.TenNDA;
                tbMaNDA.Enabled = false;
                tbTenNDA.Enabled = false;
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

            if (string.IsNullOrEmpty(tbMaNDA.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã nhóm dự án", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaNDA.Focus();
                return false;
            }
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(tbMaNDA.Text))
            {
                MessageBox.Show("Mã nhóm dự án không được nhập ký tự đặc biệt", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaNDA.Focus();
                return false;
            }
            return true;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            if (IsThemSua == 1)
            {

                if (bllNDA.CheckNhomDuAn(tbMaNDA.Text.Trim()).Rows.Count > 0)
                {
                    MessageBox.Show("Mã nhóm dự án đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbMaNDA.Focus();
                    tbMaNDA.SelectAll();
                }

                if (checkdata())
                {
                    DM_NhomDuAn nda = new DM_NhomDuAn();
                    nda.MaNDA = tbMaNDA.Text;
                    nda.TenNDA = tbTenNDA.Text;
                    if (bllNDA.InsertNhomDuAn(nda))
                    {

                        Close();
                        raiseUpdate();
                    }
                }
            }
            else if (IsThemSua == 2)
            {
                string ma_nda_cu = "";
                // Check dữ liệu không cho trùng
                if (Nda.MaNDA != tbMaNDA.Text.Trim())
                {
                    if (bllNDA.CheckNhomDuAn(tbMaNDA.Text.Trim()).Rows.Count > 0)
                    {
                        MessageBox.Show("Đã tồn tại mã nhóm dự án này", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbMaNDA.Focus();
                        tbMaNDA.SelectAll();
                    }
                }
                ma_nda_cu = Nda.MaNDA;
                DM_NhomDuAn nda = new DM_NhomDuAn();
                nda.MaNDA = tbMaNDA.Text;
                nda.TenNDA = tbTenNDA.Text;
                if (bllNDA.UpdateNhomDuAn(nda, ma_nda_cu))
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

        private void tbMaNDA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbTenNDA.Focus();
            }
        }


    }
}
