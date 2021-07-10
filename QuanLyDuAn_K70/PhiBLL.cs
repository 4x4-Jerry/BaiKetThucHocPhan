using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class PhiBLL
    {
        PhiDAL dalPhi;
        public PhiBLL()
        {
            dalPhi = new PhiDAL();
        }
        public DataTable getALLPhi()
        {
            return dalPhi.getALLPhi();
        }
        public bool InsertPhi(DM_Phi phi)
        {
            return dalPhi.InsertPhi(phi);
        }
        public bool UpdatePhi(DM_Phi phi, string ma_phi_cu)
        {
            return dalPhi.UpdatePhi(phi, ma_phi_cu);
        }
        public bool DeletePhi(DM_Phi phi)
        {
            return dalPhi.DeletePhi(phi);
        }
        public DataTable FindPhi(String phi)
        {
            return dalPhi.FindPhi(phi);
        }

        public DataTable CheckPhi(String phi)
        {
            return dalPhi.CheckPhi(phi);
        }

    }
}
