using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleOrder.Utils;
namespace ScheduleOrder
{
    public class Nurser : IXMLFileElements
    {
       public string Id { get; set; }
       public string NurserName { get; set; } 

       public string NurserLevel { get; set; } //护士层级

       public string NurserLevelRating{ get; set; } //护士层级系数 e.g. 0.8


        //岗位
    }
}
