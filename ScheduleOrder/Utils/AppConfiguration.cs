using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ScheduleOrder.Utils
{
    public class AppConfiguration
    {
        /// <summary>
        /// get Job configuration file root node name , e.g. Jobs
        /// </summary>
        /// <returns></returns>
        public static string GetJobXMLRootNode() {
            return ConfigurationManager.AppSettings["JobsRootNode"].ToString();
        }

        /// <summary>
        /// get nurser xml file root node, eg. Nursers
        /// </summary>
        /// <returns></returns>
        public static string GetNurserXMLRootNode() {
            return ConfigurationManager.AppSettings["NurserRootNode"].ToString();
        }

        /// <summary>
        /// get configuraiton files folder, eg. data
        /// </summary>
        /// <returns></returns>
        public static string ConfigurationFolderName() {
            return ConfigurationManager.AppSettings["ConfigurationFolderName"].ToString();
        }

        /// <summary>
        /// ShiftNum = 1 获取上半夜值班名称
        /// shiftNum = 2 获取下半夜值班名称
        /// </summary>
        /// <param name="shiftNum"></param>
        /// <returns></returns>
        public static dynamic GetNightShiftName(string shiftNum)
        {
            string shiftName = string.Format("NightShift{0}Name", shiftNum);
            string shiftIndexName = string.Format("NightShift{0}Index",shiftNum);
            var obj = new {NightShiftName = ConfigurationManager.AppSettings[shiftName].ToString(),
                NightShiftIndex = ConfigurationManager.AppSettings[shiftIndexName].ToString()
            };
            return obj;

        }
    }
}
