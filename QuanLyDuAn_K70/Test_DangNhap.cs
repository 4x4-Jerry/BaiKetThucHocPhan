using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDuAn_K70
{
    public partial class Test_DangNhap : Form
    {
        public Test_DangNhap()
        {
            InitializeComponent();
        }

        private void btDangNhap_Click_1(object sender, EventArgs e)
        {
            if (tbTenDangNhap.Text == "" || tbTenDangNhap.Text == null)
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập");
                tbTenDangNhap.Focus();

            }
            if (tbMatKhau.Text == "" || tbMatKhau.Text == null)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
                tbMatKhau.Focus();

            }
            Menu f = new Menu();

            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-QVP8J3B\\SQLEXPRESS; Initial Catalog =QLDA; UID = sa; PWD = 123; ");
            try
            {
                conn.Open();
                string sql = "select * from DM_User where TaiKhoan='" + tbTenDangNhap.Text + "' and MatKhau='" + tbMatKhau.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbTenDangNhap.Focus();
                    tbTenDangNhap.SelectAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối!!");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
                Application.Exit();
        }
        private void button1_MouseHover_1(object sender, EventArgs e)
        {
            if (tbMatKhau.PasswordChar == '*')
            {
                tbMatKhau.BringToFront();
                tbMatKhau.PasswordChar = '\0';
            }
        }

        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            if (tbMatKhau.PasswordChar == '\0')
            {
                tbMatKhau.BringToFront();
                tbMatKhau.PasswordChar = '*';
            }
        }

        private void Test_DangNhap_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}