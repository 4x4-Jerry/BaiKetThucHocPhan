using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class ChiNhanhBLL
    {
        ChiNhanhDAL dalCN;
        public ChiNhanhBLL()
        {
            dalCN = new ChiNhanhDAL();
        }
        public DataTable getALLChiNhanh()
        {
            return dalCN.getALLChiNhanh();
        }
        public bool InsertChiNhanh(DM_ChiNhanh cn)
        {
            return dalCN.InsertChiNhanh(cn);
        }
        public bool UpdateChiNhanh(DM_ChiNhanh cn, string ma_cn_cu)
        {
            return dalCN.UpdateChiNhanh(cn,ma_cn_cu);
        }
        public bool DeleteChiNhanh(DM_ChiNhanh cn)
        {
            return dalCN.DeleteChiNhanh(cn);
        }
        public DataTable FindChiNhanh(String cn)
        {
            return dalCN.FindChiNhanh(cn);
        }

        public DataTable CheckChiNhanh(String cn)
        {
            return dalCN.CheckChiNhanh(cn);
        }

    }
}
