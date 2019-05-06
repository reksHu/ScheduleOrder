using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleOrder.Utils
{
   public class ComboBoxItem
    {
        private string key;
        private string value;
        public ComboBoxItem(string _key, string _value)
        {
            key = _key;
            value = _value;
        }
        public string Key
        {
            get { return key; }
        }
        public string Value
        {
            get { return value; }
        }
        public override string ToString()
        {
            return value;
        }
    }
}
