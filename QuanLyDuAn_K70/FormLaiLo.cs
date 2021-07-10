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
    public partial class FormLaiLo : Form
    {
        DataConnection dc;
        SqlDataAdapter da;
        thuoctinh tt = new thuoctinh();
        public FormLaiLo()
        {
            dc = new DataConnection();
            InitializeComponent();

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
        public DataTable getALLLaiLo(string tenduan)
        {
            SqlCommand cmd;
            SqlConnection con = dc.getConnect();

            string thucthi = " exec TinhLaiLoDuAn @TenDuAn ";
            cmd = new SqlCommand(thucthi, con);
            cmd.Parameters.Add("@TenDuAn", SqlDbType.NVarChar).Value = tenduan;
            con.Open();
            SqlDataReader lDr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(lDr);
            con.Close();
            return dt;
        }

        public void ShowALLLaiLo()
        {
            dtLaiLo.DataSource = getALLLaiLo("");
        }
        private void FormLaiLo_Load(object sender, EventArgs e)
        {
            ShowALLLaiLo();
        }

        public DataTable FindTenDA(String duan)
        {
            string sql = "SELECT * FROM @DuAn WHERE TenDA like N'%" + duan + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = getALLLaiLo(value);
                dtLaiLo.DataSource = dt;
            }
            else
          if (tbTimKiem.Text == null || tbTimKiem.Text == "")
                ShowALLLaiLo();
        }

        private void btChiTiet_Click(object sender, EventArgs e)
        {
            ChiTiet_LaiLo f = new ChiTiet_LaiLo(tt);
            f.Show();
        }
        private void dtLaiLo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                tt.MaDA = dtLaiLo.Rows[index].Cells["MaDA"].Value.ToString().Trim();
                tt.TenDA = dtLaiLo.Rows[index].Cells["TenDA"].Value.ToString().Trim();
                tt.LaiLo = dtLaiLo.Rows[index].Cells["LaiLo"].Value.ToString().Trim();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestExcel testexcel = new TestExcel();
            ExportReport exportexcel = new ExportReport();
            ExportToExcel excel = new ExportToExcel();
            // Lấy về nguồn dữ liệu cần Export là 1 DataTable
            // DataTable này mỗi bạn lấy mỗi khác. 
            // Ở đây tôi dùng BindingSouce có tên bs nên tôi ép kiểu như sau:
            // Bạn nào gán trực tiếp vào DataGridView thì ép kiểu DataSource của
            // DataGridView nhé 
            DataTable dt = (DataTable)dtLaiLo.DataSource;
           exportexcel.ExportExcel(dt);
            MessageBox.Show("Xuất file thành công. File được lưu ở Destop","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.None);
            //testexcel.ExportExcel(dt);
            //excel.Export(dt, "Danh sách", "DOANH THU CÁC DỰ ÁN");
        }
    }
}
