using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class GiaiDoanDAL
    {

        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public GiaiDoanDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getALLGiaiDoan()
        {
            string sql = "SELECT * FROM DM_GiaiDoan ORDER BY MaGD";

            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public bool InsertGiaiDoan(DM_GiaiDoan gd)
        {
            string sql = "INSERT INTO DM_GiaiDoan(MaGD,TenGD) VALUES(@MaGD,@TenGD)";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaGD", SqlDbType.Char).Value = gd.MaGD;
                cmd.Parameters.Add("@TenGD", SqlDbType.NVarChar).Value = gd.TenGD;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateGiaiDoan(DM_GiaiDoan gd, string ma_gd_cu)
        {
            string sql = "UPDATE DM_GiaiDoan SET MaGD = @MaGD, TenGD= @TenGD WHERE MaGD =@MaGD_cu";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaGD", SqlDbType.Char).Value = gd.MaGD;
                cmd.Parameters.Add("@TenGD", SqlDbType.NVarChar).Value = gd.TenGD;
                cmd.Parameters.Add("@MaGD_cu", SqlDbType.Char).Value = ma_gd_cu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public bool DeleteGiaiDoan(DM_GiaiDoan gd)
        {
            string sql = "DELETE DM_GiaiDoan  WHERE MaGD =@MaGD";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaGD", SqlDbType.Char).Value = gd.MaGD;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public DataTable FindGiaiDoan(String gd)
        {
            string sql = "SELECT MaGD,TenGD FROM DM_GiaiDoan WHERE TenGD like N'%" + gd + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable CheckGiaiDoan(String gd)
        {
            string sql = "SELECT MaGD FROM DM_GiaiDoan WHERE MaGD ='" + gd + "'";
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
