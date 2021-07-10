using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class GiaiDoanBLL
    {
        GiaiDoanDAL dalGD;
        public GiaiDoanBLL()
        {
            dalGD = new GiaiDoanDAL();
        }
        public DataTable getALLGiaiDoan()
        {
            return dalGD.getALLGiaiDoan();
        }
        public bool InsertGiaiDoan(DM_GiaiDoan gd)
        {
            return dalGD.InsertGiaiDoan(gd);
        }
        public bool UpdateGiaiDoan(DM_GiaiDoan cn, string ma_gd_cu)
        {
            return dalGD.UpdateGiaiDoan(cn,ma_gd_cu);
        }
        public bool DeleteGiaiDoan(DM_GiaiDoan gd)
        {
            return dalGD.DeleteGiaiDoan(gd);
        }
        public DataTable FindGiaiDoan(String gd)
        {
            return dalGD.FindGiaiDoan(gd);
        }

        public DataTable CheckGiaiDoan(String gd)
        {
            return dalGD.CheckGiaiDoan(gd);
        }

    }
}
