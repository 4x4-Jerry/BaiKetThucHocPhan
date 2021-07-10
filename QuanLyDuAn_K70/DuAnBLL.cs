using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class DuAnBLL
    {
        DuAnDAL dalDA;
        public DuAnBLL()
        {
            dalDA = new DuAnDAL();
        }
        public DataTable getALLDuAn()
        {
            return dalDA.getALLDuAn();
        }
        public bool InsertDuAn(DM_DuAn duan)
        {
            return dalDA.InsertDuAn(duan);
        }
        public bool UpdateDuAn(DM_DuAn duan, string ma_da_cu)
        {
            return dalDA.UpdateDuAn(duan, ma_da_cu);
        }
        public bool DeleteDuAn(DM_DuAn duan)
        {
            return dalDA.DeleteDuAn(duan);
        }
        public DataTable FindDuAn(String duan)
        {
            return dalDA.FindDuAn(duan);
        }

        public DataTable CheckDuAn(String duan)
        {
            return dalDA.CheckDuAn(duan);
        }
        public DataTable CheckDuAnPhatSinh(String duan)
        {
            return dalDA.CheckDuAnPhatSinh(duan);
        }

    }
    }

