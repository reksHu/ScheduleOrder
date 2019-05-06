using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleOrder
{
   public class JobsCount
    {
       private  Dictionary<string,double> jobDict = new Dictionary<string,double>();
       public  void Count(string jobName)
       {
           if(string.IsNullOrEmpty(jobName)){
               return;
           }
           if (jobDict.ContainsKey(jobName))
           {
               double count = jobDict[jobName];
               count = count + 0.5;
               jobDict[jobName] = count;
           }
           else {
               jobDict.Add(jobName, 0.5);
           }
       }

       public  Dictionary<string, double> GetJobDict()
       {
           return jobDict;
       }

       public  void Clear() {
           jobDict.Clear();
       }

       
    }
}
