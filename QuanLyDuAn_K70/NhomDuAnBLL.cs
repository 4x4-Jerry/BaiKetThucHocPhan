using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class NhomDuAnBLL
    {
        NhomDuAnDAL dalNDA;
        public NhomDuAnBLL()
        {
            dalNDA = new NhomDuAnDAL();
        }
        public DataTable getALLNhomDuAn()
        {
            return dalNDA.getALLNhomDuAn();
        }
        public bool InsertNhomDuAn(DM_NhomDuAn nda)
        {
            return dalNDA.InsertNhomDuAn(nda);
        }
        public bool UpdateNhomDuAn(DM_NhomDuAn nda, string ma_nda_cu)
        {
            return dalNDA.UpdateNhomDuAn(nda, ma_nda_cu);
        }
        public bool DeleteNhomDuAn(DM_NhomDuAn nda)
        {
            return dalNDA.DeleteNhomDuAn(nda);
        }
        public DataTable FindNhomDuAn(String nda)
        {
            return dalNDA.FindNhomDuAn(nda);
        }

        public DataTable CheckNhomDuAn(String nda)
        {
            return dalNDA.CheckNhomDuAn(nda);
        }

    }
}
