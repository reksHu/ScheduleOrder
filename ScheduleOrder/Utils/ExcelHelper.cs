using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using ScheduleOrder.Utils;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
namespace ScheduleOrder.Utils
{
   public class ExcelHelper
    {

       public static string GetExcelVersion() {
           try
           {
               Excel.Application excel = new Excel.Application();
               return "当前Office 版本为:"+excel.Version +@"(\Microsoft Visual Studio 10.0\Visual Studio Tools for Office\PIA\Office14\Microsoft.Office.Interop.Excel.dll)";
           }catch(Exception ex ){
               return "Error:" + ex.Message;
           }
       }
       public static void DataTableToExcel(string filePath, System.Data.DataTable dt)
       {
           

           Excel.Application excel = new Excel.Application();
           excel.Visible = false;
          
           Excel.Workbook workbook = excel.Application.Workbooks.Open(filePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value
, Missing.Value, Missing.Value, Missing.Value, Missing.Value
, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

           Excel.Worksheet sheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];

           ///---读取EXcel单元格的值
           ///---这里是获取固定位置上的值
           ///---这里获取的是  行索引为 1列 索引为1的单元格的值
           Excel.Range range = (Excel.Range)sheet.Cells[1, 1];
           sheet.Cells[1, 2] = "132456";
           string txt = range.Text;

           Excel.Range xlsRow = sheet.Rows[3, Missing.Value];
           xlsRow.Insert(Excel.XlDirection.xlDown, Missing.Value);
           sheet.Cells[3, 1] = "test";

           workbook.Save();
           workbook.Close();
           sheet = null;
           workbook = null;
           excel.Quit();
           excel = null;
           ///---回收系统资源
           GC.Collect();


       }

       public static void WriteExcel(string filename, DataGridView dgv)
       {
           Excel.Application excelApp = new Excel.Application();
           //判断指定路径中是否存在要创建的Excel
           Excel.Workbook workBook;

           Excel.Worksheet workSheet = null;
           try
           {
               if (excelApp == null)
               {
                   return;
               }

               
               if (File.Exists(filename))
               {
                   workBook =
                       excelApp.Application.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value
, Missing.Value, Missing.Value, Missing.Value, Missing.Value
, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                       //excelApp.Workbooks.Open(filename, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, Missing.Value, false, false, 0, true, 1, 0);
               }
               else
               {
                   workBook = excelApp.Workbooks.Add(true);
               }

               //workSheet = workBook.ActiveSheet as Excel.Worksheet;
               workSheet = (Excel.Worksheet)workBook.Sheets["Sheet1"];

               //excel中单元格下标为1开始
               for (int cindex = 0; cindex < dgv.Columns.Count; cindex++)
               {
                   workSheet.Cells[1, cindex+1] = dgv.Columns[cindex].Name.ToString();
               }
               int contentRow = 2; //从第二行开始写入数据
               for (int rindex = 0; rindex < dgv.Rows.Count; rindex++)
               {
                   for (int cindex = 0; cindex < dgv.Columns.Count; cindex++)
                   {
                       
                       workSheet.Cells[rindex+contentRow, cindex+1] = dgv.Rows[rindex].Cells[cindex].Value;
                   }
               }
              

               excelApp.Visible = false;
               excelApp.DisplayAlerts = false;

               workBook.SaveAs(filename);
               workBook.Close(false, Missing.Value, Missing.Value);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               if (excelApp != null)
               {
                   excelApp.Quit();
                   excelApp = null;
               }
               workSheet = null;
               workBook = null;
               GC.Collect();
           }
       }

       public static void DataTableToExcelForSchedule(string tempfilePath,string savedExcelFilePath, System.Data.DataTable dt, List<string> weekdays)
       {
           Excel.Application excel = new Excel.Application();
           excel.Visible = false;

           Excel.Workbook workbook = excel.Application.Workbooks.Open(tempfilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value
, Missing.Value, Missing.Value, Missing.Value, Missing.Value
, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

           Excel.Worksheet sheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];

           ///---读取EXcel单元格的值
           ///---这里是获取固定位置上的值
           ///---这里获取的是  行索引为1,列索引为1的单元格的值
           //Excel.Range range = (Excel.Range)sheet.Cells[1, 1];
           int dateColIndex = 5;
           for (int i = 0; i < weekdays.Count; i++) {  //读取第三行周时间单元

               Excel.Range mergedCells = sheet.Cells[3, dateColIndex];
               if (mergedCells.MergeCells)
               {
                   sheet.Cells[3, dateColIndex] = Convert.ToDateTime(weekdays[i]).ToString("yyyy-MM.dd");
               }
               dateColIndex += 2;
           }

           //设置护士层级
           XDocument nurseDoc = XMLHelper.GetNursersAllData(Miscellaneous.GetNurseXMLFullPath());
           


           //保存护士值班数据
           int baseDataRow = 7;
           for (int rowIndex = 0; rowIndex < dt.Rows.Count - 1; rowIndex++) {
               string nurseName = dt.Rows[rowIndex][0]==null?"":dt.Rows[rowIndex][0].ToString();
               var nurseLevelObj = nurseDoc.Descendants("Nurser").Where(e => e.Element("NurseName").Value.Equals(nurseName)).Select(e => e.Element("Level").Value);
               var lists = nurseDoc.Descendants("Nurser").Where(e => e.Element("NurseName").Value.Equals(nurseName)).ToList();
               string nurseLevel = nurseLevelObj == null ? "" : nurseLevelObj.FirstOrDefault();

               string monday_mor = dt.Rows[rowIndex][1] == null ? "" : dt.Rows[rowIndex][1].ToString();
               string monday_after = dt.Rows[rowIndex][2]==null?"":dt.Rows[rowIndex][2].ToString();
               string tuesday_mor = dt.Rows[rowIndex][3]==null?"":dt.Rows[rowIndex][3].ToString();
               string tuesday_after = dt.Rows[rowIndex][4]==null?"":dt.Rows[rowIndex][4].ToString();

               string wednesday_mor = dt.Rows[rowIndex][5]==null?"":dt.Rows[rowIndex][5].ToString();
               string wednesday_after = dt.Rows[rowIndex][6]==null?"":dt.Rows[rowIndex][6].ToString();

               string thursday_mor = dt.Rows[rowIndex][7] == null ? "" : dt.Rows[rowIndex][7].ToString();
               string thursday_after = dt.Rows[rowIndex][8] == null ? "" : dt.Rows[rowIndex][8].ToString();

               string friday_mor = dt.Rows[rowIndex][9] == null ? "" : dt.Rows[rowIndex][9].ToString();
               string friday_after = dt.Rows[rowIndex][10] == null ? "" : dt.Rows[rowIndex][10].ToString();

               string saturday_mor = dt.Rows[rowIndex][11] == null ? "" : dt.Rows[rowIndex][11].ToString();
               string saturday_after = dt.Rows[rowIndex][12] == null ? "" : dt.Rows[rowIndex][12].ToString();

               string sunday_mor = dt.Rows[rowIndex][13] == null ? "" : dt.Rows[rowIndex][13].ToString();
               string sunday_after = dt.Rows[rowIndex][14] == null ? "" : dt.Rows[rowIndex][14].ToString();

               Excel.Range xlsRow = sheet.Rows[baseDataRow, Missing.Value];
               xlsRow.Insert(Excel.XlDirection.xlDown, Missing.Value);
               sheet.Cells[baseDataRow, 2] = nurseLevel;
               sheet.Cells[baseDataRow, 3] = nurseName;
             
               //为每一个填入值班数据，表格为列 5 - 18
               sheet.Cells[baseDataRow,5] = monday_mor;
               sheet.Cells[baseDataRow, 6] = monday_after;
               sheet.Cells[baseDataRow, 7] = tuesday_mor;
               sheet.Cells[baseDataRow, 8] = tuesday_after;
               sheet.Cells[baseDataRow, 9] = wednesday_mor;
               sheet.Cells[baseDataRow, 10] = wednesday_after;
               sheet.Cells[baseDataRow, 11] = thursday_mor;
               sheet.Cells[baseDataRow, 12] = thursday_after;
               sheet.Cells[baseDataRow, 13] = friday_mor;
               sheet.Cells[baseDataRow, 14] = friday_after;
               sheet.Cells[baseDataRow, 15] = saturday_mor;
               sheet.Cells[baseDataRow, 16] = saturday_after;
               sheet.Cells[baseDataRow, 17] = sunday_mor;
               sheet.Cells[baseDataRow, 18] = sunday_after;
              
               baseDataRow ++;

           }
           //当有拍板信息时候就设置格式
           if (baseDataRow > 7)
           {
               string endrow = "S" + (baseDataRow - 1);
               Excel.Range range = sheet.get_Range("A7",endrow);
               range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; //设置文字居中
               range.Borders.LineStyle = 1;  //设置
           }
           string fileName =string.Format("护理排班表－护理部-{0}.xls",weekdays[0]);
           //string savedPath = Miscellaneous.GetExcelsFileFullPath(fileName);
           //string savedExcelPath = System.IO.Path.Combine(savedExcelLocation, fileName);
           workbook.SaveAs(savedExcelFilePath);
           workbook.Close();
           sheet = null;
           workbook = null;
           excel.Quit();
           excel = null;
           ///---回收系统资源
           GC.Collect();
       }

       

      
       /// <summary>
       /// upload schedule excel file and save the schedule data into the system
       /// </summary>
       /// <param name="excelPath"></param>
       public static void UploadAndSaveExcel(string excelPath, List<string> nursersName, List<string> jobsName)
       {
           try
           {
               Excel.Application excel = new Excel.Application();
               excel.Visible = false;

               Excel.Workbook workbook = excel.Application.Workbooks.Open(excelPath, Missing.Value, Missing.Value, Missing.Value, Missing.Value
    , Missing.Value, Missing.Value, Missing.Value, Missing.Value
    , Missing.Value, Missing.Value, Missing.Value, Missing.Value);

               Excel.Worksheet sheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];

               ///---这里获取的是  行索引为1,列索引为1的单元格的值
               //Excel.Range range = (Excel.Range)sheet.Cells[1, 1];
               //int dateColIndex = 5;
               //for (int i = 0; i < 7; i++)
               //{  //读取第三行周时间单元

               //    Excel.Range mergedCells = sheet.Cells[3, dateColIndex];
               //    if (mergedCells.MergeCells)
               //    {
               //        Excel.Range range = sheet.Cells[3, dateColIndex];
               //        string text = range.Text;
               //    }
               //    dateColIndex += 2;
               //}
               List<Schedules> scheduledList = new List<Schedules>();
               int baseDataRow = 7;
               for (int indexRow = baseDataRow; indexRow < baseDataRow + nursersName.Count(); indexRow++)
               {
                   Excel.Range rangeNurseName = (Excel.Range)sheet.Cells[baseDataRow, 3];
                   string nurseName = rangeNurseName.Text;
                   //判断护士名称是否存在
                   if (nursersName.Select(e => e.Equals(nurseName.Trim())).Any())
                   {
                       Schedules schedule = new Schedules();
                       schedule.ScheduledNurser = new Nurser() { NurserName = nurseName.Trim() };

                       int baseScheduleDataColumns = 5;
                       //从第五列开始，直到一周结束,一周为14个小单元
                       for (int indexCol = baseScheduleDataColumns; indexCol < baseScheduleDataColumns + 14; indexCol++) {
                           Excel.Range rangeScheduleData = (Excel.Range)sheet.Cells[indexRow, indexCol];
                           string scheduleJobData = rangeScheduleData.Text;

                           if (jobsName.Select(e => e.Equals(scheduleJobData.Trim())).Any())
                           {
                               ScheduleJob job = new ScheduleJob();
                               job.Tasks = new List<TaskDetail>();
                               if (indexCol / 2 == 0) // 下午
                               {
                                   TaskDetail task_afternoon = new TaskDetail()
                                   {
                                       JobDayType = ScheduledType.Afternoon.ToString(),
                                       JobName = scheduleJobData
                                   };

                               }
                               else {
                                   TaskDetail task_morning = new TaskDetail()
                                   {
                                       JobDayType = ScheduledType.Morning.ToString(),
                                       JobName = scheduleJobData
                                   };
                               }
                               

                           }
                           else {
                               Exception ex = new Exception("文件中排班名称与系统中名称名称不一致");
                               throw ex;
                           }
                       }
                       

                   }
                   else
                   {
                       Exception ex = new Exception("文件中护士名称与系统中护士名称或数量不一致");
                       throw ex;
                   }

               }
           }catch(Exception ex){
               throw ex;
           }
           



           

       }

       public static void DSToExcel(string Path, DataSet oldds)
       {
           //先得到汇总EXCEL的DataSet 主要目的是获得EXCEL在DataSet中的结构 
           string strCon = " Provider = Microsoft.Jet.OLEDB.4.0;Data Source =" + Path + ";Extended Properties=Excel 8.0";
           OleDbConnection myConn = new OleDbConnection(strCon);
           string strCom = "select * from [Sheet1$]";
           myConn.Open();
           OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
           OleDbCommandBuilder builder = new OleDbCommandBuilder(myCommand);
           //QuotePrefix和QuoteSuffix主要是对builder生成InsertComment命令时使用。 
           builder.QuotePrefix = "[";     //获取insert语句中保留字符（起始位置） 
           builder.QuoteSuffix = "]"; //获取insert语句中保留字符（结束位置） 
           DataSet newds = new DataSet();
           myCommand.Fill(newds, "Table1");

           for (int i = 0; i < oldds.Tables[0].Rows.Count; i++)
           {
               //在这里不能使用ImportRow方法将一行导入到news中，因为ImportRow将保留原来DataRow的所有设置(DataRowState状态不变)。
               //在使用ImportRow后newds内有值，但不能更新到Excel中因为所有导入行的DataRowState!=Added 
               DataRow nrow = newds.Tables["Table1"].NewRow();
               for (int j = 0; j < newds.Tables[0].Columns.Count; j++)
               {
                   nrow[j] = oldds.Tables[0].Rows[i][j];
               }
               newds.Tables["Table1"].Rows.Add(nrow);
           }
           myCommand.Update(newds, "Table1");
           myConn.Close();
       } 

       //读取EXCEL的方法   (用范围区域读取数据)
       private void OpenExcel(string strFileName)
       {
           object missing = System.Reflection.Missing.Value;
           Excel.Application excel = new Excel.Application();//lauch excel application
           if (excel == null)
           {
               
           }
           else
           {
               excel.Visible = false; excel.UserControl = true;
               // 以只读的形式打开EXCEL文件
               Excel.Workbook wb = excel.Application.Workbooks.Open(strFileName, missing, true, missing, missing, missing,
                missing, missing, missing, true, missing, missing, missing, missing, missing);
               //取得第一个工作薄
               Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.get_Item(1);


               //取得总记录行数   (包括标题列)
               int rowsint = ws.UsedRange.Cells.Rows.Count; //得到行数
               //int columnsint = mySheet.UsedRange.Cells.Columns.Count;//得到列数


               //取得数据范围区域 (不包括标题列) 
               Excel.Range rng1 = ws.Cells.get_Range("B2", "B" + rowsint);   //item


               Excel.Range rng2 = ws.Cells.get_Range("K2", "K" + rowsint); //Customer
               object[,] arryItem = (object[,])rng1.Value2;   //get range's value
               object[,] arryCus = (object[,])rng2.Value2;
               //将新值赋给一个数组
               string[,] arry = new string[rowsint - 1, 2];
               for (int i = 1; i <= rowsint - 1; i++)
               {
                   //Item_Code列
                   arry[i - 1, 0] = arryItem[i, 1].ToString();
                   //Customer_Name列
                   arry[i - 1, 1] = arryCus[i, 1].ToString();
               }
           }
           excel.Quit(); excel = null;
           Process[] procs = Process.GetProcessesByName("excel");


           foreach (Process pro in procs)
           {
               pro.Kill();//没有更好的方法,只有杀掉进程
           }
           GC.Collect();
       }

    }
}
