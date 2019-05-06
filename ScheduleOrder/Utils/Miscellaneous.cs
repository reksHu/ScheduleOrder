using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;
using System.Data;

namespace ScheduleOrder.Utils
{
    public class Miscellaneous
    {
        /// <summary>
        /// DES解密。
        /// </summary>
        /// <param name="pToDecrypt">要解密的字符串</param>
        /// <param name="sKey">8位密钥</param>
        /// <returns>已解密的字符串。</returns>
        public static string DESDecrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //把字符串放入byte数组 
            int len = 0;
            len = pToDecrypt.Length / 2 - 1;
            byte[] inputByteArray = new byte[len + 1];
            int x = 0;
            int i = 0;
            for (x = 0; x <= len; x++)
            {
                i = Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16);
                inputByteArray[x] = Convert.ToByte(i);
            }
            //建立加密对象的密钥和偏移量，此值重要，不能修改 
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        /// <summary>
        /// DES加密函数
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串</param>
        /// <param name="sKey">8位密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = null;
            inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            //建立加密对象的密钥和偏移量 
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法 
            //使得输入密码必须输入英文文本 
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            //写二进制数组到加密流 
            //(把内存流中的内容全部写入) 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //写二进制数组到加密流 
            //(把内存流中的内容全部写入) 
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //建立输出字符串      
            StringBuilder ret = new StringBuilder();
            byte b = 0;
            foreach (byte b_loopVariable in ms.ToArray())
            {
                b = b_loopVariable;
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }


        public static string GetJobXMLFullPath()
        {
            string APPPATH = System.Windows.Forms.Application.StartupPath;
            string fileLocation = System.IO.Path.Combine(APPPATH, "data");
            string xmlFileName = "Jobs.xml";
            string xmlfileFullPath = System.IO.Path.Combine(fileLocation, xmlFileName);
            return xmlfileFullPath;
        }

        public static string GetNurseXMLFullPath()
        {
            string path = System.Windows.Forms.Application.StartupPath;
            string fileLocation = System.IO.Path.Combine(path, "data");
            string xmlfileFullPath = System.IO.Path.Combine(fileLocation, "Nursers.xml");
            return xmlfileFullPath;
        }

        public static string GetSchedulerXMLFullPath(string weekFirstDay)
        {
            string path = System.Windows.Forms.Application.StartupPath;
            string fileLocation = System.IO.Path.Combine(path, "data");
            string fileName = string.Format("Schedules-{0}.xml", weekFirstDay);
            string xmlfileFullPath = System.IO.Path.Combine(fileLocation, fileName);
            return xmlfileFullPath;
        }

        public static string GetWeekFirstDayStr(DateTime weekFirstDay) {
            return weekFirstDay.ToString("yyyyMMdd");
        }
        /// <summary>
        /// 获取排班模板excel地址,并生成全域文件路径
        /// </summary>
        /// <returns></returns>
        public static string GetScheduleTempExcelFile() {
            string path = "";
            string fileLocation = "";
            object pathObj = ConfigurationManager.AppSettings["ScheduleExcelTempFilePath"];
            if (pathObj == null || pathObj.ToString().Trim()=="")
            {
                path = System.Windows.Forms.Application.StartupPath;
                fileLocation = System.IO.Path.Combine(path, "data");
            }
            else {
                fileLocation = pathObj.ToString();
            }

            string scheduleInfoTempFileName = ConfigurationManager.AppSettings["ScheduleExcelTempFileName"] == null ?
                "NurseSchedule.xlsm" : ConfigurationManager.AppSettings["ScheduleExcelTempFileName"].ToString();

            string tempFile = System.IO.Path.Combine(fileLocation, scheduleInfoTempFileName);
            if (DataInit.IsFileExited(tempFile)) {
                return tempFile;
            }
            
            return string.Empty;
        }

        /// <summary>
        /// 生成排班信息excel 文件,生成用户需要导出的excel文件全路径和名称
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetExcelsFileFullPath(string fileName) {
            string path = "";
            string fileLocation = "";
            object pathObj = ConfigurationManager.AppSettings["ScheduleExcelFolder"];
            if (pathObj == null || pathObj.ToString().Trim() == "")
            {
                path = System.Windows.Forms.Application.StartupPath;
                fileLocation = System.IO.Path.Combine(path, "data");
            }
            else
            {
                fileLocation = pathObj.ToString();
            }
           
            return System.IO.Path.Combine(fileLocation, fileName);
        }
        

        public static List<string> GenerateWeekDaysList(DateTime startWeek) {
            List<string> weekDays = new List<string>();
            string dayOfWeek = startWeek.DayOfWeek.ToString();
            for (int i = 0; i < 7; i++)
            {
                DateTime offSet = startWeek.AddDays(i);
                weekDays.Add(offSet.ToString("yyyy-MM-dd"));
            }
            return weekDays;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="folderName"></param>
        public static void CleanFiles(string folderName,string exceptFiles) {
            string[] files = Directory.GetFiles(folderName);


        }

        public static bool IsDatatablesValueSame(DataTable dt1,DataTable dt2) {
            bool flag = dt1 == dt2;
            return true;
        }
       

     
    }
}