using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleOrder.Utils
{
    interface InfoHandel<T>
    {
        void CreateInfoNode(string xmlFileName, string xmlPath, string newElement, T t);
    }
}
