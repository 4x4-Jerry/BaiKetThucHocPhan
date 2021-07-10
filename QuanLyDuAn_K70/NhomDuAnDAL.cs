using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class NhomDuAnDAL
    {

        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public NhomDuAnDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getALLNhomDuAn()
        {
            string sql = "SELECT * FROM DM_NhomDuAn ORDER BY MaNDA";

            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public bool InsertNhomDuAn(DM_NhomDuAn nda)
        {
            string sql = "INSERT INTO DM_NhomDuAn(MaNDA,TenNDA) VALUES(@MaNDA,@TenNDA)";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNDA", SqlDbType.Char).Value = nda.MaNDA;
                cmd.Parameters.Add("@TenNDA", SqlDbType.NVarChar).Value = nda.TenNDA;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateNhomDuAn(DM_NhomDuAn nda, string ma_nda_cu)
        {
            string sql = "UPDATE DM_NhomDuAn SET MaNDA = @MaNDA, TenNDA= @TenNDA WHERE MaNDA =@MaNDA_cu";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNDA", SqlDbType.Char).Value = nda.MaNDA;
                cmd.Parameters.Add("@TenNDA", SqlDbType.NVarChar).Value = nda.TenNDA;
                cmd.Parameters.Add("@MaNDA_cu", SqlDbType.Char).Value = ma_nda_cu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public bool DeleteNhomDuAn(DM_NhomDuAn nda)
        {
            string sql = "DELETE DM_NhomDuAn  WHERE MaNDA =@MaNDA";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaNDA", SqlDbType.Char).Value = nda.MaNDA;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public DataTable FindNhomDuAn(String nda)
        {
            string sql = "SELECT MaNDA,TenNDA FROM DM_NhomDuAn WHERE TenNDA like N'%" + nda + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable CheckNhomDuAn(String nda)
        {
            string sql = "SELECT MaNDA FROM DM_NhomDuAn WHERE MaNDA ='" + nda + "'";
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
