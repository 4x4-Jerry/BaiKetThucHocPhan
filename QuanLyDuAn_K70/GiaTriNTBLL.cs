using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class GiaTriNTBLL
    {
        GiaTriNTDAL dalGTNT;
        public GiaTriNTBLL()
        {
            dalGTNT = new GiaTriNTDAL();
        }
        public DataTable getALLGiaTriNT()
        {
            return dalGTNT.getALLGiaTriNT();
        }
        public bool InsertGiaTriNT(DM_GiaTriNT gt)
        {
            return dalGTNT.InsertGiaTriNT(gt);
        }
        public bool UpdateGiaTriNT(DM_GiaTriNT gt, string ma_gd_cu,string ma_da_cu)
        {
            return dalGTNT.UpdateGiaTriNT(gt, ma_gd_cu, ma_da_cu);
        }
        public bool DeleteGiaTriNT(DM_GiaTriNT gt)
        {
            return dalGTNT.DeleteGiaTriNT(gt);
        }
        public DataTable FindGiaTriNT(String gt)
        {
            return dalGTNT.FindGiaTriNT(gt);
        }

        public DataTable Checkthuphi(String gd,string duan)
        {
            return dalGTNT.Checkthuphi(gd, duan);
        }
        public DataTable CheckDuAnPhatSinh( string duan)
        {
            return dalGTNT.CheckDuAnPhatSinh( duan);
        }
    }
}
