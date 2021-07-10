using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class KhachHangDAL
    {

        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public KhachHangDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getALLKhachHang()
        {
            string sql = "SELECT * FROM DM_KhachHang ORDER BY MaKH";

            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public bool InsertKhachHang(DM_KhachHang kh)
        {
            string sql = "INSERT INTO DM_KhachHang(MaKH,TenKH,DiaChi,DoiTac,DienThoai,Email,Fax,GhiChu) VALUES(@MaKH,@TenKH,@DiaChi,@DoiTac,@DienThoai,@Email,@Fax,@GhiChu)";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = kh.MaKH;
                cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = kh.TenKH;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = kh.DiaChi;
                cmd.Parameters.Add("@DoiTac", SqlDbType.NVarChar).Value = kh.DoiTac;
                cmd.Parameters.Add("@DienThoai", SqlDbType.Char).Value = kh.DienThoai;
                cmd.Parameters.Add("@Email", SqlDbType.Char).Value = kh.Email;
                cmd.Parameters.Add("@Fax", SqlDbType.Char).Value = kh.Fax;
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = kh.GhiChu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateKhachHang(DM_KhachHang kh, string ma_kh_cu)
        {
            string sql = "UPDATE DM_KhachHang SET MaKH = @MaKH, TenKH= @TenKH,DiaChi=@DiaChi,DoiTac=@DoiTac,DienThoai=@DienThoai,Email=@Email,Fax=@Fax,GhiChu=@GhiChu WHERE MaKH =@MaKH_cu";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = kh.MaKH;
                cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = kh.TenKH;
                cmd.Parameters.Add("@MaKH_cu", SqlDbType.Char).Value = ma_kh_cu;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = kh.DiaChi;
                cmd.Parameters.Add("@DoiTac", SqlDbType.NVarChar).Value = kh.DoiTac;
                cmd.Parameters.Add("@DienThoai", SqlDbType.Char).Value = kh.DienThoai;
                cmd.Parameters.Add("@Email", SqlDbType.Char).Value = kh.Email;
                cmd.Parameters.Add("@Fax", SqlDbType.Char).Value = kh.Fax;
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = kh.GhiChu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public bool DeleteKhachHang(DM_KhachHang kh)
        {
            string sql = "DELETE DM_KhachHang  WHERE MaKH =@MaKH";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = kh.MaKH;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public DataTable FindKhachHang(String kh)
        {
            string sql = "SELECT MaKH,TenKH,DiaChi,DoiTac,DienThoai,Email,Fax,GhiChu FROM DM_KhachHang WHERE TenKH like N'%" + kh + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        

        public DataTable CheckKhachHang(String kh)
        {
            string sql = "SELECT MaKH FROM DM_KhachHang WHERE MaKH ='" + kh + "'";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }
        public DataTable CheckEmail(String kh)
        {
            string sql = "SELECT Email FROM DM_KhachHang WHERE Email ='" + kh + "'";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }
        public DataTable CheckDienThoai(String kh)
        {
            string sql = "SELECT DienThoai FROM DM_KhachHang WHERE DienThoai ='" + kh + "'";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }
    }

}
