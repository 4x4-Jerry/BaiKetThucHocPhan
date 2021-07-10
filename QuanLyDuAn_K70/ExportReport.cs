using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn_K70
{
    class ExportReport
    {
        public void ExportExcel(DataTable lstDoanhThu)
        {
            List<DoanhThu> result = new List<DoanhThu>();
            for (int i = 0; i < lstDoanhThu.Rows.Count; i++)
            {
                DoanhThu itemDT = new DoanhThu();
                itemDT.MaDuAn = lstDoanhThu.Rows[i]["MaDA"].ToString();
                itemDT.TenDuAn = lstDoanhThu.Rows[i]["TenDA"].ToString();
                itemDT.DoanhThuDA = lstDoanhThu.Rows[i]["LaiLo"].ToString();
                result.Add(itemDT);
            }
            //Export excel
            XLWorkbook workbook = new XLWorkbook();
            DataTable dt = new DataTable() { TableName = "Doanh thu" };
            DataSet ds = new DataSet();

            //input data
            var columns = new[] { "Mã dự án", "Tên dự án", "Doanh thu" };
            
            //Add columns
            dt.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());
             
           
            //Add rows

            foreach (var row in result)
            {
                dt.Rows.Add(row.MaDuAn, row.TenDuAn, row.DoanhThuDA);
            }
            
            //Convert datatable to dataset and add it to the workbook as worksheet
            ds.Tables.Add(dt);
            workbook.Worksheets.Add(ds.Tables[0],"Doanh thu");
            IXLWorksheet Worksheet = workbook.Worksheet("Doanh thu");

            Worksheet.Columns(2, 20).AdjustToContents();
           
            Worksheet.Row(1).Style.Alignment.WrapText = true;
            Worksheet.Column(2).Width= 40;
            Worksheet.RowHeight = 13.5;

            //save
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string savePath = Path.Combine(desktopPath, "Báo cáo doanh thu dự án.xlsx");


            workbook.SaveAs(savePath, false);
            
        }
        public class DoanhThu
        {
            public string MaDuAn { get; set; }
            public string TenDuAn { get; set; }
            public string DoanhThuDA { get; set; }
        }
    }
}
