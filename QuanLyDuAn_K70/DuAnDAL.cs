using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class DuAnDAL
    {

        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public DuAnDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getALLDuAn()
        {
            string sql = "SELECT * FROM view_duan2 ORDER BY MaDA";

            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public bool InsertDuAn(DM_DuAn duan)
        {
            string sql = "INSERT INTO DM_DuAn(MaDA,TenDA,MaCN,MaKH,MaNV,MaBP,GiaTriDA,MaNDA,StartDay,FinalDay,GhiChu) VALUES(@MaDA,@TenDA,@MaCN,@MaKH,@MaNV,@MaBP,@GiaTriDA,@MaNDA,@StartDay,@FinalDay,@GhiChu)";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = duan.MaDA;
                cmd.Parameters.Add("@TenDA", SqlDbType.NVarChar).Value = duan.TenDA;
                cmd.Parameters.Add("@MaCN", SqlDbType.Char).Value = duan.MaCN;
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = duan.MaKH;
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = duan.MaNV;
                cmd.Parameters.Add("@MaBP", SqlDbType.Char).Value = duan.MaBP;
                cmd.Parameters.Add("@GiaTriDA", SqlDbType.Char).Value = duan.GiaTriDA;
                cmd.Parameters.Add("@MaNDA", SqlDbType.Char).Value = duan.MaNDA;
                cmd.Parameters.Add("@StartDay", SqlDbType.Char).Value = duan.StartDay;
                cmd.Parameters.Add("@FinalDay", SqlDbType.Char).Value = duan.FinalDay;
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = duan.GhiChu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateDuAn(DM_DuAn duan, string ma_da_cu)
        {
            string sql = "UPDATE DM_DuAn SET MaDA = @MaDA, TenDA= @TenDA,MaCN=@MaCN,MaKH=@MaKH,MaNV=@MaNV,MaBP=@MaBP,GiaTriDA=@GiaTriDA,MaNDA=@MaNDA,StartDay=@StartDay,FinalDay=@FinalDay,GhiChu=@GhiChu WHERE MaDA =@MaDA_cu";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = duan.MaDA;
                cmd.Parameters.Add("@TenDA", SqlDbType.NVarChar).Value = duan.TenDA;
                cmd.Parameters.Add("@MaCN", SqlDbType.Char).Value = duan.MaCN;
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = duan.MaKH;
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = duan.MaNV;
                cmd.Parameters.Add("@MaBP", SqlDbType.Char).Value = duan.MaBP;
                cmd.Parameters.Add("@GiaTriDA", SqlDbType.Char).Value = duan.GiaTriDA;
                cmd.Parameters.Add("@MaNDA", SqlDbType.Char).Value = duan.MaNDA;
                cmd.Parameters.Add("@StartDay", SqlDbType.Char).Value = duan.StartDay;
                cmd.Parameters.Add("@FinalDay", SqlDbType.Char).Value = duan.FinalDay;
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = duan.GhiChu;
                cmd.Parameters.Add("@MaDA_cu", SqlDbType.NVarChar).Value = ma_da_cu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public bool DeleteDuAn(DM_DuAn duan)
        {
            string sql = "DELETE DM_DuAn  WHERE MaDA =@MaDA";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaDA", SqlDbType.Char).Value = duan.MaDA;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public DataTable FindDuAn(String duan)
        {
            string sql = "SELECT MaDA,TenDA,MaCN,MaKH,MaNV,MaBP,GiaTriDA,MaNDA,StartDay,FinalDay,GhiChu FROM DM_DuAn WHERE TenDA like N'%" + duan + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable CheckDuAn(String duan)
        {
            string sql = "SELECT MaDA FROM DM_DuAn WHERE MaDA ='" + duan + "'";
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
