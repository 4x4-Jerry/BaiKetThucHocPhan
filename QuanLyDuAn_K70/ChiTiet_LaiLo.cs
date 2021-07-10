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
    public partial class ChiTiet_LaiLo : Form
    {
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        thuoctinh Tt = new thuoctinh();
        public ChiTiet_LaiLo(thuoctinh tt)
        {
            InitializeComponent();
            Tt = tt;
            tbMaDA.Text = Tt.MaDA;
            tbTenDA.Text = Tt.TenDA;
            tbLaiLo.Text = Tt.LaiLo;
            tbMaDA.Enabled = false;
            tbTenDA.Enabled = false;
            tbLaiLo.Enabled = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        public class UpdateEventArgs : EventArgs
        {
           
        }
    }
}
