using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleOrder.Utils;
using System.Xml;

namespace ScheduleOrder
{
   public class DataInit
    {
       

       public static void AddJobNode(string jobxmlFullPath,Job job) {
           string rootElement = "Jobs";
           try
           {
               XMLHelper.CreateJobNode(jobxmlFullPath, rootElement, job);
           }
           catch (Exception ex) { 
             
           }
       }

       public static void AddNurseNode(string nurserXmlFullPath, Nurser nurser)
       {
           string rootElement = "Nursers";

           try
           {
               XMLHelper.CreateNurseNode(nurserXmlFullPath, rootElement, nurser);
           }
           catch (Exception ex)
           {

           }

       }

       public static void UpdateNurses(List<Nurser> updatedNurseList) {
           string fullpath =  Miscellaneous.GetNurseXMLFullPath();
           try
           {
               XMLHelper.DeleteXMLFile(fullpath);
               XMLHelper.CreateXmlFile(fullpath, "data", AppConfiguration.GetNurserXMLRootNode());
               XMLHelper.CreateNurseNodes(Miscellaneous.GetNurseXMLFullPath(), AppConfiguration.GetNurserXMLRootNode(), updatedNurseList);
               //AddSchedulerNodes(fullpath, updatedNurseList);

           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public static void AddSchedulerNodes(string schedulerXmlFullPath, List<Schedules> schedulesList)
       {
           string rootElement = "Schedules";
           try
           {
               XMLHelper.CreateXmlFile(schedulerXmlFullPath, "data", rootElement);
               XMLHelper.CreateSchedulesNodes(schedulerXmlFullPath, rootElement, schedulesList);
           }
           catch (Exception ex)
           {
           }
       }

       public static void UpdateSchedulerNodes(string schedulerXmlFullPath, List<Schedules> schedulesList)
       {
           try {
               XMLHelper.DeleteXMLFile(schedulerXmlFullPath);
               AddSchedulerNodes(schedulerXmlFullPath, schedulesList);
               
           }catch(Exception ex){
               throw ex;
           }

       }

       public static void UpdateJobNode(string jobxmlFullPath, string nodeName, Job job) {
           try
           {
               string nodeRootName = "Jobs";
               XMLHelper.UpdateJobNode(jobxmlFullPath, nodeRootName, job);
           }
           catch (Exception ex) { 
            
           }
       }

       public static void UpdateJobs(string jobxmlFullPath, List<Job> Jobs) { 
         
       }

       public static List<Job> CovertJobTableToLists(System.Data.DataTable jobTable) {
           List<Job> jobsList = new List<Job>();
           for (int row = 0; row < jobTable.Rows.Count; row++)
           {
               if (jobTable.Rows[row][0] != null &&
                   !string.IsNullOrEmpty(jobTable.Rows[row][0].ToString()) &&
                   jobTable.Rows[row][1]!=null &&
                    !string.IsNullOrEmpty(jobTable.Rows[row][1].ToString())) 
               {
                   Job job = new Job();
                   job.JobName = jobTable.Rows[row][0].ToString();
                   job.JobIndex = jobTable.Rows[row][1].ToString();
                   job.Id = jobTable.Rows[row][2].ToString();
                   jobsList.Add(job);
               }
           }
           return jobsList;
       }

       
       public static void UpdateNurserNode(string nurserXmlFullPath,Nurser nurser) {
           try {
               XMLHelper.UpdateNurserNode(nurserXmlFullPath, nurser);
           }catch(Exception ex){
           }
            
       }


      


       /// <summary>
       /// get schedules data for reporting
       /// </summary>
       /// <param name="monthStr"></param>
       /// <returns></returns>
       public static Dictionary<string, JobsCount> GetSchedulesDataForReporint(string monthStr)
       {
           List<string> filesNames = XMLHelper.GetSchedulerReportingFiles(monthStr, "data");
           return XMLHelper.GetSchedulesForReporting(filesNames);
       }


       public static void checkNodeTest(string xmlFullPath)
       {
           XmlDocument doc = new XmlDocument();
           doc.Load(xmlFullPath);
           XmlNode nodes = doc.SelectSingleNode("Jobs");
           string id = "ad66328d-0946-4b16-8292-e77a6a1a185d";
           bool isUpdated = false;
           foreach (XmlNode node in nodes) {
               XmlElement ele = (XmlElement)node;
               string eleId = ele.GetAttribute("id");
               
               if (eleId.Equals(id))
               {
                   XmlNodeList nls = node.ChildNodes;
                   nls[0].InnerText = "责主";
                   nls[1].InnerText = "0.98";
                   isUpdated = true;
                   continue;
               }
           }
           if (isUpdated)
           {
               doc.Save(xmlFullPath);
           }

       }


       public static bool IsFileExited(string fileFullPath)
       {
           bool isExisted = System.IO.File.Exists(fileFullPath);
           return isExisted;
       }
    }
}
