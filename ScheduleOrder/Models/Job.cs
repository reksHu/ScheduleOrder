using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleOrder
{
    public class Job
    {
        public string JobName { get; set; } //岗位名称
        public string JobIndex { get; set; } //岗位系数
        public string Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Job) {
                Job job = obj as Job;
                if(this.Id.Equals(job.Id) && 
                    this.JobName.Equals(job.JobName) &&
                    this.JobIndex.Equals(JobIndex)
                    ){
                        return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
