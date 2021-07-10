using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class SoDuDauKyDAL
    {

        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public SoDuDauKyDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getALLSoDuDauKy()
        {
            string sql = "SELECT * FROM view_SDDK ORDER BY MaDA";

            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public bool InsertSoDuDauKy(DM_SoDuDauKy sd)
        {
            string sql = "INSERT INTO DM_SoDuDauKy(MaDA,MaKH,GiaTriBD) VALUES(@MaDA,@MaKH,@GiaTriBD)";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = sd.MaDA;
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = sd.MaKH;
                cmd.Parameters.Add("@GiaTriBD", SqlDbType.Char).Value = sd.GiaTriBD;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateSoDuDauKy(DM_SoDuDauKy sd, string ma_da_cu,string ma_kh_cu)
        {
            string sql = "UPDATE DM_SoDuDauKy SET MaDA = @MaDA, MaKH= @MaKH,GiaTriBD = @GiaTriBD WHERE MaDA =@MaDA_cu and MaKH=@MaKH_cu";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = sd.MaDA;
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = sd.MaKH;
                cmd.Parameters.Add("@MaDA_cu", SqlDbType.Char).Value = ma_da_cu;
                cmd.Parameters.Add("@MaKH_cu", SqlDbType.Char).Value = ma_kh_cu;
                cmd.Parameters.Add("@GiaTriBD", SqlDbType.Char).Value = sd.GiaTriBD;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public bool DeleteSoDuDauKy(DM_SoDuDauKy sd)
        {
            string sql = "DELETE DM_SoDuDauKy  WHERE MaDA =@MaDA";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = sd.MaDA;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public DataTable FindSoDuDauKy(String sd)
        {
            string sql = "SELECT MaDA,MaKH FROM DM_SoDuDauKy WHERE MaKH like N'%" + sd + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable CheckMaDA(String da,string kh)
        {
            string sql = "SELECT MaDA FROM DM_SoDuDauKy WHERE MaDA ='" + da + "'and MaKH ='" + kh + "'";
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
