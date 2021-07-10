using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class SoDuDauKyBLL
    {
        SoDuDauKyDAL dalSDDK;
        public SoDuDauKyBLL()
        {
            dalSDDK = new SoDuDauKyDAL();
        }
        public DataTable getALLSoDuDauKy()
        {
            return dalSDDK.getALLSoDuDauKy();
        }
        public bool InsertSoDuDauKy(DM_SoDuDauKy sd)
        {
            return dalSDDK.InsertSoDuDauKy(sd);
        }
        public bool UpdateSoDuDauKy(DM_SoDuDauKy sd, string ma_sd_cu,string ma_kh_cu)
        {
            return dalSDDK.UpdateSoDuDauKy(sd, ma_sd_cu, ma_kh_cu);
        }
        public bool DeleteSoDuDauKy(DM_SoDuDauKy sd)
        {
            return dalSDDK.DeleteSoDuDauKy(sd);
        }
        public DataTable FindSoDuDauKy(String sd)
        {
            return dalSDDK.FindSoDuDauKy(sd);
        }
        public DataTable CheckMaDA(String da, String kh)
        {
            return dalSDDK.CheckMaDA(da,kh);
        }
        public DataTable CheckDuAnPhatSinh(String duan)
        {
            return dalSDDK.CheckDuAnPhatSinh(duan);
        }
    }
}
