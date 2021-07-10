using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class BoPhanBLL
    {
        BoPhanDAL dalBP;
        public BoPhanBLL()
        {
            dalBP = new BoPhanDAL();
        }
        public DataTable getALLBoPhan()
        {
            return dalBP.getALLBoPhan();
        }
        public bool InsertBoPhan(DM_BoPhan bp)
        {
            return dalBP.InsertBoPhan(bp);
        }
        public bool UpdateBoPhan(DM_BoPhan bp, string ma_bp_cu)
        {
            return dalBP.UpdateBoPhan(bp, ma_bp_cu);
        }
        public bool DeleteBoPhan(DM_BoPhan bp)
        {
            return dalBP.DeleteBoPhan(bp);
        }
        public DataTable FindBoPhan(String bp)
        {
            return dalBP.FindBoPhan(bp);
        }

        public DataTable CheckBoPhan(String bp)
        {
            return dalBP.CheckBoPhan(bp);
        }


    }
}
