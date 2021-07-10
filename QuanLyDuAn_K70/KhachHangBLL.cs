using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class KhachHangBLL
    {
        KhachHangDAL dalKH;
        public KhachHangBLL()
        {
            dalKH = new KhachHangDAL();
        }
        public DataTable getALLKhachHang()
        {
            return dalKH.getALLKhachHang();
        }
        public bool InsertKhachHang(DM_KhachHang kh)
        {
            return dalKH.InsertKhachHang(kh);
        }
        public bool UpdateKhachHang(DM_KhachHang kh, string ma_kh_cu)
        {
            return dalKH.UpdateKhachHang(kh, ma_kh_cu);
        }
        public bool DeleteKhachHang(DM_KhachHang kh)
        {
            return dalKH.DeleteKhachHang(kh);
        }
        public DataTable FindKhachHang(String kh)
        {
            return dalKH.FindKhachHang(kh);
        }

        public DataTable CheckKhachHang(String kh)
        {
            return dalKH.CheckKhachHang(kh);
        }
        public DataTable CheckEmail(String kh)
        {
            return dalKH.CheckEmail(kh);
        }

        public DataTable CheckDienThoai(String kh)
        {
            return dalKH.CheckDienThoai(kh);
        }
    }
}
