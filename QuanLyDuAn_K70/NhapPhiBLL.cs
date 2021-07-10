using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class NhapPhiBLL
    {
        NhapPhiDAL dalNP;
        public NhapPhiBLL()
        {
            dalNP = new NhapPhiDAL();
        }
        public DataTable getALLNhapPhi()
        {
            return dalNP.getALLNhapPhi();
        }
        public bool InsertNhapPhi(DM_NhapPhi np)
        {
            return dalNP.InsertNhapPhi(np);
        }
        public bool UpdateNhapPhi(DM_NhapPhi np, string ma_da_cu,string ma_phi_cu)
        {
            return dalNP.UpdateNhapPhi(np, ma_da_cu, ma_phi_cu);
        }
        public bool DeleteNhapPhi(DM_NhapPhi np)
        {
            return dalNP.DeleteNhapPhi(np);
        }
        public DataTable FindNhapPhi(String np)
        {
            return dalNP.FindNhapPhi(np);
        }
        public DataTable CheckMaDA(String np, String phi)
        {
            return dalNP.CheckMaDA(np, phi);
        }
        public DataTable CheckDuAnPhatSinh(String duan)
        {
            return dalNP.CheckDuAnPhatSinh(duan);
        }
    }
}
