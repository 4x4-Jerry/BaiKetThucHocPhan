using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class NhapPhiDAL
    {

        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public NhapPhiDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getALLNhapPhi()
        {
            string sql = "SELECT * FROM view_NP ORDER BY MaDA";

            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public bool InsertNhapPhi(DM_NhapPhi np)
        {
            string sql = "INSERT INTO DM_NhapPhi(MaDA,MaPhi,ChiPhi) VALUES(@MaDA,@MaPhi,@ChiPhi)";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = np.MaDA;
                cmd.Parameters.Add("@MaPhi", SqlDbType.Char).Value = np.MaPhi;
                cmd.Parameters.Add("@ChiPhi", SqlDbType.Char).Value = np.ChiPhi;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateNhapPhi(DM_NhapPhi np, string ma_da_cu,string ma_phi_cu)
        {
            string sql = "UPDATE DM_NhapPhi SET MaDA = @MaDA, MaPhi= @MaPhi,ChiPhi = @ChiPhi WHERE MaDA =@MaDA_cu and MaPhi=@MaPhi_cu";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = np.MaDA;
                cmd.Parameters.Add("@MaPhi", SqlDbType.Char).Value = np.MaPhi;
                cmd.Parameters.Add("@MaDA_cu", SqlDbType.Char).Value = ma_da_cu;
                cmd.Parameters.Add("@MaPhi_cu", SqlDbType.Char).Value = ma_phi_cu;
                cmd.Parameters.Add("@ChiPhi", SqlDbType.Char).Value = np.ChiPhi;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public bool DeleteNhapPhi(DM_NhapPhi np)
        {
            string sql = "DELETE DM_NhapPhi  WHERE MaDA =@MaDA";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = np.MaDA;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public DataTable FindNhapPhi(String np)
        {
            string sql = "SELECT MaDA,MaPhi FROM DM_NhapPhi WHERE MaPhi like N'%" + np + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable CheckMaDA(String np, string phi)
        {
            string sql = "SELECT MaDA,MaPhi FROM DM_NhapPhi WHERE MaDA ='" + np + "' and MaPhi ='" + phi + "'";
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
