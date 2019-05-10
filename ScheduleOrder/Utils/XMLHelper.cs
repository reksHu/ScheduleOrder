using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using System.IO;
using ScheduleOrder.Utils;
using System.Text.RegularExpressions;
using System.Data;
namespace ScheduleOrder.Utils
{
    public sealed class XMLHelper
    {

        public static void CreateXmlFile(string xmlFileFullPath,string folderPath,string rootElementName) {
            if (checkFolderExisted(folderPath))
            {
                //string fullPathFileName =System.IO.Path.Combine(folderPath, xmlFileName);
                if (checkFileExisted(xmlFileFullPath))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    //xmlDoc.Load(fullPathFileName);
                    XmlDeclaration decl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                    xmlDoc.AppendChild(decl);
                    XmlElement rootEle = xmlDoc.CreateElement(rootElementName);
                    xmlDoc.AppendChild(rootEle);

                    xmlDoc.Save(xmlFileFullPath);
                }
            }
           
        }
        public static void DeleteXMLFile(string xmlFileFullPath) {
           bool isExisted =  File.Exists(xmlFileFullPath);
           try
           {
               if (isExisted)
               {
                   File.Delete(xmlFileFullPath);
               }
           }
           catch (Exception ex) {
               throw ex;
           }
        
        }
       

        public static void CreateNurseNode(string xmlFilefullPath, string rootElement, Nurser element) {
            try {
                //XMLHelper.checkFileExisted(xmlFileName);
                checkFileExisted(xmlFilefullPath);
                XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(HttpContext.Current.Server.MapPath(xmlFileName));
                xmlDoc.Load(xmlFilefullPath);
                XmlNode rootNode = xmlDoc.SelectSingleNode(rootElement);

                //string newElementName = element.GetType().Name;
                //XmlElement newTag = xmlDoc.CreateElement(newElementName);
                string newElementName = "Nurser";
                XmlElement newTag = xmlDoc.CreateElement(newElementName);
                newTag.SetAttribute("id", Guid.NewGuid().ToString());

                XmlElement nameEle = xmlDoc.CreateElement("NurseName");
                nameEle.InnerText= element.NurserName;
                newTag.AppendChild(nameEle);

                XmlElement assignedBedEle = xmlDoc.CreateElement("Level");
                assignedBedEle.InnerText = element.NurserLevel;
                newTag.AppendChild(assignedBedEle);

                XmlElement indexEle = xmlDoc.CreateElement("LevelIndex");
                indexEle.InnerText = element.NurserLevelRating;
                newTag.AppendChild(indexEle);


                rootNode.AppendChild(newTag);
                xmlDoc.Save(xmlFilefullPath);

            }catch(Exception ex){

            }

        }

        public static void CreateNurseNodes(string xmlFilefullPath, string rootElement, List<Nurser> nurserList) {
            checkFileExisted(xmlFilefullPath);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilefullPath);
            XmlNode rootNode = xmlDoc.SelectSingleNode(AppConfiguration.GetNurserXMLRootNode());
            foreach (Nurser element in nurserList)
            {
                string newElementName = "Nurser";
                XmlElement newTag = xmlDoc.CreateElement(newElementName);
                if (!string.IsNullOrEmpty(element.Id))
                {
                    newTag.SetAttribute("id", element.Id);
                }
                else
                {
                    newTag.SetAttribute("id", Guid.NewGuid().ToString());
                }

                XmlElement nameEle = xmlDoc.CreateElement("NurseName");
                nameEle.InnerText = element.NurserName;
                newTag.AppendChild(nameEle);

                XmlElement assignedBedEle = xmlDoc.CreateElement("Level");
                assignedBedEle.InnerText = element.NurserLevel;
                newTag.AppendChild(assignedBedEle);

                XmlElement indexEle = xmlDoc.CreateElement("LevelIndex");
                indexEle.InnerText = element.NurserLevelRating;
                newTag.AppendChild(indexEle);

                rootNode.AppendChild(newTag);
                
            }
            xmlDoc.Save(xmlFilefullPath);
        }

        public static void CreateJobNode(string xmlFilefullPath, string rootElement, Job element) {
            checkFileExisted(xmlFilefullPath);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilefullPath);
            XmlNode rootNode = xmlDoc.SelectSingleNode(rootElement);

            string newElementName = "Job";
            XmlElement newTag = xmlDoc.CreateElement(newElementName);
            newTag.SetAttribute("id", Guid.NewGuid().ToString());

            XmlElement nameEle = xmlDoc.CreateElement("JobName");
            nameEle.InnerText = element.JobName;
            newTag.AppendChild(nameEle);

            XmlElement jobIndexEle = xmlDoc.CreateElement("JobIndex");
            jobIndexEle.InnerText = element.JobIndex.ToString();
            newTag.AppendChild(jobIndexEle);


            rootNode.AppendChild(newTag);
            xmlDoc.Save(xmlFilefullPath);
        }

        public static void CreateJobNodes(string xmlFilefullPath,  List<Job> jobsList) {
            checkFileExisted(xmlFilefullPath);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilefullPath);
            XmlNode rootNode = xmlDoc.SelectSingleNode(AppConfiguration.GetJobXMLRootNode());
            foreach (Job element in jobsList)
            {
                string newElementName = "Job";
                XmlElement newTag = xmlDoc.CreateElement(newElementName);
                if (!string.IsNullOrEmpty(element.Id))
                {
                    newTag.SetAttribute("id", element.Id);
                }
                else {
                    newTag.SetAttribute("id", Guid.NewGuid().ToString());
                }

                XmlElement nameEle = xmlDoc.CreateElement("JobName");
                nameEle.InnerText = element.JobName;
                newTag.AppendChild(nameEle);

                XmlElement jobIndexEle = xmlDoc.CreateElement("JobIndex");
                jobIndexEle.InnerText = element.JobIndex.ToString();
                newTag.AppendChild(jobIndexEle);

                rootNode.AppendChild(newTag);
            }
            xmlDoc.Save(xmlFilefullPath);
        }

        public static void CreateSchedulesNodes(string xmlFileFullPath, string rootElement, List<Schedules> schedulesList)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFileFullPath);
            XmlNode rootNode = xmlDoc.SelectSingleNode(rootElement);

            foreach (var item in schedulesList)
            {
                XmlElement newTag = xmlDoc.CreateElement("Schedule");
                newTag.SetAttribute("id", Guid.NewGuid().ToString());

                XmlElement nameEle = xmlDoc.CreateElement("NurserName");
                nameEle.InnerText = item.ScheduledNurser.NurserName;
                newTag.AppendChild(nameEle);

                XmlElement ratingEle = xmlDoc.CreateElement("NurserRating");
                ratingEle.InnerText = item.ScheduledNurser.NurserLevelRating;
                newTag.AppendChild(ratingEle);

                XmlElement nurseLevel = xmlDoc.CreateElement("NurserLevel");
                nurseLevel.InnerText = item.ScheduledNurser.NurserLevel;
                newTag.AppendChild(nurseLevel);

                XmlElement weekFirstDayEle = xmlDoc.CreateElement("WeekFirstDay");
                weekFirstDayEle.InnerText = item.WeekFirstDay;
                newTag.AppendChild(weekFirstDayEle);

                foreach (var job in item.JobsList)
                {
                    XmlElement jobEle = xmlDoc.CreateElement("Job");
                    jobEle.SetAttribute("WeekDay", job.ScheduledWeekday);
                    List<TaskDetail> tasks = job.Tasks;
                    foreach (var task in tasks)
                    {
                        XmlElement jobOfDayEle = xmlDoc.CreateElement(task.JobDayType);
                        jobOfDayEle.SetAttribute("JobRating", task.JobRating);
                        jobOfDayEle.InnerText = task.JobName;
                        jobEle.AppendChild(jobOfDayEle);
                    }
                    newTag.AppendChild(jobEle);
                   
                }

                rootNode.AppendChild(newTag);

            }

            xmlDoc.Save(xmlFileFullPath);

        }


        /// <summary>
        /// check folder is existed or not, if non-existed create.
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public static bool checkFolderExisted(string folderPath){
            bool folderExisted = Directory.Exists(folderPath);
            try
            {
                if (!folderExisted)
                {
                    Directory.CreateDirectory(folderPath);
                    folderExisted=true;
                }
            }
            catch (Exception ex) {
                folderExisted = false;
            }
            return folderExisted;

        }

        /// <summary>
        /// 检查指定文件是否存在，如果不存在则创建
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool checkFileExisted(string filePath) {
            bool fileExisted = File.Exists(filePath);
            if (!fileExisted) //if not existed create.
            {
                try
                {
                    using (FileStream fs = File.Create(filePath))
                    {
                        fileExisted = true;
                    }
                }catch(Exception ex){
                    fileExisted = false;
                }
            }
            return fileExisted;

        }

        public static List<String> GetNursersName(string filePath) {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlElement rootEle = doc.DocumentElement;
            XmlNodeList eleLists = rootEle.GetElementsByTagName("Nurser");
            
            List<String> nursers = new List<String>();
            foreach (XmlNode node in eleLists)
            {
                XmlNodeList nurseNameNode = ((XmlElement)node).GetElementsByTagName("NurseName");
                String nurseName = nurseNameNode[0].InnerText;
                nursers.Add(nurseName);
            }

            return nursers;

        }

        public static XDocument GetNursersAllData(string filePath)
        {
            XDocument nurserDoc = XDocument.Load(filePath);
            //List<Nurser> nursers = new List<Nurser>();
            //foreach (var item in nurserDoc.Root.Descendants("Nurser"))
            //{
            //    nursers.Add(new Nurser() { NurserLevel = item.Element("Level").Value });
            //}
            //nurserDoc = null;
            return nurserDoc;

        }

        public static List<string> GetJobsName(string filePath) {
            XDocument doc = XDocument.Load(filePath);
            List<string> jobsName = doc.Descendants("Job").Select(e => e.Element("JobName").Value).ToList();
            return jobsName;
        }

        public static Nurser GetNurserFromName(string filePath, string nurserName) {
            //XmlDataDocument doc = new XmlDataDocument();
            XDocument doc = XDocument.Load(filePath);
            var ele = doc.Descendants("Nurser")
                .Where(p => p.Element("NurseName").Value.ToString().Equals(nurserName))
                .Select(p => new Nurser() { 
                    Id = p.Attribute("id").Value, 
                    NurserName = nurserName, 
                    NurserLevel = p.Element("Level").Value,
                    NurserLevelRating = p.Element("LevelIndex").Value 
                });
            if (ele != null) {
                return ele.First();
            }
            return null;
        }

        public static List<Schedules> GetSchedules(string filePath) {
            XDocument doc = XDocument.Load(filePath);
            
            List<Schedules> scheduledList = new List<Schedules>();
            foreach (var item in doc.Root.Descendants("Schedule"))
            {
                Schedules schedule = new Schedules();
                schedule.Id = item.Attribute("id").Value;
                schedule.ScheduledNurser = new Nurser() { NurserName = item.Element("NurserName").Value, NurserLevelRating = item.Element("NurserRating").Value };
                schedule.JobsList = new List<ScheduleJob>();
                schedule.WeekFirstDay = item.Element("WeekFirstDay").Value;

                var jobsDescendants = item.Descendants("Job");
                foreach (var jobEle in jobsDescendants)
                {
                    ScheduleJob job = new ScheduleJob();
                    job.ScheduledWeekday = jobEle.Attribute("WeekDay").Value;
                    job.Tasks = new List<TaskDetail>();
                    TaskDetail task_morning = new TaskDetail() { 
                         JobDayType = ScheduledType.Morning.ToString(),
                         JobRating = jobEle.Element(ScheduledType.Morning.ToString()).Attribute("JobRating").Value,
                         JobName = jobEle.Element(ScheduledType.Morning.ToString()).Value
                    };
                    TaskDetail task_afternoon = new TaskDetail() { 
                        JobDayType = ScheduledType.Afternoon.ToString(),
                        JobRating = jobEle.Element(ScheduledType.Afternoon.ToString()).Attribute("JobRating").Value,
                        JobName = jobEle.Element(ScheduledType.Afternoon.ToString()).Value
                    };

                    job.Tasks.Add(task_morning);
                    job.Tasks.Add(task_afternoon);

                    schedule.JobsList.Add(job);
                    
                }
                scheduledList.Add(schedule);

            }

            return scheduledList;
        }

        public static Dictionary<string, JobsCount> GetSchedulesForReporting(List<string> filePaths)
        {
            Dictionary<string, JobsCount> dict = new Dictionary<string, JobsCount>();
            foreach (var filePath in filePaths)
            {
                XDocument doc = XDocument.Load(filePath);
                //var results = doc.Descendants("Schedule").GroupBy(p => p.Element("NurserName").Value).Select(e => new { NurserName = e.Elements("NurserName"), Jobs = e.Elements("Job")});
                var results = doc.Descendants("Schedule").Select(e => new { NurserName = e.Element("NurserName").Value, Jobs = e.Elements("Job") });
                //var results = doc.Descendants("Schedule").GroupBy(p => p.Element("Job").Value).Select(e => e.Elements("Job"));
                foreach (var item in results)
                {
                    var name = dict.Keys.Where(p => p.Equals(item.NurserName));
                    JobsCount jobsCount;
                    if (name.Count() > 0)
                    {
                        jobsCount = dict.Where(e => e.Key.Equals(item.NurserName)).Select(e => e.Value).First();
                    }
                    else
                    {

                        jobsCount = new JobsCount();
                    }
                    //var result = item.Where(p => !string.IsNullOrEmpty(p.Element("Morning").Value) && !string.IsNullOrEmpty(p.Element("Afternoon").Value))
                    //    .Select(p => new { Morning = p.Element("Morning").Value, Afternoon = p.Element("Afternoon").Value });
                    var result = item.Jobs.Where(p => !string.IsNullOrEmpty(p.Element("Morning").Value) || !string.IsNullOrEmpty(p.Element("Afternoon").Value))
                        //.Select(p => p.Elements("Morning"));
                        .Select(p => new { Morning = p.Element("Morning").Value, Afternoon = p.Element("Afternoon").Value });

                    foreach (var r in result)
                    {
                        jobsCount.Count(r.Morning);
                        jobsCount.Count(r.Afternoon);
                    }
                    if (name.Count() == 0)
                    {
                        dict.Add(item.NurserName, jobsCount);
                    }

                }
            }
            return dict;

        }


        public static List<string> GetSchedulerReportingFiles(string monthStr,string folerPath) {
            string pattern = @"Schedules-\d{4}(\d{2})\d{2}";
            string[] files =  Directory.GetFiles(folerPath);
            List<string> results = files.Where(f => Regex.Match(f, pattern).Groups[1].Value.Equals(monthStr)).ToList();
            return results;
        }

        public static bool hasSchedulesFilesExisted(string folerPath)
        {
            //string pattern = @"Schedules-\d{4}\d{2}\d{2}";
            string[] files = Directory.GetFiles(folerPath);
            return files.Any(f=>f.Contains("Schedules"));
        } 

        public static void UpdateJobNode(string appPath,string nodeRootName, Job job)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(appPath);
                bool isUpdated = false;
                XmlNode nodes = doc.SelectSingleNode(nodeRootName);
                foreach (XmlNode node in nodes) {
                    XmlElement ele = (XmlElement)node;
                    string eleId = ele.GetAttribute("id");
                    if(eleId.Equals(job.Id)){
                        XmlNodeList nls = node.ChildNodes;
                        nls[0].InnerText = job.JobName;
                        nls[1].InnerText = job.JobIndex;
                        isUpdated = true;
                        break;
                    }

                }
                if (isUpdated)
                {
                    doc.Save(appPath);
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public static void UpdateJobNodes(string jobxmlFullPath, List<Job> jobs)
        {
            try
            {

                //XDocument doc = XDocument.Load(jobxmlFullPath);

                DeleteXMLFile(jobxmlFullPath);
                CreateXmlFile(jobxmlFullPath, AppConfiguration.ConfigurationFolderName(), AppConfiguration.GetJobXMLRootNode());
                CreateJobNodes(jobxmlFullPath, jobs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                jobs = null;
            }
        }

        public static void UpdateNurserNode(string appPath, Nurser nurser) {
            string rootNode = AppConfiguration.GetNurserXMLRootNode();
            XmlDocument doc = new XmlDocument();
            doc.Load(appPath);
            bool isUpdated = false;
            XmlNode nodes = doc.SelectSingleNode(rootNode);
            foreach (XmlNode item in nodes)
            {
                XmlElement ele = (XmlElement)item;
                string eleId = ele.GetAttribute("id");
                if (eleId.Equals(nurser.Id)) {
                    XmlNodeList nls = item.ChildNodes;
                    nls[0].InnerText = nurser.NurserName;
                    nls[1].InnerText = nurser.NurserLevel;
                    nls[2].InnerText = nurser.NurserLevelRating;
                    isUpdated = true;
                    break;
                }
            }
            if (isUpdated) {
                doc.Save(appPath);
            }
        }

        public static List<Job> GetJobs(string appPath) {
            XmlDocument doc = new XmlDocument();
            doc.Load(appPath);
            XmlElement rootEle = doc.DocumentElement;
            XmlNodeList eleLists = rootEle.GetElementsByTagName("Job");
            List<Job> jobs = new List<Job>();
            foreach (XmlNode node in eleLists)
            {
                XmlNodeList jobNameNode = ((XmlElement)node).GetElementsByTagName("JobName");
                XmlNodeList jobIndexNode = ((XmlElement)node).GetElementsByTagName("JobIndex");
                string jobId = ((XmlElement)node).GetAttribute("id");
                string jobName = jobNameNode[0].InnerText;
                string jobIndex = jobIndexNode[0].InnerText;
                Job job = new Job() { JobName = jobName, JobIndex =jobIndex, Id = jobId };
                jobs.Add(job);
            }

            return jobs;
        }

        public static DataTable GetJobsDataTable()
        {
            List<Job> jobs = XMLHelper.GetJobs(Miscellaneous.GetJobXMLFullPath());
            DataTable dtJobs = new DataTable();
            dtJobs.Columns.Add("JobName");
            dtJobs.Columns.Add("JobIndex");
            dtJobs.Columns.Add("id");

            foreach (Job item in jobs)
            {
                DataRow nameRow = dtJobs.NewRow();

                //ComboBoxItem boxItem = new ComboBoxItem(item.JobIndex, item.JobName);
                nameRow["JobIndex"] = item.JobIndex;
                nameRow["JobName"] = item.JobName;
                nameRow["Id"] = item.Id;
                dtJobs.Rows.Add(nameRow);
            }
            return dtJobs;
        }

    }
}