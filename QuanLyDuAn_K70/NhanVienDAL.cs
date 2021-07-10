using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class NhanVienDAL
    {

        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public NhanVienDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getALLNhanVien()
        {
            string sql = "SELECT * FROM DM_NhanVien ORDER BY MaNV";

            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public bool InsertNhanVien(DM_NhanVien nv)
        {
            string sql = "INSERT INTO DM_NhanVien(MaNV,TenNV) VALUES(@MaNV,@TenNV)";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = nv.MaNV;
                cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nv.TenNV;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateNhanVien(DM_NhanVien nv, string ma_nv_cu)
        {
            string sql = "UPDATE DM_NhanVien SET MaNV = @MaNV, TenNV= @TenNV WHERE MaNV =@MaNV_cu";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = nv.MaNV;
                cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nv.TenNV;
                cmd.Parameters.Add("@MaNV_cu", SqlDbType.Char).Value = ma_nv_cu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public bool DeleteNhanVien(DM_NhanVien nv)
        {
            string sql = "DELETE DM_NhanVien  WHERE MaNV =@MaNV";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = nv.MaNV;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public DataTable FindNhanVien(String nv)
        {
            string sql = "SELECT MaNV,TenNV FROM DM_NhanVien WHERE TenNV like N'%" + nv + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable CheckNhanVien(String nv)
        {
            string sql = "SELECT MaNV FROM DM_NhanVien WHERE MaNV ='" + nv + "'";
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
