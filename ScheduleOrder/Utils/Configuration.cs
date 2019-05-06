using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleOrder.Utils
{
    public class Configuration
    {
        #region parameter
        private static Configuration config;
        public string GetKey {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["key"] == null ? null : System.Configuration.ConfigurationManager.AppSettings["key"].ToString();
            }
        }
        public string XMLFile {
            get { return System.Configuration.ConfigurationManager.AppSettings["xmlFile"] == null ? string.Empty : System.Configuration.ConfigurationManager.AppSettings["xmlFile"].ToString(); }
        }
        public string RootNode {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["parentNode"] == null ? null : System.Configuration.ConfigurationManager.AppSettings["parentNode"].ToString();
            }
        }
        public string NewNode {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["newNode"] == null ? string.Empty : System.Configuration.ConfigurationManager.AppSettings["newNode"].ToString();
            }
        }
        public string PerInfoFileName {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["perInfo"]==null?string.Empty:System.Configuration.ConfigurationManager.AppSettings["perInfo"].ToString();
            }
        }
        public string PerInfoFileRootNode {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["perRootNode"] == null ? string.Empty : System.Configuration.ConfigurationManager.AppSettings["perRootNode"].ToString();
            }
        }
        public string GetUrlInfoFileName {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["urlInfoFile"] == null ? string.Empty : System.Configuration.ConfigurationManager.AppSettings["urlInfoFile"].ToString();
            }
        }
        #endregion
        #region method
        public static  Configuration GetConfig() {
            if (config == null)
            {
                config = new Configuration();
            }
            return config;
        }
        private Configuration() { }
        #endregion

    }
}