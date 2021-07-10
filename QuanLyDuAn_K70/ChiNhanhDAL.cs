using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class ChiNhanhDAL
    {

        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public ChiNhanhDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getALLChiNhanh()
        {
            string sql = "SELECT * FROM DM_ChiNhanh ORDER BY MaCN";

            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public bool InsertChiNhanh(DM_ChiNhanh cn)
        {
            string sql = "INSERT INTO DM_ChiNhanh(MaCN,TenCN) VALUES(@MaCN,@TenCN)";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaCN", SqlDbType.Char).Value = cn.MaCN;
                cmd.Parameters.Add("@TenCN", SqlDbType.NVarChar).Value = cn.TenCN;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateChiNhanh(DM_ChiNhanh cn, string ma_cn_cu)
        {
            string sql = "UPDATE DM_ChiNhanh SET MaCN = @MaCN, TenCN= @TenCN WHERE MaCN =@MaCN_cu";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaCN", SqlDbType.Char).Value = cn.MaCN;
                cmd.Parameters.Add("@TenCN", SqlDbType.NVarChar).Value = cn.TenCN;
                cmd.Parameters.Add("@MaCN_cu", SqlDbType.Char).Value = ma_cn_cu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public bool DeleteChiNhanh(DM_ChiNhanh cn)
        {
            string sql = "DELETE DM_ChiNhanh  WHERE MaCN =@MaCN";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaCN", SqlDbType.Char).Value = cn.MaCN;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public DataTable FindChiNhanh(String cn)
        {
            string sql = "SELECT MaCN,TenCN FROM DM_ChiNhanh WHERE TenCN like N'%" + cn + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable CheckChiNhanh(String cn)
        {
            string sql = "SELECT MaCN FROM DM_ChiNhanh WHERE MaCN ='" + cn + "'";
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
