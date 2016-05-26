using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace HelperUtility.Excel
{
    class GenerateExcel
    {
        //systemFunction.systemFunction mySys = new systemFunction.systemFunction();
        public void createExcel(DataTable dt)
        {
            //int headtextnum = 0;
            //Excel.Application app = new Excel.Application();
            //app = new Excel.Application();
            //app.Application.Workbooks.Add(true);
            //Excel.Workbook book = (Excel.Workbook)app.ActiveWorkbook;
            //Excel.Worksheet sheet = (Excel.Worksheet)book.ActiveSheet;

            //foreach (DataColumn dgvc in dt.Columns)
            //{
            //    headtextnum++;
            //    sheet.Cells[1, headtextnum] = dgvc.Caption;
            //}
            //for (int i = 0; i < dt.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        sheet.Cells[i + 2, j + 1] = "'" + dt.Rows[i][j].ToString();
            //    }
            //}
            //string strExePath = mySys.exePath();
            //book.SaveCopyAs(strExePath + @"\数据\Excel文件\"
            //    + DateTime.Now.ToString("yyyyMMddHHmmss") + "_转换.xls");
            //book.Close(false, Type.Missing, Type.Missing);
            //app.Quit();
        }
    }
}
