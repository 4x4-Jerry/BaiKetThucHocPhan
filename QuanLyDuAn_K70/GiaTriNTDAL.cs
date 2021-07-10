using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class GiaTriNTDAL
    {

        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public GiaTriNTDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getALLGiaTriNT()
        {
            string sql = "SELECT * FROM view_GTNT ORDER BY MaDA";

            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public bool InsertGiaTriNT(DM_GiaTriNT gt)
        {
            string sql = "INSERT INTO DM_GiaTriNT(MaDa,MaGD,StartDayGD,FinalDayGD,GiaTriNT) VALUES(@MaDA,@MaGD,@StartDayGD,@FinalDayGD,@GiaTriNT)";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = gt.MaDA;
                cmd.Parameters.Add("@MaGD", SqlDbType.NVarChar).Value = gt.MaGD;
                cmd.Parameters.Add("@StartDayGD", SqlDbType.Char).Value = gt.StartDayGD;
                cmd.Parameters.Add("@FinalDayGD", SqlDbType.Char).Value = gt.FinalDayGD;
                cmd.Parameters.Add("@GiaTriNT", SqlDbType.Char).Value = gt.GiaTriNT;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateGiaTriNT(DM_GiaTriNT gt, string ma_gd_cu,string ma_da_cu)
        {
            string sql = "UPDATE DM_GiaTriNT SET MaDA = @MaDA, MaGD= @MaGD,StartDayGD=@StartDayGD,FinalDayGD=@FinalDayGD,GiaTriNT=@GiaTriNT WHERE MaGD =@MaGD_cu and MaDA=@MaDA_cu";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = gt.MaDA;
                cmd.Parameters.Add("@MaGD", SqlDbType.NVarChar).Value = gt.MaGD;
                cmd.Parameters.Add("@StartDayGD", SqlDbType.Char).Value = gt.StartDayGD;
                cmd.Parameters.Add("@FinalDayGD", SqlDbType.Char).Value = gt.FinalDayGD;
                cmd.Parameters.Add("@GiaTriNT", SqlDbType.Char).Value = gt.GiaTriNT;
                cmd.Parameters.Add("@MaGD_cu", SqlDbType.Char).Value = ma_gd_cu;
                cmd.Parameters.Add("@MaDA_cu", SqlDbType.Char).Value = ma_da_cu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public bool DeleteGiaTriNT(DM_GiaTriNT gt)
        {
            string sql = "DELETE DM_GiaTriNT  WHERE MaGD =@MaGD";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaGD", SqlDbType.Char).Value = gt.MaGD;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public DataTable FindGiaTriNT(String gt)
        {
            string sql = "SELECT MaDA,MaGD,StartDayGD,FinalDayGD FROM DM_GiaTriNT WHERE MaGD like N'%" + gt + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Checkthuphi(String gd,string duan)
        {
            string sql = "SELECT MaGD FROM DM_GiaTriNT WHERE MaGD ='" + gd + "'and MaDA ='" + duan + "'";
            SqlConnection con = dc.getConnect();
            cmd = new SqlCommand(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }
        public DataTable CheckDuAnPhatSinh(String duan)
        {
            string sql = "SELECT MaDA FROM DM_GiaTriNT WHERE MaDA ='" + duan + "' UNION SELECT MaDA FROM DM_SoDuDauKy WHERE MaDA ='" + duan + "' UNION SELECT MaDA FROM DM_NhapPhi WHERE MaDA ='" + duan + "'";

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
