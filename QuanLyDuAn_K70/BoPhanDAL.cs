using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class BoPhanDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public BoPhanDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getALLBoPhan()
        {
            string sql = "SELECT * FROM DM_BoPhan ORDER BY MaBP";

            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public bool InsertBoPhan(DM_BoPhan bp)
        {
            string sql = "INSERT INTO DM_BoPhan(MaBP,TenBP) VALUES(@MaBP,@TenBP)";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaBP", SqlDbType.Char).Value = bp.MaBP;
                cmd.Parameters.Add("@TenBP", SqlDbType.NVarChar).Value = bp.TenBP;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateBoPhan(DM_BoPhan bp, string ma_bp_cu)
        {
            string sql = "UPDATE DM_BoPhan SET MaBP = @MaBP, TenBP= @TenBP WHERE MaBP =@MaBP_cu";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaBP", SqlDbType.Char).Value = bp.MaBP;
                cmd.Parameters.Add("@TenBP", SqlDbType.NVarChar).Value = bp.TenBP;
                cmd.Parameters.Add("@MaBP_cu", SqlDbType.Char).Value = ma_bp_cu;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public bool DeleteBoPhan(DM_BoPhan bp)
        {
            string sql = "DELETE DM_BoPhan  WHERE MaBP =@MaBP";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaBP", SqlDbType.Char).Value = bp.MaBP;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public DataTable FindBoPhan(String bp)
        {
            string sql = "SELECT MaBP,TenBP FROM DM_BoPhan WHERE TenBP like N'%" + bp + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable CheckBoPhan(String bp)
        {
            string sql = "SELECT MaBP FROM DM_BoPhan WHERE MaBP ='" + bp + "'";
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
   
