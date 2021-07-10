using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class PhiDAL
    {

        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public PhiDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getALLPhi()
        {
            string sql = "SELECT * FROM DM_Phi ORDER BY MaPhi";

            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public bool InsertPhi(DM_Phi phi)
        {
            string sql = "INSERT INTO DM_Phi(MaPhi,TenPhi) VALUES(@MaPhi,@TenPhi)";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaPhi", SqlDbType.Char).Value = phi.MaPhi;
                cmd.Parameters.Add("@TenPhi", SqlDbType.NVarChar).Value = phi.TenPhi;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdatePhi(DM_Phi phi, string ma_phi_cu)
        {
            string sql = "UPDATE DM_Phi SET MaPhi = @MaPhi, TenPhi= @TenPhi WHERE MaPhi =@MaPhi_cu";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaPhi", SqlDbType.Char).Value = phi.MaPhi;
                cmd.Parameters.Add("@TenPhi", SqlDbType.NVarChar).Value = phi.TenPhi;
                cmd.Parameters.Add("@MaPhi_cu", SqlDbType.Char).Value = ma_phi_cu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public bool DeletePhi(DM_Phi phi)
        {
            string sql = "DELETE DM_Phi  WHERE MaPhi =@MaPhi";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaPhi", SqlDbType.Char).Value = phi.MaPhi;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public DataTable FindPhi(String phi)
        {
            string sql = "SELECT MaPhi,TenPhi FROM DM_Phi WHERE TenPhi like N'%" + phi + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable CheckPhi(String phi)
        {
            string sql = "SELECT MaPhi FROM DM_Phi WHERE MaPhi ='" + phi + "'";
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
