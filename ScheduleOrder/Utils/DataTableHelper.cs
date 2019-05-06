using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace ScheduleOrder.Utils
{
    public class DataTableHelper<T>
    {
        public List<T> ConvertTableToList(DataTable table) {
            List<T> lists = new List<T>();
            Type t = typeof(T);
            PropertyInfo[] pro = t.GetProperties();
            for (int row = 0; row < table.Rows.Count; row++ ) { 
                
            }
            return null;
        }
    }
}
