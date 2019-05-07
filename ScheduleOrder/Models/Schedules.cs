using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleOrder
{
    public class Schedules
    {
        /// <summary>
        /// Scheduler guid
        /// </summary>
        public string Id { get; set; }

        public Nurser ScheduledNurser { get; set; }

        ///// <summary>
        /////  Scheduler start week date, it's scheuler file name
        ///// </summary>
        //public string SchedulerWeek { get; set; }

        /// <summary>
        /// week first day date, e.g 2018-10-1
        /// </summary>
        public string WeekFirstDay { get; set; }

        public List<ScheduleJob> JobsList { get; set; }

       
    }

    public class ScheduleJob {

        /// <summary>
        ///1= monday, 2= thursday...
        /// </summary>
        public string ScheduledWeekday { get; set; }

        ///// <summary>
        ///// Job Morning or Afternoon
        ///// </summary>
        //public string ScheduledJobDayType { get; set; }

        public List<TaskDetail> Tasks { get; set; }


    }


    /// <summary>
    /// Morning or Afternoon
    /// NightShift1表示上夜班
    /// NightShift2下夜班
    /// </summary>
    public enum ScheduledType
    {
        Morning,
        Afternoon,
        NightShift1,
        NightShift2
    }

    public class TaskDetail {
        /// <summary>
        /// Morning or Afternoon
        /// </summary>
        public string JobDayType { get; set; }

        public string JobRating { get; set; }

        public string JobName { get; set; }
    }


}
