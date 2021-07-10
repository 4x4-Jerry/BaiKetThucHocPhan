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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
           // SetStyle(ControlStyles.ResizeRedraw, true);
        }
        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    Rectangle rc = ClientRectangle;
        //    if (rc.IsEmpty)
        //        return;
        //    if (rc.Width == 0 || rc.Height == 0)

        //        return;
        //    using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.White, Color.FromArgb(196, 232, 250), 90F))
        //    {
        //        e.Graphics.FillRectangle(brush, rc);
        //    }
        //}

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form_NDA f = new Form_NDA();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form_NP f = new Form_NP();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form_KH f = new Form_KH();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form_GiaTriNT f = new Form_GiaTriNT();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormLaiLo f = new FormLaiLo();

            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QLBP f = new QLBP();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_CN f = new Form_CN();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_DA f = new Form_DA();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_GD f = new Form_GD();
            f.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form_NV f = new Form_NV();
            f.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form_Phi f = new Form_Phi();
            f.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form_SDDK f = new Form_SDDK();
            f.Show();
        }
    }
}
