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
    }
}
