using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using System.IO;
using System.Data;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Xml.Linq;

namespace ScheduleOrder.Utils
{
    class NPOIHelper : IDisposable
    {
        private string fileName = null; //文件名
        private IWorkbook workbook = null;
        private FileStream fs = null;
        private bool disposed;

        public NPOIHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }


        public static void DataTableToExcelForSchedule_NPOI(string scheduleTemp_filePath, System.Data.DataTable dt, List<string> weekdays)
        {
            string scheduled_fileName = string.Format("护理排班表－护理部-{0}.xlsx", weekdays[0]);
            string scheduled_fileFullPath = Miscellaneous.GetExcelsFileFullPath(scheduled_fileName);

            using (FileStream temp_fs = File.Open(scheduleTemp_filePath,FileMode.Open,FileAccess.Read))
            {
                IWorkbook temp_workbook = new XSSFWorkbook(temp_fs);

                ISheet sheet = temp_workbook.GetSheetAt(0);

                ///---读取EXcel单元格的值
                ///---这里是获取固定位置上的值
                ///---这里获取的是  行索引为0,列索引为0的单元格的值
                int dateColIndex = 4;
                for (int i = 0; i < weekdays.Count; i++) {
                    IRow row = sheet.GetRow(2);
                    ICell cell =  row.GetCell(dateColIndex);
                    
                    if (cell.IsMergedCell) {
                        cell.SetCellValue(Convert.ToDateTime(weekdays[i]).ToString("yyyy-MM.dd"));
                    }
                    dateColIndex += 2;
                }

                //if(File.Exists(scheduled_fileFullPath)){
                //    File.Delete(scheduled_fileFullPath);
                //}
                XDocument nurseDoc = XMLHelper.GetNursersAllData(Miscellaneous.GetNurseXMLFullPath());

                //保存护士值班数据, NPOI中定义Excel 单元格从0开始，而不是1
                int baseDataRow = 6; //从单元格第7行开始
                for (int rowIndex = 0; rowIndex < dt.Rows.Count - 1; rowIndex++)
                {
                    string nurseName = dt.Rows[rowIndex][0] == null ? "" : dt.Rows[rowIndex][0].ToString();
                    var nurseLevelObj = nurseDoc.Descendants("Nurser").Where(e => e.Element("NurseName").Value.Equals(nurseName)).Select(e => e.Element("Level").Value);
                    var lists = nurseDoc.Descendants("Nurser").Where(e => e.Element("NurseName").Value.Equals(nurseName)).ToList();
                    string nurseLevel = nurseLevelObj == null ? "" : nurseLevelObj.FirstOrDefault();

                    string monday_mor = dt.Rows[rowIndex][1] == null ? "" : dt.Rows[rowIndex][1].ToString();
                    string monday_after = dt.Rows[rowIndex][2] == null ? "" : dt.Rows[rowIndex][2].ToString();
                    string tuesday_mor = dt.Rows[rowIndex][3] == null ? "" : dt.Rows[rowIndex][3].ToString();
                    string tuesday_after = dt.Rows[rowIndex][4] == null ? "" : dt.Rows[rowIndex][4].ToString();

                    string wednesday_mor = dt.Rows[rowIndex][5] == null ? "" : dt.Rows[rowIndex][5].ToString();
                    string wednesday_after = dt.Rows[rowIndex][6] == null ? "" : dt.Rows[rowIndex][6].ToString();

                    string thursday_mor = dt.Rows[rowIndex][7] == null ? "" : dt.Rows[rowIndex][7].ToString();
                    string thursday_after = dt.Rows[rowIndex][8] == null ? "" : dt.Rows[rowIndex][8].ToString();

                    string friday_mor = dt.Rows[rowIndex][9] == null ? "" : dt.Rows[rowIndex][9].ToString();
                    string friday_after = dt.Rows[rowIndex][10] == null ? "" : dt.Rows[rowIndex][10].ToString();

                    string saturday_mor = dt.Rows[rowIndex][11] == null ? "" : dt.Rows[rowIndex][11].ToString();
                    string saturday_after = dt.Rows[rowIndex][12] == null ? "" : dt.Rows[rowIndex][12].ToString();

                    string sunday_mor = dt.Rows[rowIndex][13] == null ? "" : dt.Rows[rowIndex][13].ToString();
                    string sunday_after = dt.Rows[rowIndex][14] == null ? "" : dt.Rows[rowIndex][14].ToString();

                    IRow xlsRow = sheet.CreateRow(baseDataRow);
                    xlsRow.CreateCell(1).SetCellValue(nurseLevel);
                    xlsRow.CreateCell(2).SetCellValue(nurseName);
                   
                    //为每一个填入值班数据，表格为列 5 - 18
                    xlsRow.CreateCell(4).SetCellValue(monday_mor);
                   
                    xlsRow.CreateCell(5).SetCellValue(monday_after);
                    xlsRow.CreateCell(6).SetCellValue(tuesday_mor);
                    xlsRow.CreateCell(7).SetCellValue(tuesday_after);
                    xlsRow.CreateCell(8).SetCellValue(wednesday_mor);
                    xlsRow.CreateCell(9).SetCellValue(wednesday_after);
                    xlsRow.CreateCell(10).SetCellValue(thursday_mor);
                    xlsRow.CreateCell(11).SetCellValue(thursday_after);
                    xlsRow.CreateCell(12).SetCellValue(friday_mor);
                    xlsRow.CreateCell(13).SetCellValue(friday_after);
                    xlsRow.CreateCell(14).SetCellValue(saturday_mor);
                    xlsRow.CreateCell(15).SetCellValue(saturday_after);
                    xlsRow.CreateCell(16).SetCellValue(sunday_mor);
                    xlsRow.CreateCell(17).SetCellValue(sunday_after);

                    ICellStyle style = temp_workbook.CreateCellStyle();
                    style.Alignment = HorizontalAlignment.Center;
                    IFont font = temp_workbook.CreateFont();
                    font.Boldweight = (short)FontBoldWeight.Bold;
                    style.SetFont(font);

                    style.BorderBottom = BorderStyle.Thin;


                    //设置居中显示
                    for (int style_index = 1; style_index < 18;style_index++ ) {
                        if (xlsRow.GetCell(style_index) != null) //排除cell index =3
                        {
                            xlsRow.GetCell(style_index).CellStyle = style;
                        }
                    }

                    baseDataRow++;

                }

                if(File.Exists(scheduled_fileFullPath)){
                    File.Delete(scheduled_fileFullPath);
                }
                using (FileStream fs = File.Open(scheduled_fileFullPath,FileMode.Create,FileAccess.Write)) {
                    temp_workbook.Write(fs);
                }

            }

           
        }


       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }

                fs = null;
                disposed = true;
            }
        }
    }
}
