using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace ScheduleOrder.Utils
{
    public class DatagridviewHelper
    {
        public static DataTable ConvertDataGridViewToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            
            for (int row = 0; row < dgv.Rows.Count; row++)
            {
                //每一行的第一个元素不为空,比如Name
                if (dgv.Rows[row].Cells[0].Value != null &&
                    !string.IsNullOrEmpty(dgv.Rows[row].Cells[0].Value.ToString()))
                {
                    DataRow dr = dt.NewRow();
                    for (int cindex = 0; cindex < dgv.Columns.Count; cindex++)
                    {
                        dr[cindex] = Convert.ToString(dgv.Rows[row].Cells[cindex].Value);
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        ///   <summary>
        ///   比较两个DataTable内容是否相等，先是比数量，数量相等就比内容 
        ///   </summary> 
        ///   <param   name= "dtA "> </param> 
        ///   <param   name= "dtB "> </param> 
        public static bool CompareDataTable(DataTable dtA, DataTable dtB,string sortColumnName)
        {
            string sort = string.Format("{0} ASC", sortColumnName);
            //dtA.DefaultView.Sort = "JobName ASC";
            //dtB.DefaultView.Sort = "JobName ASC";
            dtA.DefaultView.Sort = sort;
            dtB.DefaultView.Sort = sort;
            dtA = dtA.DefaultView.ToTable();
            dtB = dtB.DefaultView.ToTable();
            if (dtA.Rows.Count == dtB.Rows.Count)
            {
                //比内容 
                for (int i = 0; i < dtA.Rows.Count; i++)
                {
                    for (int j = 0; j < dtA.Columns.Count; j++)
                    {
                        if (!dtA.Rows[i][j].Equals(dtB.Rows[i][j]))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
