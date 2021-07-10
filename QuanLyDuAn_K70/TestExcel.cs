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
    public class TestExcel
    {
        thuoctinh tt = new thuoctinh();
        public void ExportExcel(DataTable lstDoanhThu)
        {
            for (int i = 0; i < lstDoanhThu.Rows.Count; i++)
            {
                tt.MaDA = lstDoanhThu.Rows[i]["MaDA"].ToString();
                tt.TenDA = lstDoanhThu.Rows[i]["TenDA"].ToString();
                tt.LaiLo = lstDoanhThu.Rows[i]["LaiLo"].ToString();

            }
            //Export excel
            XLWorkbook workbook = new XLWorkbook();
            DataTable dt = new DataTable() { TableName = "Doanh thu" };
            DataSet ds = new DataSet();

            //input data
            var columns = new[] { "MaDA", "TenDA", "LaiLo" };

            //Add columns
            dt.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());

            //Add rows
            //foreach (var row in )
            //{
            //    dt.Rows.Add(row.MaDuAn, row.TenDuAn, row.DoanhThuDA);
            //}
            //Convert datatable to dataset and add it to the workbook as worksheet
            ds.Tables.Add(dt);
            workbook.Worksheets.Add(ds);

            //save
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string savePath = Path.Combine(desktopPath, "Báo cáo doanh thu dự án.xlsx");
            workbook.SaveAs(savePath, false);
        }

    }
}

