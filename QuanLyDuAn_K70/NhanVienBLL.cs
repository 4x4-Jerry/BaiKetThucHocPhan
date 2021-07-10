using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class NhanVienBLL
    {
        NhanVienDAL dalNV;
        public NhanVienBLL()
        {
            dalNV = new NhanVienDAL();
        }
        public DataTable getALLNhanVien()
        {
            return dalNV.getALLNhanVien();
        }
        public bool InsertNhanVien(DM_NhanVien nv)
        {
            return dalNV.InsertNhanVien(nv);
        }
        public bool UpdateNhanVien(DM_NhanVien nv, string ma_nv_cu)
        {
            return dalNV.UpdateNhanVien(nv, ma_nv_cu);
        }
        public bool DeleteNhanVien(DM_NhanVien nv)
        {
            return dalNV.DeleteNhanVien(nv);
        }
        public DataTable FindNhanVien(String nv)
        {
            return dalNV.FindNhanVien(nv);
        }

        public DataTable CheckNhanVien(String nv)
        {
            return dalNV.CheckNhanVien(nv);
        }

    }
}
